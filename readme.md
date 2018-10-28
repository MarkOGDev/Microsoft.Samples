# Microsoft Samples 

*Created by MarkOGDev*
 
 
## Azure Functions


* [Azure.Functions.HttpTrigger.Demo](/Azure.Functions/HttpTrigger.Demo/readme.md)
* [Azure.Functions.TableBindings.Demo](/Azure.Functions/TableBindings.Demo/readme.md)


 

## Tools 

* [Postman App](https://www.getpostman.com/) - Manually Test / View you function responses.


## Automation

* [Azure DevOps Documentation](https://docs.microsoft.com/en-us/azure/devops/)


[![Build Status](https://dev.azure.com/markogdev/Microsoft.Samples/_apis/build/status/Microsoft.Samples)](https://dev.azure.com/markogdev/Microsoft.Samples/_build/latest?definitionId=2)




* [Azure Build pipeline source repositories](https://docs.microsoft.com/en-us/azure/devops/pipelines/build/repository?view=vsts)
* [What is Azure Pipelines release service](https://docs.microsoft.com/en-us/azure/devops/pipelines/release/what-is-release-management?view=vsts)


We can deploy an individual project in this solution by createing a build in Azure portal, NOT uisng Yaml.
YAML builds don't support tagging sources (at this time Oct 2018).

Tagging sources let you point to a project to create an artifact.

Then publish the artifact to the function app.



## Second Repo
We are using Micorsoft team Services to manage our codebase, automate building and deployment.

We are alos pusshing the codebase to a second repo in Github for Public viewing. 

You can add a second Repo to your project by adding a second Remote to the Repo and pushing a Baranch to the new repo.

