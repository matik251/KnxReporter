<img src="https://raw.githubusercontent.com/matik251/KnxReporter/1b42b192d3ba113a5c9670cc32f4d2f33556d770/KnxReporter/wwwroot/Images/icon_app_knx.svg" width="40px" height="auto" align="right" >

# KnxManager General info
 KnxReporter is a web PWA client for system management of Data Extraction System from Intelligent Building with KNX.
## Table of contents
- [KnxManager General info](#knxmanager-general-info)
  - [Table of contents](#table-of-contents)
  - [Technologies](#technologies)
  - [Features](#features)
  - [KNX Data XML file scheme](#knx-data-xml-file-scheme)
  - [Installation](#installation)
	
## Technologies
Project is created with:
* .NET 5
* Bl@zor Webassembly
	
## Features
Website allows user to manage all features of Data Extraction System from Intelligent Building with KNX. 

## KNX Data XML file scheme
Website supports uploading and processing multiple xml files with scheme given below: 
```
<CommunicationLog xmlns="http://knx.org/xml/telegrams/01">
<!-- timezone offset +01:00 hour -->
  <Telegram Timestamp="YYYY-MM-DDTHH:mm:ss.xxxx" Service="service" FrameFormat="CommonEmi" RawData="HexadecimalData" />
  ...
  </CommunicationLog>
```

## Installation