# FSBingMapsConnect

Send Flight Simulator Plane Position to Windows Bing Maps App or Google Earth Pro

Most useful if application is running an secondary display (enable Keep FS window focused) or on another PC (enable Keep display on). See [Remote SimConnect](#using-another-pc-to-connect-to-fs) howto configure SimConnect for this.

  * [Details](#details)
  * [Installation](#installation)
  * [Settings](#settings)
  * [Crash on Startup](#crash-on-startup)
  * [Google Earth Pro support](#google-earth-pro-support)
  * [Using another PC to connect to FS](#using-another-pc-to-connect-to-fs)
  

Windows Maps:
* Windows Maps uses Bing Maps Data thus data is naturally more aligned with World in Flight Simulator. Current Position is center of the Map as placing a pin is not possible.

![image](https://github.com/baumhoto/FSBingMapsConnect/blob/main/assets/windowsmap.jpg)

Google Earth Pro:
* Google Earth Pro allows to set a pin at the current location but only supports Aerial view.
![image](https://github.com/baumhoto/FSBingMapsConnect/blob/main/assets/googleearth.jpg)


## Details

Microsoft Flight Simulator Ingame VFR Map only has limited infos. This application will retrieve the current plane position from Flight Simulator and create an bingmaps application url (https://docs.microsoft.com/en-us/windows/uwp/launch-resume/launch-maps-app) from that which will show the position in the windows maps app (usually installed on every windows 10 device, if not get it from the Microsoft Store https://www.microsoft.com/en-us/p/windows-maps/9wzdncrdtbvb?activetab=pivot:overviewtab ).

Updates can be triggered manually or automatically (update interval can be specified).

Windows Maps app should be placed on a second monitor though it will also work with only one (disable Keep FS Window Focused) to keep the Maps app in Front. It also works using another PC (see description below)

## Installation

Get latest version from releases page: https://github.com/baumhoto/FSBingMapsConnect/releases  ,download zip file and extract it. Double-Click *FSBingMapsConnect.exe*, Windows SmartScreen might give you a warning as the executable is not signed. Click on "More Info" and then on the "Run anyway".

  
## Settings

![image](https://github.com/baumhoto/FSBingMapsConnect/blob/main/assets/fsmapsconnect.jpg)

* **Connect** - Connect to FlightSimulator Session
* **Disconnect** - Disconnect from FlightSimulator Session
* **Manually Request Position** - Retrieve current positon from Flight Simulator
* Choose **Windows Maps or Google Earth Pro**
* **Automatic Request Position** - Automatically retrieve the position in the interval specified under Request Interval
* **Request Interval** - how often is the position retrieved (in seconds)
* **Send Position to Windows Maps** - should the new position be send to Windows Maps (or Google Earth Pro) - disable if you want to look around in at your current location
* **Windows maps Zoom Level** - Max Zoom Level is 20
* **Align Zoom Level to Altitude** - if enabled the Altitude Above Ground is used to set the Zoom Level.
* **Map Type** - Aerial or Road View
* **Map Pitch** - Value between 0 and 90 where 0 is Top-Down view and 90 is horizontal
* **Keep Display On** - useful if running application on another pc to prevent the display to turn off
* **Keep FS window focused** - useful if running an secondary monitor to refocus Flight Simulator Window after Map app has been updated
* **Show Values** - Display the current values in textbox below

## Crash on Startup
Install C++ redistributable from https://aka.ms/vs/16/release/vc_redist.x64.exe .

## Google Earth Pro support

Version 0.4.0 now support Google Earth Pro (get it from here: https://www.google.com/earth/download/gep/agree.html). Google Earth Pro shows a pin marker at the current location. 

Functionality provided by writing an kml (https://developers.google.com/kml/documentation/kmlreference?csw=1#top_of_page) file which is constantly updated, thus **there will be an dialog in Google Earth Pro asking about loading an modified file. Please choose "always" when this occurs.**


## Using another PC to connect to FS

SimConnect needs to be configured to connect from another PC (Windows 10 64 bit required). Depending on which version you have you'll need to go to a different location:

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
  

  

  


