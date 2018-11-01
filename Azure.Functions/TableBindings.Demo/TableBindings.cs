using System.Collections.Generic;
using System.Threading.Tasks;
using MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;

namespace MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo
{
    /// <summary>
    /// Table Bindings Demos
    /// </summary>
    public static class TableBindings
    { 
        /// <summary>
        /// Returns a Row of data from Table Storage (Table Binding) in Response to a HTTP URL Request (HTTP Trigger)        
        /// </summary>
        /// <param name="req"></param>
        /// <param name="poco"></param>
        /// <param name="log"></param>
        /// <param name="PartitionKey"></param>
        /// <param name="RowKey"></param>
        /// <returns></returns>
        [FunctionName("TableGetRow")]
        public static JsonResult TableGetRow(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "TableGetRow/{PartitionKey}/{RowKey}")] HttpRequest req,          
            [Table("TableBinding", "{PartitionKey}", "{RowKey}")] MyPoco poco,                                                      
            ILogger log,
            string PartitionKey,                                                         
            string RowKey)
        {
            log.LogInformation($"Hello: Query PartitionKey={PartitionKey} and Query RowKey={RowKey}");
            log.LogInformation($"PK={poco.PartitionKey}, RK={poco.RowKey}, Name={poco.Name}, Job={poco.Job}");

            return new JsonResult(poco);
        }
                  

        /// <summary>
        /// Alternative Version show how to allow Content Negotiation. If the request has an Accept header of 'application/XML' the response will be returned in XML.
        /// You can test this easily using 'PostMan App'
        /// </summary>
        /// <param name="req"></param>
        /// <param name="poco"></param>
        /// <param name="log"></param>
        /// <param name="PartitionKey"></param>
        /// <param name="RowKey"></param>
        /// <returns></returns>
        [FunctionName("TableGetRowJsonOrXml")]
        public static ActionResult TableGetRowJsonOrXml(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "TableGetRowJsonOrXml/{PartitionKey}/{RowKey}")] HttpRequest req,       
           [Table("TableBinding", "{PartitionKey}", "{RowKey}")] MyPoco poco,                                                     
           ILogger log,
           string PartitionKey,                                                                
           string RowKey)
        {
            log.LogInformation($"Hello: Query PartitionKey={PartitionKey} and Query RowKey={RowKey}");
            log.LogInformation($"PK={poco.PartitionKey}, RK={poco.RowKey}, Name={poco.Name}, Job={poco.Job}");

            return poco != null
               ? (ActionResult)new OkObjectResult(poco)
               : new BadRequestObjectResult("Data not found.");
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
              [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "TableListByPartition/{PartitionKey}")] HttpRequest req,
              [Table("TableBinding")] CloudTable cloudTable,
              ILogger log,
              string PartitionKey)
        {
            var query = new TableQuery<MyPoco>();
            query.Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, PartitionKey));

            TableContinuationToken continueToken = null;
            var entities = new List<MyPoco>();

            do
            {
                var queryResult = await cloudTable.ExecuteQuerySegmentedAsync(query, continueToken);
                entities.AddRange(queryResult);
                continueToken = queryResult.ContinuationToken;

            } while (continueToken != null);

            return new JsonResult(entities);
        }




        /// <summary>
        /// Returns All rows from a Table.
        /// </summary>
        /// <param name="req"></param>
        /// <param name="cloudTable"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        [FunctionName("TableListAll")]
        public static async System.Threading.Tasks.Task<JsonResult> TableListAll(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "TableListAll")] HttpRequest req,
        [Table("TableBinding")] CloudTable cloudTable,
        ILogger log)
        {
            TableContinuationToken token = null;
            var entities = new List<MyPoco>();
            do
            {
                var queryResult = await cloudTable.ExecuteQuerySegmentedAsync(new TableQuery<MyPoco>(), token);
                entities.AddRange(queryResult);
                token = queryResult.ContinuationToken;

            } while (token != null);

            //Return Json Formatted Data.
            return new JsonResult(entities);
        }




        //TODO:
        //Document  function TableGetRowJsonOrXml
        //Make insert , update,delete demos

        //Add error handling/error messages

    }
}
