using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace HttpTriggerUnitTestProject
{
    [TestClass]
    public class HelloWorldFunctionUnitTest
    {

        //### FIX

        /// <summary>
        /// Tests the output of the function. We could crete a Integration Test that executes the url.
        /// </summary>
        //[TestMethod]
        //public void HelloWorld3Test()
        //{
        //    var _log = new Mock<ILogger>();
        //    var _req = new Mock<HttpRequest>();
        //    var _name = "Peter";                //Test name Parameter

        //    var result = HttpTrigger.HelloWorldFunction.HelloWorld3(req: _req.Object, log: _log.Object, name: _name);

        //    Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        //    Assert.AreEqual($"Hello, {_name}", ((OkObjectResult)result).Value); //Expected Result: "Hello Peter"
        //}


       

    }
}
