# HomemadeEats
<b>First try</b> in creating an <b>MVC5 ASP.NET</b> app with <b>Bootstrap</b> and <b>W3.CSS</b>


Project for a cooking app


<b>INSTRUCTIONS:</b>

If you download this project, here is what will help you get through the issue with the packages.
<br/>
<br/>

<b>1)</b> Open the solution file for the Domain project first (HE.Domain.sln).  
[  <b>NOTES:</b> 
* This project contains the database <b>TABLE DEFINITIONS</b> and <b>CLASSES</b> for the HomemadeEats project.  <br/><br/>
* These tables are custom designed tables specific to HomemadeEats app.  <br/><br/>
* The tables are needed by the HomemadeEats app. <br/><br/>
* Due to Katana and ASP.NET Identity (v2.0) and its design, customizations and definitions to Identity tables were kept/left alone and done at the MVC project level (ie where Identity is employed - HE.API.sln and HE.WebApp.UserInterface - it WAS very difficult and time consuming to separate out (not decouple) the Katana and Identity stuff)  ]
<br/><br/>
- Build > Clean solution <br/><br/>
- Build > Rebuild solution (this should trigger a Restore of the referenced packages for this project).  If doing this is <b>STILL NOT SUFFICIENT</b> to get rid of the errors, then go to Package Manager and after it loads, type in "Update-Package" (without the double quotes to be clear).  Doing this should update all the referenced packages a second time.  This should clear out the yellow warning triangles on the referenced package that you see in Solution Explorer > References.  At this point, I would suggest you go ahead and do <b>ANOTHER</b> clean (Build > Clean solution), then <b>ANOTHER</b> rebuild (Build > Rebuild solution).  This should clear any errors that were previously there.  I've only had to follow these steps to get through the issues I've experienced downloading this project.  If you continue having issues with referenced packages, I would suggest go over the steps another time and possibly even closing Visual Studio after you do a clean and then reopen the project solution, clean, rebuild.  Once you managed to get through the errors, you can close this solution now (ie close out visual studio).

<br/>
<br/>
<br/>
<br/>

<b>2)</b> Open the solution file for the API project (HE.API.sln). <br/><br/>
[  <b>NOTES:</b> 
* This is an MVC5 Web API project with Individual User Account. <br/><br/>
* This project has a <b>REFERENCE</b> to HE.Domain. <br/><br/>
* This project contains the DB context and customizations to the ASP.NET Identity tables.  <br/><br/>
* The purpose of this project is to serve somewhat as the repository for the data and every action sent to the DB is <b>ASYNC</b> here. <br/><br/>
* I wanted this API to be usable across platforms and contains the functions for <b>CREATING (ie INSERTING and ADDING)</b> records into the database, <b>DELETING (ie REMOVING)</b> records from the database, and <b>UPDATING (ie EDITING)</b> records on the database. <br/><br/>
* Basically, any action that is related to working with the database <b>SHOULD & MUST</b> go through this API.  ] <br/><br/>
- Build > Clean solution <br/><br/>
- Build > Rebuild solution (this should trigger a Restore of the referenced packages for this project).  If doing this is <b>STILL NOT SUFFICIENT</b> to get rid of the errors, then go to Package Manager and after it loads, type in "Update-Package" (without the double quotes to be clear).  Doing this should update all the referenced packages a second time.  This should clear out the yellow warning triangles on the referenced package that you see in Solution Explorer > References.   At this point, I would suggest you go ahead and do <b>ANOTHER</b> clean (Build > Clean solution), then <b>ANOTHER</b> rebuild (Build > Rebuild solution).  This should clear any errors that were previously there.  I've only had to follow these steps to get through the issues I've experienced downloading this project.  If you continue having issues with referenced packages, I would suggest go over the steps another time and possibly even closing Visual Studio after you do a clean and then reopen the project solution, clean, rebuild.  Once you managed to get through the errors, you can close this solution now (ie close out visual studio). <br/><br/>
- If you run into problems with the <b>REFERENCE</b> to HE.Domain: remove this reference and readd it (Under Solution Explorer >  References > Right click the reference > Remove.  I know of two ways to readd the reference.  <b>OPTION 1</b> is to include the project in the solution: Under Solution Explorer > Right click the top level solution > Add > Existing Project > browse to the file "HE.Domain.csproj" and click OPEN button and the reference should be added immediately after that.  <b>OPTION 2</b> is to point to the pre-built "HE.Domain.dll": Under Solution Explorer > Right click References > Add Reference... > click Browse on the left of the Reference Manager window > locate the file "HE.Domain.dll" which is usually found in bin/Debug or bin/Release or obj/Debug or obj/Release depending on your settings in Visual Studio when you built the Domain project.). <b>NOTE</b> that the dll file is actually created by you building the project in Visual Studio - if you don't see the dll, you may need to open that particular project in Visual Studio separately and build the project to generate the dll.  The dll file <b>SHOULD</b> already be there because of step 1.

