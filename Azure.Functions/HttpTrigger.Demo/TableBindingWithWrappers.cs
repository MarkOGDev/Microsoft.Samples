
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace HttpTrigger
{
    public static class TableBindingWithWrappers
    {
        public class MyPoco2 : TableEntity
        {
            public string Name { get; set; }
            public string Job { get; set; }
        }

        [FunctionName("ListAllAsync")]
        public static async System.Threading.Tasks.Task<JsonResult> ListAllAsync(
           [HttpTrigger(AuthorizationLevel.Function, "get", Route = "ListAll")] HttpRequest req,
           [Table("TableBinding")] CloudTable cloudTable,
           ILogger log)
        {
            //To use Azure.Data.Wrappers we can get credentials from the table 
            CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(cloudTable.ServiceClient.Credentials, useHttps: true);

            log.LogInformation($"cloudTable.Name = {cloudTable.Name}");
         //   log.LogInformation($"cloudTable.Name = {cloudTable.}");


            //Create the Azure.Data.Wrappers.TableStorage Obejct 
          //  Azure.Data.Wrappers.TableStorage _myTableStorage = new Azure.Data.Wrappers.TableStorage(cloudTable.Name, cloudStorageAccount);
            Azure.Data.Wrappers.TableStorage _myTableStorage = new Azure.Data.Wrappers.TableStorage(cloudTable.Name, "UseDevelopmentStorage=true");


            //Define and execute query
            var query = new Microsoft.WindowsAzure.Storage.Table.TableQuery<MyPoco2>();
            var results = await _myTableStorage.Query<MyPoco2>(query);                  

            //Return Json Formatted Data
            return new JsonResult(results);





            //### KEEP - Without Wrappers
            //TableContinuationToken token = null;
            //var entities = new List<MyPoco2>();
            //do
            //{
            //    var queryResult = cloudTable.ExecuteQuerySegmentedAsync(new TableQuery<MyPoco2>(), token);
            //    entities.AddRange(queryResult.Result);
            //    token = queryResult.ContinuationToken;
            //} while (token != null);












            //var query = new TableQuery<MyPoco2>();  //get all query

            //var queryResult = await cloudTable.ExecuteQuerySegmentedAsync(query, null);  //execute query

            //cloudTable.

            //var table = new TableStorage(("Table", "UseDevelopmentStorage=true");
            //table.


            ////log info 
            //foreach (MyPoco2 entity in queryResult)
            //{
            //    log.LogInformation(
            //        $"{entity.PartitionKey}\t{entity.RowKey}\t{entity.Name}\t{entity.Job}");
            //}

            //Return Json Formatted Data
            //  return new JsonResult(queryResult);

        }
    }
}