# Microsoft Samples 

*Created by MarkOGDev*
 

 
## C# Azure Functions Demos

See: [Function Samples Introduction](Azure.Functions/readmeFunctionsIntro.md)
 
 
 ## Blazor Demos
 
 Coming Soon.....



 

## Azure DevOps Automation 

We are using Azure DevOps to manage our code base and achieve **Continuous Integration and Continuous Deployment**.
(i.e. automate building, testing and deployment.)

Read the following docs to learn how to set up automation:

* [Azure DevOps Documentation](https://docs.microsoft.com/en-us/azure/devops/)
* [Azure Build pipeline source repositories](https://docs.microsoft.com/en-us/azure/devops/pipelines/build/repository?view=vsts)
* [What is Azure Pipelines release service](https://docs.microsoft.com/en-us/azure/devops/pipelines/release/what-is-release-management?view=vsts)


Note: We can deploy an individual project from this solution by creating a build in Azure portal, NOT using YAML.
YAML builds don't support tagging sources (at this time Oct 2018).

Tagging Sources let you point to a project to create an artifact that will be published to the Azure function app.


### Secondary Repository

We are also pushing the code base to a second repository in **GitHub for Public Sharing**. 

You can add a Second Repository to your project by adding a Second Remote to the Repository and pushing a branch to the new remote.

 