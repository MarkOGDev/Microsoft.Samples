using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MarkOGDev.Microsoft.Samples.Azure.Functions.HttpTrigger.Demo
{
    /// <summary>
    /// A Class Library containing Azure Functions
    /// </summary>
    public static class HelloWorldFunctions
    {

        //Route Example 
        //https://httptriggerdemo.azurewebsites.net/api/hello3/Mark
        //Functions add api automatically to url
        //We can change the default prefix: https://docs.microsoft.com/en-us/sandbox/functions-recipes/routes?tabs=csharp



        /// <summary>
        /// Hello World.
        /// <para>Configured for Get Requests</para>
        /// </summary>
        /// <param name="req"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        [FunctionName("HelloWorld1")]
        public static IActionResult HelloWorld1(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "hello1")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("HelloWorld1() C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }


        /// <summary>
        /// Hello World.
        /// <para>Configured for Get and Post Requests</para>
        /// </summary>
        /// <param name="req"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        [FunctionName("HelloWorld2")]
        public static async Task<IActionResult> HelloWorld2(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "hello2")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("HelloWorld2() C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }


  

        /// <summary>
        /// This is an example with a url parameter specified. The url must pass a {name} or the route won't match.
        /// <para>Configured for Get Requests</para>
        /// </summary>
        /// <param name="req"></param>
        /// <param name="log"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [FunctionName("HelloWorld3")]
        public static IActionResult HelloWorld3(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "hello3/{name}")] HttpRequest req,
           ILogger log,
           string name)
        {
             log.LogInformation("HelloWorld3() C# HTTP trigger function processed a request.");

            return (ActionResult)new OkObjectResult($"Hello, {name}");
        }

    }
}
