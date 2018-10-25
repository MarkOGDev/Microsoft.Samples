
using Azure.Data.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo
{
    public static class TableBindingWithWrappers
    {
        public class MyPoco2 : TableEntity
        {
            public string Name { get; set; }
            public string Job { get; set; }
        }


        [FunctionName("ListAllWithWrappers")]
        public static async System.Threading.Tasks.Task<JsonResult> ListAllWithWrappers(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ListAllWithWrappers")] HttpRequest req,
           [Table("TableBinding")] CloudTable cloudTable,
           ILogger log)
        {

            log.LogInformation("YO AzureWebJobsStorage Setting = " + System.Environment.GetEnvironmentVariable("AzureWebJobsStorage"));
            log.LogInformation("YO marksVar Setting = " + System.Environment.GetEnvironmentVariable("marksVar"));
            log.LogInformation($"cloudTable.Name = {cloudTable.Name}");

            //Using Azure.Data.Wrappers 

            //get stroage account string from env/app settings
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(System.Environment.GetEnvironmentVariable("AzureWebJobsStorage"));

            //Create the Azure.Data.Wrappers.TableStorage Obejct 
            TableStorage _myTableStorage = new TableStorage(cloudTable.Name, cloudStorageAccount);

            //Define and execute query
            var query = new TableQuery<MyPoco2>();
            var results = await _myTableStorage.Query<MyPoco2>(query);

            //Return Json Formatted Data
            return new JsonResult(results);

        }
    }
}