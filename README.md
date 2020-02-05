# Power Apps & Azure Lab

<!-- 
Guidelines on README format: https://review.docs.microsoft.com/help/onboard/admin/samples/concepts/readme-template?branch=master

Guidance on onboarding samples to docs.microsoft.com/samples: https://review.docs.microsoft.com/help/onboard/admin/samples/process/onboarding?branch=master

Taxonomies for products and languages: https://review.docs.microsoft.com/new-hope/information-architecture/metadata/taxonomies?branch=master
-->
This repository contains a source code for an API App and a lab manual for demonstrating a simple example for integrating Power Apps Canvas apps with an API app hosted on an Azure Web App using a custom-connector. This scenario can be used to unlock the potential of untapped assets within an enterprise (legacy APIs, data sources, processes etc..)

## Lab Overview & Objective

### Overview

Most enterprises have a majority of their core business data trapped in several silos (legacy databases & apps - Systems of Records). It is essential for digital transformation to break those data silos and make the information trapped in those systems available to employees and business teams as needed.  

It is also important to modernize the user experience of the enterprise apps in order to drive productivity.  

[Microsoft Power Apps](https://docs.microsoft.com/en-us/powerapps/powerapps-overview) along with [Azure](https://docs.microsoft.com/en-us/azure/guides/developer/azure-developer-guide) could be an effective way to bridge this gap, by enabling an RESTful API layer powered by Azure which could encapsulate and standardize the enterprise data for use with apps + Power Apps as the rapid application development User interface where business apps can be built with agility and in collaboration with the business.

### Objectives

This lab has two key objectives:
- To demonstrate how Power Apps platform can help unlock the potential of untapped assets within an Enterprise ( legacy APIs, data sources, processes) with a low-code / no code approach.  
- Learn to create a cross-platform application user experience using Microsoft Power Apps to consume these RESTful APIs through custom connectors
- `[Optional/Bonus Lab]` Learn how to enable Application Lifecycle Management (ALM) and setup Azure DevOps for the application  

## Prerequisites

The lab requires: 
- Visual Studio 2017 or 2019 to compile the code and publish to Azure
- Access to an Azure Subscription to create an API app to serve as the RESTful API
- Access to a Power Apps environment with Maker permission to create apps and custom connectors

## Lab Manual

Refer to the [Lab Document](https://github.com/microsoft/PowerApps-Azure-Lab/blob/master/Lab%20Resources/Hands-on%20with%20PowerApps%20and%20Azure-Lab%20Document.pdf) for the step-by-step guidance for this lab.

## Key concepts

- [Microsoft Power Apps](https://docs.microsoft.com/en-us/powerapps/powerapps-overview)
- [Custom Connectors](https://docs.microsoft.com/en-us/connectors/custom-connectors/)
- [ALM for Power Apps](https://docs.microsoft.com/en-us/power-platform/admin/automate-alm)

## Contents

| File/folder       | Description                                |
|-------------------|--------------------------------------------|
| `Lab Resources`   | Lab Resources including Lab Manual.        |
| `src`             | Source code for the API App.               |
| `README.md`       | This README file.                          |
| `LICENSE`         | The license for the lab.                |


## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
