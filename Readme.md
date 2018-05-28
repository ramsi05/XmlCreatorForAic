#XML Creator for AIC

Johannes Ramsebner, 26.05.2018
lun.3@ki.ooelfv.at

Program to Parse the next Google Calendar Events
to the AIC* XML-File

Make a folder were the AIC get the xml File.
In that folder save the 'Input.xml' with the pattern
In a subfolder are the files of that program
Also in the subfolder the 'client_secret.json' from google api is required**

To compile the program the google referances are required.
To get them install them with NuGet Package Manager Console in Visual Studio:
PM> Install-Package Google.Apis.Calendar.v3


* AIC=Alarm Info Center http://www.alarm-info-center.at/ 
** to get this follow the instructions from "https://developers.google.com/calendar/quickstart/dotnet" Step 1 (called on 26.05.2018)