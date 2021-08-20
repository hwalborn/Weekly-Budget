## Holts Weekly Budget Transfer

#### About
This is a .net core command line app to copy over some data and make a fresh weekly budget sheet. It should read the weekly budget sheet (hopefully programmatically), copy the necessary values onto the anual budget, make a copy of the weekly budget template named for the upcoming week, copy over the final values from this week, copy over the budgeted values from the annual, and save it in the appropriate yearly details folder.

#### Untracked Files
There is one untracked file: `google-credentials.json` that is the json output from the key here `https://console.developers.google.com/`...

I'm also following along with this tutorial, just to get my bearings on reading/writing to google sheets: https://medium.com/@semuserable/net-core-google-sheets-api-read-write-5edd919868e3

#### TODO:
* Learn how to write
* Learn how to query for specific sheets
* structure the dates/names of files
* write the whole app