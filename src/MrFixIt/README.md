# "Mr. Fixit" An exercise in C# and the ASP.Net framework

#### _Mr. Fixit_, 05.05.2017

### By _Sam Kirsch_

## Description

#### A simple website built to allow the crowdsourcing of simple fix-it tasks. Users can add jobs they want done, and check the status of existing jobs. Registered workers can add jobs to their queue and mark jobs as active or done.

## Specifications

* Visitors may register as users and create accounts
* Visitors may add jobs to the job list
* Visitors may check status of existing jobs
* Users may sign up to be workers and thus queue jobs for themselves
* Workers may mark which jobs they are actively working on
* Workers may mark jobs complete

#### Stretch Goals

* Increase usability and depth of functionality by creating User roles
* Rework database structure to create more efficient representations

## Setup
>Requirements: Microsoft Visual Studio 2017
* Clone this repository
* Open the solution in visual studio 2017
* In the directory MrFixIt-dotnet run the command dotnet restore
* In the directory MrFixIt-dotnet>src>MrFixIt run the command dotnet ef database update Initial
* Click the "run" green arrow in Microsoft visual studio - you will automatically be redirected to the home page

### Technologies Used

* HTML and CSS
* C# with ASP.Net
* MSSQL database manager

[github link for this project](https://github.com/denalisk/MrFixIt-dotnet)

##### Copyright (c) 2017 Sam Kirsch.

##### Licensed under the MIT license.
