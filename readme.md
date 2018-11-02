# Microsoft Samples 

*Created by MarkOGDev*


 
## C# Azure Functions

Azure Functions is a serverless compute service. 

See: [Function Samples Introduction](Azure.Functions/readmeFunctionsIntro.md)
 
 
## Blazor
 
 Blazor is an experimental .NET web framework using C# and HTML that runs in the browser.

 More Coming Soon.....


## Service Fabric

 Azure Service Fabric is a distributed systems platform for deploying and managing scalable and reliable microservices and containers.

 More Coming Soon.....
 



## Azure DevOps Automation 

We are using Azure DevOps to manage our code base and achieve **Continuous Integration and Continuous Deployment**.
(i.e. automate building, testing and deployment.)

Setting up your first Build and Release it can take a bit of time to find all the correct settings. Give yourself plenty of time and experiment a bit. 

Read the following docs to learn how to set up automation:

* [Azure DevOps Documentation](https://docs.microsoft.com/en-us/azure/devops/)
* [Azure Build pipeline source repositories](https://docs.microsoft.com/en-us/azure/devops/pipelines/build/repository?view=vsts)
* [What is Azure Pipelines release service](https://docs.microsoft.com/en-us/azure/devops/pipelines/release/what-is-release-management?view=vsts)


Note: We can deploy an individual project from this solution by creating a build in Azure portal, NOT using YAML.
YAML builds don't support tagging sources (at this time Oct 2018).

Tagging Sources let you point to an individual project in a solution. This will create an artifact. The artifact is your compiled project ready for publishing. Therefore you can create many artifacts from one solution and have each one published to a different location.


### Secondary Repository

We are also pushing the code base to a second repository in **GitHub for Public Sharing**. 

You can add a Second Repository to your project by adding a Second Remote to the Repository and pushing a branch to the new remote.

 