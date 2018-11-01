
using Azure.Data.Wrappers;
using MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo
{
    /// <summary>
    /// Examples of Azure Table Binding With Azure.Data.Wrappers.
    /// </summary>
    public static class TableBindingWithWrappers
    { 
        /// <summary>
        /// Returns All data from a cloudTable
        /// Using Azure.Data.Wrappers to 
        /// </summary>
        /// <param name="req"></param>
        /// <param name="cloudTable"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        [FunctionName("ListAllWithWrappers")]
        public static async System.Threading.Tasks.Task<JsonResult> ListAllWithWrappers(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ListAllWithWrappers")] HttpRequest req,
           [Table("TableBinding")] CloudTable cloudTable,
           ILogger log)
        {
            log.LogInformation("YO AzureWebJobsStorage Setting = " + System.Environment.GetEnvironmentVariable("AzureWebJobsStorage"));
            log.LogInformation($"cloudTable.Name = {cloudTable.Name}");

            //Using Azure.Data.Wrappers 

            //get storage account string from ENV/app settings
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(System.Environment.GetEnvironmentVariable("AzureWebJobsStorage"));

            //Create the Azure.Data.Wrappers.TableStorage Object 
            TableStorage _myTableStorage = new TableStorage(cloudTable.Name, cloudStorageAccount);

            //Define and execute query
            var query = new TableQuery<MyPoco>();
            var results = await _myTableStorage.Query<MyPoco>(query);

            //Return Json Formatted Data
            return new JsonResult(results);

        }
    }
}