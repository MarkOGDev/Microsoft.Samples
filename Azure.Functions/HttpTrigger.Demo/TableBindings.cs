using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;

namespace HttpTrigger
{
    public static class TableBindings
    {
        public class MyPoco
        {
            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public string Name { get; set; }
            public string Job { get; set; }
        }

        /// <summary>
        /// Returns a Row of data from Table Storage (Table Binding) in Response to a Http Url Request (Http Trigger)
        /// </summary>
        /// <param name="req"></param>
        /// <param name="poco"></param>
        /// <param name="log"></param>
        /// <param name="PartitionKey"></param>
        /// <param name="RowKey"></param>
        /// <returns></returns>
        [FunctionName("TableRowOut")]
        public static JsonResult TableInput(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "TableRowOut/{PartitionKey}/{RowKey}")] HttpRequest req,       //Trigger Route expects two parameters in Nice Url Style    
            [Table("TableBinding", "{PartitionKey}", "{RowKey}")] MyPoco poco,                                                      //poco is the object that will be returned from the table
            ILogger log,
            string PartitionKey,                                                                //pass the params into the function so we can use them if nessasary. 
            string RowKey)
        {
            //Log Query and Reult Info
            log.LogInformation($"Hello: Query PartitionKey={PartitionKey} and Query RowKey={RowKey}");
            log.LogInformation($"PK={poco.PartitionKey}, RK={poco.RowKey}, Name={poco.Name}, Job={poco.Job}");

            //Return Json Formatted Data
            return new JsonResult(poco);

        }







        //## Using Table Entity our POCO must inherit from TableEntity


        public class MyPoco2 : TableEntity
        {
            public string Name { get; set; }
            public string Job { get; set; }
        }




        /// <summary>
        ///  Returns All rows from a Partition of a Table.
        /// </summary>
        /// <param name="req"></param>
        /// <param name="cloudTable"></param>
        /// <param name="log"></param>
        /// <param name="PartitionKey"></param>
        /// <returns></returns>
        [FunctionName("TableListByPartition")]
        public static async Task<JsonResult> TableListByPartition(
              [HttpTrigger(AuthorizationLevel.Function, "get", Route = "TableListByPartition/{PartitionKey}")] HttpRequest req,
              [Table("TableBinding")] CloudTable cloudTable,
              ILogger log,
              string PartitionKey)
        {
            var query = new TableQuery<MyPoco2>();
            query.Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, PartitionKey));

            TableContinuationToken continueToken = null;
            var entities = new List<MyPoco2>();

            do
            {
                var queryResult = await cloudTable.ExecuteQuerySegmentedAsync(query, continueToken);
                entities.AddRange(queryResult);
                continueToken = queryResult.ContinuationToken;

            } while (continueToken != null);

            //Return Json Formatted Data
            return new JsonResult(entities);
        }




        /// <summary>
        /// Returns All rows from a Table.
        /// </summary>
        /// <param name="req"></param>
        /// <param name="cloudTable"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        [FunctionName("GetAll")]
        public static async System.Threading.Tasks.Task<JsonResult> TableListAllSegmentedAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetAll")] HttpRequest req,
        [Table("TableBinding")] CloudTable cloudTable,
        ILogger log)
        {

            //### KEEP - Without Wrappers
            TableContinuationToken token = null;
            var entities = new List<MyPoco2>();
            do
            {
                var queryResult = await cloudTable.ExecuteQuerySegmentedAsync(new TableQuery<MyPoco2>(), token);
                entities.AddRange(queryResult);
                token = queryResult.ContinuationToken;

            } while (token != null);

            //Return Json Formatted Data
            return new JsonResult(entities);

        }

        public class RadioStationEntity : TableEntity
        {
            //#### Entity COnstructors #####

            /// <summary>
            /// Initializes a new instance of the <see cref="RadioStationEntity"/> class.
            /// Your entity type must expose a parameter-less constructor
            /// </summary>
            public RadioStationEntity()
            {

            }


            /// <summary>
            /// Initializes a new instance of the <see cref="RadioStationEntity"/> class.
            /// Defines the PK and RK.
            /// </summary>
            /// <param name="countryCode"></param>
            /// <param name="channelNumber"></param>
            public RadioStationEntity(string countryCode, int channelNumber)
            {
                this.PartitionKey = countryCode;
                this.RowKey = channelNumber.ToString();
            }


            //#### Entity Properties #####

            /// <summary>
            /// Gets or sets the Station Name
            /// A property for use in Table storage must be a public property of a 
            /// supported type that exposes both a getter and a setter.     
            /// </summary>
            /// <value>
            /// The station Name.
            /// </value>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the Web URL of the Station Home Page
            /// </summary>       
            /// <value>
            /// The station Station Home Page Url.
            /// </value>
            public string Url { get; set; }

            /// <summary>
            /// The Web Play URL of the Station. The url to connect to in order to listen to the station.
            /// </summary>
            /// <value>
            /// The PlayUrl  
            /// </value>
            public string PlayUrl { get; set; }

            /// <summary>
            /// The Local Frequency of the Radio Station. E.g. 89.9 FM
            /// </summary>
            public string Frequency { get; set; }

            /// <summary>
            /// Station Description
            /// </summary>
            /// <value>
            /// The Description Text
            /// </value>
            public string Description { get; set; }

            public string ImageUrl { get; set; }

            /// <summary>
            /// We Could have a category for stations, but where to get cat info from? 
            /// </summary>
            public string Category
            {
                get;
                set;
            }


            /// <summary>
            /// Returns the Partition Key
            /// </summary>
            /// <returns></returns>
            public string GetCountryCode()
            {
                return this.PartitionKey;
            }

            /// <summary>
            ///  Returns the Channel Number
            /// </summary>
            /// <returns></returns>
            public string GetChannelNumber()
            {
                return this.RowKey;
            }


        }



        /// <summary>
        /// Returns Radio Stations By Country. CountryCode is the Partition Key of the Azure Table.
        /// </summary>
        /// <param name="req"></param>
        /// <param name="cloudTable"></param>
        /// <param name="log"></param>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        [FunctionName("ByCountry")]
        public static async Task<JsonResult> ByCountry(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "byCountry/{countryCode}")] HttpRequest req,
            [Table("OnlineRadio")] CloudTable cloudTable,
            ILogger log,
            string countryCode)
        {
            log.LogInformation($"C# HTTP trigger function processed a request. ByCountry {countryCode}");

            //Define the Table Query   
            var query = new TableQuery<RadioStationEntity>();
            //GenerateFilterCondition creates a string  
            query.Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, countryCode));

            //loop through all data 
            TableContinuationToken continueToken = null;        //we could use the continueToken to cancell the request if we meet a condition we dont like.
            var entities = new List<RadioStationEntity>();

            do
            {
                //ExecuteQuerySegmentedAsync
                //https://docs.microsoft.com/en-us/azure/cosmos-db/table-storage-how-to-use-dotnet#retrieve-entities-in-pages-asynchronously
                var queryResult = await cloudTable.ExecuteQuerySegmentedAsync(query, continueToken);
                entities.AddRange(queryResult);
                continueToken = queryResult.ContinuationToken;

            } while (continueToken != null);

            //Return Json Formatted Data
            return new JsonResult(entities);
        }




    }
}
