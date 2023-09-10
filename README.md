# Practice Management Project

## Description

The Practice Management Project is a PracticePanther knockoff application developed 
using the C# programming language and the .Net framework. This system is designed to facilitate seamless 
operations and interactions between various entities such as Clients, Projects, Bills, Times, and Employees, 
unified under a user-friendly interface.

## Features

Upon initialization, the system prompts the user to configure their working shift timings if identified as an 
employee, granting them access to the expansive client database thereafter. The primary interface
serves as a portal where users can perform various CRUD (Create, Read, Update, Delete) operations 
on client data. Furthermore, the ClientView module also provides a streamlined view of specific project details 
and billing information pertaining to individual clients.

Structured with a tiered data hierarchy, the application allows users to navigate from client profiles to detailed 
project and billing interfaces. Through a meticulously designed workflow, a bill is inherently associated with a 
specific project, which in turn is uniquely linked to a singular client, thereby maintaining a strict one-to-many 
relationship hierarchy and ensuring data integrity.

When interacting with a project entity, users have the ability to modify project details or append billing information 
to it. The billing component is equipped with a time tracking feature, which, when activated, dynamically calculates 
the total amount due based on the specified billing rate, thus automating the invoicing process.

At the core of the system is a robust API service hosted locally, providing smooth interactions with the backend 
database. This backend is designed to efficiently manage and store data utilizing JSON files, ensuring quick retrieval 
and update operations.

## Run and Test the Database

To run the program, install Visual Studio (VS) Community as the primary development environment. Before initiating the project, 
the ensure the following packages are installed.

ASP.NET and Web Development
Node.js Development
Mobile Development for .NET
.NET Desktop Development
Universal Windows Platform Development
Data Storage and Processing

Furthermore, configure the server settings to align the new host and port in the WebRequestHandler.cs file.


<h3 align="left">Languages and Tools:</h3>
<p align="left"> <a href="https://developer.android.com" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/android/android-original-wordmark.svg" alt="android" width="40" height="40"/> </a> <a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> </a> <a href="https://dotnet.microsoft.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="40" height="40"/> </a> <a href="https://git-scm.com/" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/git-scm/git-scm-icon.svg" alt="git" width="40" height="40"/> </a> <a href="https://www.java.com" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/java/java-original.svg" alt="java" width="40" height="40"/> </a> <a href="https://nodejs.org" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/nodejs/nodejs-original-wordmark.svg" alt="nodejs" width="40" height="40"/> </a> <a href="https://www.sqlite.org/" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/sqlite/sqlite-icon.svg" alt="sqlite" width="40" height="40"/> </a> </p>

