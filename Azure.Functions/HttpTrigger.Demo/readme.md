# Azure Functions V2 - HTTP Trigger Example

[Back to Functions Introduction](../../Docs/functionsIntroductionReadme.md)


This example code shows you how to make **Azure Functions V2** with an **Http Trigger**.

An HttpTrigger will trigger a function to run in response to an incomming Http Request.

## Development Tools
Required / useful tools for this example are:

* [Visual Studio](https://visualstudio.microsoft.com/)
* [Azure Storage Emulator](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator)
* [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/)
* [Postman App](https://www.getpostman.com/) (Manually test and view your Azure Function responses)

## Creating a Function 

You can create new functions in many ways. I prefer using Visual Studio.

See [Create your first function using Visual Studio.](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-your-first-function-visual-studio)

[Guides are available for Azure Portal, Visual Studio Code, Azure Cli and more.](https://docs.microsoft.com/en-us/azure/azure-functions/)
 
 


## Example Code

File: [HelloWorldFunction.cs](/HelloWorldFunction.cs)


| Parameter name  |  Example  |
| :--------:| :-----:|
| name    |     Peter | 
 


### HelloWorld1 - Query String Parameters 
* Configured for **Get** Requests
* Requires a **name parameter** in the Query String

#### Route

```
/api/hello1?name={name}
```

#### Example Url
* http://localhost:7071/api/hello1?name=Peter

#### Live Url
* https://httptriggerdemo.azurewebsites.net/api/hello1?name=Peter

#### HelloWorld1 C# Function Code

```c#
[FunctionName("HelloWorld1")]
public static IActionResult HelloWorld1(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "hello1")] HttpRequest req,
    ILogger log)
{
    log.LogInformation("HelloWorld1() with route 'hello1/' C# HTTP trigger function processed a request.");

    string name = req.Query["name"];

    return name != null
        ? (ActionResult)new OkObjectResult($"Hello, {name}")
        : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
}
```

### HelloWorld2 - Query String Parameters
* Configured for **Get** and **Post** Requests
* Requires a **name parameter** in the query string or **name paramter** posted in the request body.

Posted Data may look like this:
```json
{
    "name":"Peter"
}
```

#### Route

```
/api/hello2?name={name}
```

#### Example Url

* http://localhost:7071/api/hello2?name=Peter


#### Live Url

* https://httptriggerdemo.azurewebsites.net/api/hello2?name=Peter

#### HelloWorld2 C# Function Code

```c#
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
```

### HelloWorld3 - Nice Url Parameters

* Configured for **Get** Requests
* Requires a **name value** in the url
 
#### Route

```
/api/hello3/{name}
```

#### Example Url

* http://localhost:7071/api/hello3/Peter

#### Live Url

* https://httptriggerdemo.azurewebsites.net/api/hello3/Peter

#### HelloWorld3 C# Function Code

```c#
[FunctionName("HelloWorld3")]
public static IActionResult HelloWorld3(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "hello3/{name}")] HttpRequest req,
    ILogger log,
    string name)
{
        log.LogInformation("HelloWorld3() C# HTTP trigger function processed a request.");

    return (ActionResult)new OkObjectResult($"Hello, {name}");
}
```

 