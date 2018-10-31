# Microsoft Samples 

*Created by MarkOGDev*
 
 
## Azure Functions Demos

* [Function Samples Introduction](Docs/functionsIntroductionReadme.md)
* [Azure.Functions.HttpTrigger.Demo Project](Azure.Functions/HttpTrigger.Demo/readme.md)
  [![Build Status](https://markogdev.visualstudio.com/Microsoft.Samples/_apis/build/status/Azure.Functions.HttpTrigger.Demo)](https://markogdev.visualstudio.com/Microsoft.Samples/_build/latest?definitionId=3)
* [Azure.Functions.TableBindings.Demo Project](Azure.Functions/TableBindings.Demo/readme.md)
  [![Build Status](https://markogdev.visualstudio.com/Microsoft.Samples/_apis/build/status/Azure.Functions.TableBindings.Demo)](https://markogdev.visualstudio.com/Microsoft.Samples/_build/latest?definitionId=4)

 
 ## Blazor Demos
 
 Comming Soon.....





## Azure Devops Automation 

We are using Azure Devops to manage our codebase and achieve **Continuous Integration and Continuous Deployment**.
(i.e. automate building, testing and deployment.)

* [Azure DevOps Documentation](https://docs.microsoft.com/en-us/azure/devops/)
* [Azure Build pipeline source repositories](https://docs.microsoft.com/en-us/azure/devops/pipelines/build/repository?view=vsts)
* [What is Azure Pipelines release service](https://docs.microsoft.com/en-us/azure/devops/pipelines/release/what-is-release-management?view=vsts)


We can deploy an individual project from this solution by createing a build in Azure portal, NOT uisng Yaml.
YAML builds don't support tagging sources (at this time Oct 2018).

Tagging Sources let you point to a project to create an artifact that will be published to the Azure function app.


### Second Repo

We are also pushing the codebase to a second repo in **Github for Public Sharing**. 

You can add a Second Repo to your project by adding a Second Remote to the Repo and pushing a branch to the new remote.

