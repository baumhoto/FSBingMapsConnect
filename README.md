# FSBingMapsConnect
Send Flight Simulator Plane Position to Windows Bing Maps App

Microsoft Flight Simulator Ingame VFR Map only has limited infos. This application will retrieve the current plane position from Flight Simulator and create an bingmaps application url (https://docs.microsoft.com/en-us/windows/uwp/launch-resume/launch-maps-app) from that which will show the position in the windows maps app (usually installed on every windows 10 device, if not get it from the Microsoft Store https://www.microsoft.com/en-us/p/windows-maps/9wzdncrdtbvb?activetab=pivot:overviewtab ).

Updates can be triggered manually or automatically (update interval can be specified).

Windows Maps app should be placed on a second monitor though it will also work with only one (disable Keep FS Window Focused) to keep the Maps app in Front. It also works using another PC (see description below)

## Crash on Startup
Install C++ redistributable from https://aka.ms/vs/16/release/vc_redist.x64.exe or use  winget install Microsoft.VC++2015-2019Redist-x64  .


## Google Earth Pro support

Version 0.4.0 now support Google Earth Pro (get it from here: https://www.google.com/earth/download/gep/agree.html). Google Earth Pro shows a pin marker at the current location. 

Functionality provided by writing an kml (https://developers.google.com/kml/documentation/kmlreference?csw=1#top_of_page) file which is constantly updated, thus **there will be an dialog in Google Earth Pro asking about loading an modified file. Please choose "always" when this occurs.**


## Using another PC to connect to FS
SimConnect needs to be configured to connect from another PC. Depending on which version you have you'll need to go to a different location:

MS Store / XBox GamePass Version:
 ``` 
%LOCALAPPDATA%\Packages\Microsoft.FlightSimulator_8wekyb3d8bbwe\LocalCache
 ``` 
Steam Version:
 ``` 
%APPDATA%\Microsoft Flight Simulator
 ``` 

Open the SimConnect.xml file and add the following right after `<Filename>SimConnect.xml</Filename>` :
```xml
<SimConnect.Comm>
    <Disabled>False</Disabled>
    <Protocol>IPv4</Protocol>
    <Scope>global</Scope>
    <Address>YOUR_IP_ADDRESS_HERE</Address>
    <MaxClients>64</MaxClients>
    <Port>YOUR_PORT_HERE</Port>
    <MaxRecvSize>4096</MaxRecvSize>
    <DisableNagle>False</DisableNagle>
  </SimConnect.Comm>
```
  
  Replace the YOUR_IP_ADDRESS_HERE with the IP of your PC on which FS will be executed. Also choose a PORT. Should look like this afterwards

```xml
.....
    <Descr>SimConnect Server Configuration</Descr>
    <Filename>SimConnect.xml</Filename>
 <SimConnect.Comm>
    <Disabled>False</Disabled>
    <Protocol>IPv4</Protocol>
    <Scope>global</Scope>
    <Address>192.168.1.32</Address>
    <MaxClients>64</MaxClients>
    <Port>4201</Port>
    <MaxRecvSize>4096</MaxRecvSize>
    <DisableNagle>False</DisableNagle>
  </SimConnect.Comm>
    <SimConnect.Comm>
        <Descr>Static IP4 port</Descr>
        <Protocol>IPv4</Protocol>
        <Scope>local</Scope>
        <Port>500</Port>
        <MaxClients>64</MaxClients>
        <MaxRecvSize>41088</MaxRecvSize>
    </SimConnect.Comm>
    <SimConnect.Comm>
  ..........
 ``` 
  
  On the PC that will run FSBingMapsConnect open the folder containing the program and edit the SimConnect.cfg replace

 ``` 
; new FS pipe
[SimConnect]
Protocol=Pipe
Port=Custom/SimConnect
Address=127.0.0.1
 ``` 

with
``` 
; new FS pipe
[SimConnect]
Protocol=IPv4
Port=YOUR_PORT_HERE
Address=YOUR_IP_ADDRESS_HERE
``` 

Use the same IP Address and Port as on the SimConnect.xml above.
  
 
Now FSBingMaps should be able connect to FS running on the remote PC.
  
  
  
  
  


