# SearchFight 
Console application that will query against implemented search engines and will get the results for all the terms, the winners by search engine and the grand winner.

## Usage
To use the console application, you need to compile it and to execute it sending the terms you want to look for. Are also allowed term with spaces (I.E: “java script”),  it receives a variable amount of words.
```
C:\SearchFight.exe .net .java
```

```
.net: Google: 4450000000 MSN Search: 12354420
java: Google: 966000000 MSN Search: 94381485
Google winner: .net
MSN Search winner: java
Total winner: .net
```
## Pre-requisites
Search Fight implements Google and Bing Search Engines, you must need the following:

* .Net Core 3.1
* Google API Key
* Google Custom Context Id
* Bing Search Engine Key

Once you have them, you must update them in the "appsettings.json" file. 
You will need the following: 
```
For testing purposes, you can use the following:
 	"Google.ApiKey": "AIzaSyD8i_0vBC8K-fc6nRWRqRP0UWHNa-YGHiM"
	"Google.ContextId": "013098496966806547910:t4zxl8xktv4"
    "Bing.ApiKey": "50ea1b9873464984bd7d2fe280cba22f"

```
```
{
	"SearchEngineSettings": {
    	"Google.BaseUrl": "https://www.googleapis.com/customsearch/v1?key={Key}&cx={ContextId}&q={Query}",
    	"Google.ApiKey": "ADD_YOUR_GOOGLE_API_KEY_HERE",
    	"Google.ContextId": "ADD_YOUR_GOOGLE_CONTEXT_ID_HERE",
    	"Bing.BaseUrl": "https://api.cognitive.microsoft.com/bing/v7.0/search?q={Query}",
    	"Bing.ApiKey": "ADD_YOUR_BING_API_KEY_HERE"
  }
}
```

## Deployment
Compile the solution with visual studio or .Net Core CLI.

## Adding functionality

* You can add another Search Engine, creating a new class that implements the ISearchEngine interface.
* You can add another Report Engine creating a new class that implements the IReportEngine interface.
