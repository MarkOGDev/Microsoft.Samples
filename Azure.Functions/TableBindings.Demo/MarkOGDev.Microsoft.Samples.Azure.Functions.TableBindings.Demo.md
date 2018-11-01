<a name='assembly'></a>
# MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo

## Contents

- [MyPoco](#T-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-Types-MyPoco 'MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.Types.MyPoco')
  - [Job](#P-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-Types-MyPoco-Job 'MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.Types.MyPoco.Job')
  - [Name](#P-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-Types-MyPoco-Name 'MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.Types.MyPoco.Name')
- [TableBindings](#T-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-TableBindings 'MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.TableBindings')
  - [TableGetRow(req,poco,log,PartitionKey,RowKey)](#M-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-TableBindings-TableGetRow-Microsoft-AspNetCore-Http-HttpRequest,MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-Types-MyPoco,Microsoft-Extensions-Logging-ILogger,System-String,System-String- 'MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.TableBindings.TableGetRow(Microsoft.AspNetCore.Http.HttpRequest,MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.Types.MyPoco,Microsoft.Extensions.Logging.ILogger,System.String,System.String)')
  - [TableGetRowJsonOrXml(req,poco,log,PartitionKey,RowKey)](#M-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-TableBindings-TableGetRowJsonOrXml-Microsoft-AspNetCore-Http-HttpRequest,MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-Types-MyPoco,Microsoft-Extensions-Logging-ILogger,System-String,System-String- 'MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.TableBindings.TableGetRowJsonOrXml(Microsoft.AspNetCore.Http.HttpRequest,MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.Types.MyPoco,Microsoft.Extensions.Logging.ILogger,System.String,System.String)')
  - [TableListAll(req,cloudTable,log)](#M-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-TableBindings-TableListAll-Microsoft-AspNetCore-Http-HttpRequest,Microsoft-WindowsAzure-Storage-Table-CloudTable,Microsoft-Extensions-Logging-ILogger- 'MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.TableBindings.TableListAll(Microsoft.AspNetCore.Http.HttpRequest,Microsoft.WindowsAzure.Storage.Table.CloudTable,Microsoft.Extensions.Logging.ILogger)')
  - [TableListByPartition(req,cloudTable,log,PartitionKey)](#M-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-TableBindings-TableListByPartition-Microsoft-AspNetCore-Http-HttpRequest,Microsoft-WindowsAzure-Storage-Table-CloudTable,Microsoft-Extensions-Logging-ILogger,System-String- 'MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.TableBindings.TableListByPartition(Microsoft.AspNetCore.Http.HttpRequest,Microsoft.WindowsAzure.Storage.Table.CloudTable,Microsoft.Extensions.Logging.ILogger,System.String)')
- [TableBindingWithWrappers](#T-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-TableBindingWithWrappers 'MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.TableBindingWithWrappers')
  - [ListAllWithWrappers(req,cloudTable,log)](#M-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-TableBindingWithWrappers-ListAllWithWrappers-Microsoft-AspNetCore-Http-HttpRequest,Microsoft-WindowsAzure-Storage-Table-CloudTable,Microsoft-Extensions-Logging-ILogger- 'MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.TableBindingWithWrappers.ListAllWithWrappers(Microsoft.AspNetCore.Http.HttpRequest,Microsoft.WindowsAzure.Storage.Table.CloudTable,Microsoft.Extensions.Logging.ILogger)')

<a name='T-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-Types-MyPoco'></a>
## MyPoco `type`

##### Namespace

MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.Types

##### Summary

Example Class representing a table row.

MyPoco inherits TableEntity which adds the Partition Key, RowKey, TimeStamp and eTag.

<a name='P-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-Types-MyPoco-Job'></a>
### Job `property`

##### Summary

Example Property

<a name='P-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-Types-MyPoco-Name'></a>
### Name `property`

##### Summary

Example Property

<a name='T-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-TableBindings'></a>
## TableBindings `type`

##### Namespace

MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo

##### Summary

Table Bindings Demos

<a name='M-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-TableBindings-TableGetRow-Microsoft-AspNetCore-Http-HttpRequest,MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-Types-MyPoco,Microsoft-Extensions-Logging-ILogger,System-String,System-String-'></a>
### TableGetRow(req,poco,log,PartitionKey,RowKey) `method`

##### Summary

Returns a Row of data from Table Storage (Table Binding) in Response to a HTTP URL Request (HTTP Trigger)

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| req | [Microsoft.AspNetCore.Http.HttpRequest](#T-Microsoft-AspNetCore-Http-HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest') |  |
| poco | [MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.Types.MyPoco](#T-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-Types-MyPoco 'MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.Types.MyPoco') |  |
| log | [Microsoft.Extensions.Logging.ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') |  |
| PartitionKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| RowKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-TableBindings-TableGetRowJsonOrXml-Microsoft-AspNetCore-Http-HttpRequest,MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-Types-MyPoco,Microsoft-Extensions-Logging-ILogger,System-String,System-String-'></a>
### TableGetRowJsonOrXml(req,poco,log,PartitionKey,RowKey) `method`

##### Summary

Alternative Version show how to allow Content Negotiation. If the request has an Accept header of 'application/XML' the response will be returned in XML.
You can test this easily using 'PostMan App'

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| req | [Microsoft.AspNetCore.Http.HttpRequest](#T-Microsoft-AspNetCore-Http-HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest') |  |
| poco | [MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.Types.MyPoco](#T-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-Types-MyPoco 'MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo.Types.MyPoco') |  |
| log | [Microsoft.Extensions.Logging.ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') |  |
| PartitionKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| RowKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-TableBindings-TableListAll-Microsoft-AspNetCore-Http-HttpRequest,Microsoft-WindowsAzure-Storage-Table-CloudTable,Microsoft-Extensions-Logging-ILogger-'></a>
### TableListAll(req,cloudTable,log) `method`

##### Summary

Returns All rows from a Table.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| req | [Microsoft.AspNetCore.Http.HttpRequest](#T-Microsoft-AspNetCore-Http-HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest') |  |
| cloudTable | [Microsoft.WindowsAzure.Storage.Table.CloudTable](#T-Microsoft-WindowsAzure-Storage-Table-CloudTable 'Microsoft.WindowsAzure.Storage.Table.CloudTable') |  |
| log | [Microsoft.Extensions.Logging.ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') |  |

<a name='M-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-TableBindings-TableListByPartition-Microsoft-AspNetCore-Http-HttpRequest,Microsoft-WindowsAzure-Storage-Table-CloudTable,Microsoft-Extensions-Logging-ILogger,System-String-'></a>
### TableListByPartition(req,cloudTable,log,PartitionKey) `method`

##### Summary

Returns All rows from a Partition of a Table.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| req | [Microsoft.AspNetCore.Http.HttpRequest](#T-Microsoft-AspNetCore-Http-HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest') |  |
| cloudTable | [Microsoft.WindowsAzure.Storage.Table.CloudTable](#T-Microsoft-WindowsAzure-Storage-Table-CloudTable 'Microsoft.WindowsAzure.Storage.Table.CloudTable') |  |
| log | [Microsoft.Extensions.Logging.ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') |  |
| PartitionKey | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-TableBindingWithWrappers'></a>
## TableBindingWithWrappers `type`

##### Namespace

MarkOGDev.Microsoft.Samples.Azure.Functions.TableBindings.Demo

##### Summary

Examples of Azure Table Binding With Azure.Data.Wrappers.

<a name='M-MarkOGDev-Microsoft-Samples-Azure-Functions-TableBindings-Demo-TableBindingWithWrappers-ListAllWithWrappers-Microsoft-AspNetCore-Http-HttpRequest,Microsoft-WindowsAzure-Storage-Table-CloudTable,Microsoft-Extensions-Logging-ILogger-'></a>
### ListAllWithWrappers(req,cloudTable,log) `method`

##### Summary

Returns All data from a cloudTable
Using Azure.Data.Wrappers to

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| req | [Microsoft.AspNetCore.Http.HttpRequest](#T-Microsoft-AspNetCore-Http-HttpRequest 'Microsoft.AspNetCore.Http.HttpRequest') |  |
| cloudTable | [Microsoft.WindowsAzure.Storage.Table.CloudTable](#T-Microsoft-WindowsAzure-Storage-Table-CloudTable 'Microsoft.WindowsAzure.Storage.Table.CloudTable') |  |
| log | [Microsoft.Extensions.Logging.ILogger](#T-Microsoft-Extensions-Logging-ILogger 'Microsoft.Extensions.Logging.ILogger') |  |
