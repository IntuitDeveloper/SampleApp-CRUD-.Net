# SampleApp-CRUD-.Net for Oauth1 apps
CRUD sample for V3 .Net SDK (This sample app has NO UI. Please run it in debug mode after enabling logging on Test class to understand how the api calls are made.)


<p>Welcome to the Intuit Developer's .Net Sample App for CRUD operations.</p>
<p>This sample app is meant to provide working examples of how to integrate your app with the Intuit Small Business ecosystem. Specifically, this sample application demonstrates the following:</p>

<ul>
	<li>Create, Read, Query, Update, Delete, Void entities.</li>
	<li>All operations are performed using QuickBooks .Net V3 SDK.</li>
</ul>

<p>Please note that while these examples work, features not called out above are not intended to be taken and used in production business applications. In other words, this is not a seed project to be taken cart blanche and deployed to your production environment.</p>  

<p>For example, certain concerns are not addressed at all in our samples (e.g. security, privacy, scalability). In our sample apps, we strive to strike a balance between clarity, maintainability, and performance where we can. However, clarity is ultimately the most important quality in a sample app.</p>

<p>Therefore there are certain instances where we might forgo a more complicated implementation (e.g. caching a frequently used value, robust error handling, more generic domain model structure) in favor of code that is easier to read. In that light, we welcome any feedback that makes our samples apps easier to learn from.</p>

## Table of Contents

* [Requirements](#requirements)
* [First Use Instructions](#first-use-instructions)
* [Running the code](#running-the-code)



## Requirements

In order to successfully run this sample app you need a few things:

1. .Net Framework 4.6.1
2. A [developer.intuit.com](http://developer.intuit.com) account
3. An app on [developer.intuit.com](http://developer.intuit.com) and the associated app token, consumer key, and consumer secret.
4. One sandbox company, connect the company with your app and generate the oauth tokens.
5. Refresh QuickBooks .Net SDK using Nuget (https://www.nuget.org/packages/IppDotNetSdkForQuickBooksApiV3/)

## First Use Instructions

1. Clone the GitHub repo to your computer
2. Update Nuget Package for .Net to the latest version.
4. Fill in the web.config file values (app token, consumer key, consumer secret) by copying over from the keys section for your app.
5. Fill in the web.config file values (realmId, access token key, access token secret) with the oauth tokens generated while connecting with the company using any of the Oauth sample apps we have or by going to the Oauth playground. Go to your app->Click Test Connect to Oauth->Intuit Anywhere tab->Set time duration in seconds for 180 days and get the access token and secret for your app and company by right clicking on the page and doing a view source. 
6. Build and run.



## Running the code

This app is directed to provide individual sample code for CRUD operations for various QBO entities.
Set TestQBOAPICalls.aspx as start page and run.

Notes: 

1. The sample code has been implemented for US locale company, certain fields may not be applicable for other locales or minor version. Care should be taken to handle such scenarios separately.
2. Before running AttachableUpload sample, update the path of the pdf that you wish to upload to point to your local directory. 



