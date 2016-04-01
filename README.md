# HomemadeEats
First try in creating an MVC5 ASP.NET app with Bootstrap and W3.CSS

Project for a cooking app


<b>INSTRUCTIONS:<b>

If you download this project, here is what will help you get through the issue with the packages.

1) Open the solution file for the Domain project first (HE.Domain.sln).  
NOTES: 
* This project contains the database TABLE DEFINITIONS and CLASSES for the HomemadeEats project.  
* These tables are custom designed tables specific to HomemadeEats app.  
* The tables are needed by the HomemadeEats app. 
* Due to Katana and ASP.NET Identity (v2.0) and its design, customizations and definitions to Identity tables were kept/left alone and done at the MVC project level (ie where Identity is employed - HE.API.sln and HE.WebApp.UserInterface - it WAS very difficult and time consuming to separate out (not decouple) the Katana and Identity stuff)

  - Build > Clean solution 
  - Build > Rebuild solution (this should trigger a Restore of the referenced packages for this project).  If doing this is STILL NOT SUFFICIENT to get rid of the errors, then go to Package Manager and after it loads, type in "Update-Package" (without the double quotes to be clear).  Doing this should update all the referenced packages a second time.  This should clear out the yellow warning triangles on the referenced package that you see in Solution Explorer > References.  At this point, I would suggest you go ahead and do ANOTHER clean (Build > Clean solution), then ANOTHER rebuild (Build > Rebuild solution).  This should clear any errors that were previously there.  I've only had to follow these steps to get through the issues I've experienced downloading this project.  If you continue having issues with referenced packages, I would suggest go over the steps another time and possibly even closing Visual Studio after you do a clean and then reopen the project solution, clean, rebuild.  Once you managed to get through the errors, you can close this solution now (ie close out visual studio).


2) Open the solution file for the API project (HE.API.sln). 
NOTES: 
* This is an MVC5 Web API project with Individual User Account. 
* This project has a REFERENCE to HE.Domain.
* This project contains the DB context and customizations to the ASP.NET Identity tables.  
* The purpose of this project is to serve somewhat as the repository for the data and every action sent to the DB is ASYNC here.
* I wanted this API to be usable across platforms and contains the functions for CREATING (ie INSERTING and ADDING) records into the database, DELETING (ie REMOVING) records from the database, and UPDATING (ie EDITING) records on the database.  
* Basically, any action that is related to working with the database SHOULD & MUST go through this API.

  - Build > Clean solution 
  - Build > Rebuild solution (this should trigger a Restore of the referenced packages for this project).  If doing this is STILL NOT SUFFICIENT to get rid of the errors, then go to Package Manager and after it loads, type in "Update-Package" (without the double quotes to be clear).  Doing this should update all the referenced packages a second time.  This should clear out the yellow warning triangles on the referenced package that you see in Solution Explorer > References.   At this point, I would suggest you go ahead and do ANOTHER clean (Build > Clean solution), then ANOTHER rebuild (Build > Rebuild solution).  This should clear any errors that were previously there.  I've only had to follow these steps to get through the issues I've experienced downloading this project.  If you continue having issues with referenced packages, I would suggest go over the steps another time and possibly even closing Visual Studio after you do a clean and then reopen the project solution, clean, rebuild.  Once you managed to get through the errors, you can close this solution now (ie close out visual studio).
  - If you run into problems with the REFERENCE to HE.Domain: remove this reference and readd it (Under Solution Explorer >  References > Right click the reference > Remove.  I know of two ways to readd the reference.  OPTION 1 is to include the project in the solution: Under Solution Explorer > Right click the top level solution > Add > Existing Project > browse to the file "HE.Domain.csproj" and click OPEN button and the reference should be added immediately after that.  OPTION 2 is to point to the pre-built "HE.Domain.dll": Under Solution Explorer > Right click References > Add Reference... > click Browse on the left of the Reference Manager window > locate the file "HE.Domain.dll" which is usually found in bin/Debug or bin/Release or obj/Debug or obj/Release depending on your settings in Visual Studio when you built the Domain project.). NOTE that the dll file is actually created by you building the project in Visual Studio - if you don't see the dll, you may need to open that particular project in Visual Studio separately and build the project to generate the dll.  The dll file SHOULD already be there because of step 1.


3) Open the solution file for the API project (HE.WebApp.UserInterface). 
NOTES: 
* This is an MVC5 project with Individual User Account.  
* This project has a REFERENCE to HE.API & HE.Domain. Although no direct access to the db is needed here or done in this project, the reference to HE.Domain is added here for convenience sake.
* The purpose of this project is to serve as the user interface part of the HomemadeEats app
* The controllers here will be making ASYNC calls to the api in step 2 to CUD data (CREATE, UPDATE, DELETE). 

  - Build > Clean solution 
  - Build > Rebuild solution (this should trigger a Restore of the referenced packages for this project).  If doing this is STILL NOT SUFFICIENT to get rid of the errors, then go to Package Manager and after it loads, type in "Update-Package" (without the double quotes to be clear).  Doing this should update all the referenced packages a second time.  This should clear out the yellow warning triangles on the referenced package that you see in Solution Explorer > References.   At this point, I would suggest you go ahead and do ANOTHER clean (Build > Clean solution), then ANOTHER rebuild (Build > Rebuild solution).  This should clear any errors that were previously there.  I've only had to follow these steps to get through the issues I've experienced downloading this project.  If you continue having issues with referenced packages, I would suggest go over the steps another time and possibly even closing Visual Studio after you do a clean and then reopen the project solution, clean, rebuild.  
  - If you run into problems with the REFERENCE to HE.Domain and/or HE.API: remove the reference and readd it (Under Solution Explorer >  References > Right click the reference > Remove.  I know of two ways to readd the reference.  OPTION 1 is to include the project in the solution: Under Solution Explorer > Right click the top level solution > Add > Existing Project > browse to the file (ex "HE.Domain.csproj") and click OPEN button and the reference should be added immediately after that.  OPTION 2 is to point to the pre-built dll file (ex "HE.Domain.dll"): Under Solution Explorer > Right click References > Add Reference... > click Browse on the left of the Reference Manager window > locate the file (ex "HE.Domain.dll") which is usually found in bin/Debug or bin/Release or obj/Debug or obj/Release depending on your settings in Visual Studio when you built the project.). NOTE that the dll file is actually created by you building the project in Visual Studio - if you don't see the dll, you may need to open that particular project in Visual Studio separately and build the project to generate the dll.  The dll file SHOULD already be there due to the previous steps in this instruction.


4) Once steps 1-3 are successfully done, you should be able to successfully RUN this app on a browser (IE, Firefox, Chrome).

The app allows external logins for Google and Facebook so far which is the RECOMMENDED way to log in to the app.  
This app is a work in progress with functionality added as progress is made.
