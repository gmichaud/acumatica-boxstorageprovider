[![Project Status](http://opensource.box.com/badges/active.svg)](http://opensource.box.com/badges)

Box.com Storage Provider for Acumatica
======================================

A custom file storage provider for Acumatica that allow tight integration with Box.com:
* Automatically upload Acumatica’s files to your Box account
* Arrange folder structure following a customizable set of DAC fields
* Use universal search information as folder description
* Browse Box folders directly on your Acumatica website
* Modified Box .NET SDK to use www.boxenterprise.net which allows usage in China


### Prerequisites
* Acumatica 2023 R2 or later
* A Box.com account (personal or enterprise)

### Notes
* The Box integration has to be the first customization that you publish when upgrading a new instance; Acumatica stores customization projects on the external file storage provider, meaning it will not be able to publish anything else unless the Box integration is published
* Starting in 2023 R2, encryption certificates need to be configured for the site, or else the authentication process will fail.


Quick Start
-----------

### Installation
Import and publish the customization package. 

1. Go to Configuration > Document Management > Configure > External File Storage
2. Choose Box.com Storage from the Provider drop down list
3. Enter the name of the root folder found in your Box account, e.g. Acumatica, and then Save
4. Click on enable provider and then click on switch direction.

![alt text](https://github.com/Acumatica/acumatica-boxstorageprovider/blob/master/ReadMeImages/extFileStorage.png "")

 
Go into your user profile and click on the Box User Profile button

1.	Click on Log Into Box button (see Known Issues section if the popup is blank)
2.	Enter your Box.com account credentials, click Authorize and on the next screen

![alt text](https://github.com/Acumatica/acumatica-boxstorageprovider/blob/master/ReadMeImages/login.png "")

 
On success you should see a screen similar to this one :

![alt text](https://github.com/Acumatica/acumatica-boxstorageprovider/blob/master/ReadMeImages/loginSuccess.png "")
 
Go to Configuration > Document Management > Box > Folder Synchronisation and click the Process All button.

![alt text](https://github.com/Acumatica/acumatica-boxstorageprovider/blob/master/ReadMeImages/synch.png "")  
The two checkboxes are optional.  
Force Update Folders Description: Use the universal index data to set a folder description on existing box folder.
Force Rescan Folder: Force synchronisation between Box folders and screen documents even if no changes are detected.


### Screen Configuration
*Configuration > Document Management > Box > Screen Configuration*

The Screen Configuration screen is used to configure the folder hierarchy that will be used to sort files on your Box account.

1.	Choose a screen
2.	Choose the fields that will be used as levels for the Box account folder hierarchy
3.	Click Move Folders button to move existing items to the new folder hierarchy

![alt text](https://github.com/Acumatica/acumatica-boxstorageprovider/blob/master/ReadMeImages/screenConfig.png "")

## Copyright and License

Copyright © `2016` `Acumatica`

This component is licensed under the MIT License, a copy of which is available online at https://github.com/Acumatica/acumatica-boxstorageprovider/blob/master/LICENSE.md
