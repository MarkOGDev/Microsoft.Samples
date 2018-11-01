# C# Azure Functions V2 - Azure Table Binding Example

[Back to Azure Functions Introduction](../readmeFunctionsIntro.md)

This example code shows you how to make **Azure Functions V2** with both **HTTP Trigger** and **Azure Table Binding**.

An HttpTrigger will trigger a function to run in response to an incoming HTTP Request.

The Table Binding will give us easy access to our Azure Table data.

## Development Tools

Required / useful tools for this example are:

* [Visual Studio](https://visualstudio.microsoft.com/)
* [Azure Storage Emulator](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator)
* [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/)
* [Postman App](https://www.getpostman.com/) (Manually test and view your Azure Function responses)

   
## Http Trigger With Table Binding

To add Table storage bindings to your project add NuGet package [Microsoft.Azure.WebJobs.Extensions.Storage](https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.Storage)

## Example Code

Local storage contains a table named "TableBinding" that looks like this:

| PartitionKey  |  RowKey       |   Timestamp                | Name              |           Job     |
| :--------:    | :-----:       |    :--------:              | :--------:        |  :-----:          |
| London        |     JoeJoe    |    [TimeStamp Data]        | Joe Smooth Jenkins | Cook             | 
| London        |     PeterSmith |   [TimeStamp Data]        |Peter Livingstone Smith |  Cleaner    | 

We represent a Table Row with the following class:

File: [Types/MyPoco.cs](Types/MyPoco.cs)

```csharp
public class MyPoco : TableEntity
{
    public string Name { get; set; }
    public string Job { get; set; }
}
```

File: [TableBindings.cs](TableBindings.cs)

### Table Get Row

```csharp
[FunctionName("TableGetRow")]
public static JsonResult TableGetRow(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "TableGetRow/{PartitionKey}/{RowKey}")] HttpRequest req,        
    [Table("TableBinding", "{PartitionKey}", "{RowKey}")] MyPoco poco,                                                      //poco is the object that will be returned from the table
    ILogger log,
    string PartitionKey,                                                                 
    string RowKey)
{ 
    log.LogInformation($"Hello: Query PartitionKey={PartitionKey} and Query RowKey={RowKey}");
    log.LogInformation($"PK={poco.PartitionKey}, RK={poco.RowKey}, Name={poco.Name}, Job={poco.Job}");
     
    return new JsonResult(poco);
}
```

```csharp
[FunctionName("TableGetRow")]
public static JsonResult TableGetRow(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "TableGetRow/{PartitionKey}/{RowKey}")] HttpRequest req,        
    [Table("TableBinding", "{PartitionKey}", "{RowKey}")] MyPoco poco,                                                      //poco is the object that will be returned from the table
    ILogger log,
    string PartitionKey,                                                                 
    string RowKey)
{ 
    log.LogInformation($"Hello: Query PartitionKey={PartitionKey} and Query RowKey={RowKey}");
    log.LogInformation($"PK={poco.PartitionKey}, RK={poco.RowKey}, Name={poco.Name}, Job={poco.Job}");
     
    return new JsonResult(poco);
}
```
 
#### Route

```
/api/TableGetRow/{PartitionKey}/{RowKey}
```

#### Example URL

http://localhost:7071/api/TableGetRow/London/JoeJoe

#### Live Demo URL

https://tablebindingsdemo.azurewebsites.net/api/TableGetRow/London/JoeJoe




### Table Get Row as XML or Json

```csharp
[FunctionName("TableGetRowJsonOrXml")]
public static ActionResult TableGetRowJsonOrXml(
    [HttpTrigger(AuthorizationLevel.Function, "get", Route = "TableGetRowJsonOrXml/{PartitionKey}/{RowKey}")] HttpRequest req,       //Trigger Route expects two parameters in Nice Url Style    
    [Table("TableBinding", "{PartitionKey}", "{RowKey}")] MyPoco poco,                                                      //poco is the object that will be returned from the table
    ILogger log,
    string PartitionKey,                                                                //pass the params into the function so we can use them if nessasary. 
    string RowKey)
{ 
    return poco != null
        ? (ActionResult)new OkObjectResult(poco)
        : new BadRequestObjectResult("Data not found.");
}
```

#### Route

```
/api/TableListByPartition/{PartitionKey}
```

#### Example URL

http://localhost:7071/api/TableListByPartition/London

#### Live Demo URL

https://tablebindingsdemo.azurewebsites.net/api/TableListByPartition/London



### Table List by Partition

```csharp
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

    //Return Json Formatted Data
    return new JsonResult(entities);
}
```

Example URL:
* http://localhost:7071/api/TableListByPartition/{PartitionKey}
* http://localhost:7071/api/TableListByPartition/London
 

#### Route

```
/api/TableListByPartition/{PartitionKey}
```

#### Example URL

http://localhost:7071/api/TableListByPartition/London

#### Live Demo URL

https://tablebindingsdemo.azurewebsites.net/api/TableListByPartition/London


### Table List All

```csharp
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

    //Return Json Formatted Data
    return new JsonResult(entities);
}
```

 
#### Route

```
/api/TableListAll
```

#### Example URL

http://localhost:7071/api/TableListAll

#### Live Demo URL

https://tablebindingsdemo.azurewebsites.net/api/TableListAll


## Table Binding with Azure.Data.Wrappers

[Azure.Data.Wrappers](https://github.com/Microsoft/Azure.Data.Wrappers) provide Simplified Azure Storage usage.

File: [TableBindings.cs](TableBindings.cs)

```csharp
[FunctionName("ListAllWithWrappers")]
public static async System.Threading.Tasks.Task<JsonResult> ListAllWithWrappers(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ListAllWithWrappers")] HttpRequest req,
    [Table("TableBinding")] CloudTable cloudTable,
    ILogger log)
{

    log.LogInformation("YO AzureWebJobsStorage Setting = " + System.Environment.GetEnvironmentVariable("AzureWebJobsStorage"));
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
```

#### Route

```
/api/ListAllWithWrappers
```

#### Example URL

http://localhost:7071/api/ListAllWithWrappers

#### Live Demo URL

https://tablebindingsdemo.azurewebsites.net/api/ListAllWithWrappers
 