<br/>
<br/>
<br/>
<br/>
<b>3)</b> Open the solution file for the API project (HE.WebApp.UserInterface). <br/><br/>
[  <b>NOTES:</b> 
* This is an MVC5 project with Individual User Account.  <br/><br/>
* This project has a <b>REFERENCE</b> to HE.API & HE.Domain. Although no direct access to the db is needed here or done in this project, the reference to HE.Domain is added here for convenience sake. <br/><br/>
* The purpose of this project is to serve as the user interface part of the HomemadeEats app <br/><br/>
* The controllers here will be making <b>ASYNC</b> calls to the api in step 2 to <b>CUD data (CREATE, UPDATE, DELETE).</b>  ] <br/><br/>
- Build > Clean solution <br/><br/>
- Build > Rebuild solution (this should trigger a Restore of the referenced packages for this project).  If doing this is <b>STILL NOT SUFFICIENT</b> to get rid of the errors, then go to Package Manager and after it loads, type in "Update-Package" (without the double quotes to be clear).  Doing this should update all the referenced packages a second time.  This should clear out the yellow warning triangles on the referenced package that you see in Solution Explorer > References.   At this point, I would suggest you go ahead and do <b>ANOTHER</b> clean (Build > Clean solution), then <b>ANOTHER</b> rebuild (Build > Rebuild solution).  This should clear any errors that were previously there.  I've only had to follow these steps to get through the issues I've experienced downloading this project.  If you continue having issues with referenced packages, I would suggest go over the steps another time and possibly even closing Visual Studio after you do a clean and then reopen the project solution, clean, rebuild.  <br/><br/>
- If you run into problems with the <b>REFERENCE</b> to HE.Domain and/or HE.API: remove the reference and readd it (Under Solution Explorer >  References > Right click the reference > Remove.  I know of two ways to readd the reference.  <b>OPTION 1</b> is to include the project in the solution: Under Solution Explorer > Right click the top level solution > Add > Existing Project > browse to the file (ex "HE.Domain.csproj") and click OPEN button and the reference should be added immediately after that.  <b>OPTION 2</b> is to point to the pre-built dll file (ex "HE.Domain.dll"): Under Solution Explorer > Right click References > Add Reference... > click Browse on the left of the Reference Manager window > locate the file (ex "HE.Domain.dll") which is usually found in bin/Debug or bin/Release or obj/Debug or obj/Release depending on your settings in Visual Studio when you built the project.). <b>NOTE</b> that the dll file is actually created by you building the project in Visual Studio - if you don't see the dll, you may need to open that particular project in Visual Studio separately and build the project to generate the dll.  The dll file <b>SHOULD</b> already be there due to the previous steps in this instruction. <br/><br/>
<br/>
<br/>
<br/>
<b>4)</b> Once steps 1-3 are successfully done, you should be able to successfully <b>RUN</b> this app on a browser (IE, Firefox, Chrome).
<br/>
<br/>

The app allows external logins for Google and Facebook so far which is the <b>RECOMMENDED</b> way to log in to the app.  
This app is a work in progress with functionality added as progress is made.
