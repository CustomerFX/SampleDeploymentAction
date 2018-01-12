# SampleDeploymentAction
*A sample project showing how to create a custom deployment action provider for Application Architect*

This project shows a fully working sample to create custom deployment step for Application Architect. This allows you to create custom actions for deployments where you can write files to the deployment folder, create connections to teh Saleslogix database, etc. 

**To Use This Sample:**

1. Build the project in Visual Studio
2. Copy the DLL to the C:\Program Files (x86)\Saleslogix\Platform folder 
3. Restart Application Architect 
4. In Application Architect, expand the Portal Manager and the select the portal you want to add this to, such as the SlxClient portal
5. In the Properties grid with the SlxClient portal selected, you'll see a property for DeploymentActionTypes. Click that to bring up the editor
6. Add your new assebmbly to the list
7. Deploy and the code will execute as a part of the deployment 
 
 
**To Create Your Own Deployment Action Provider**

1. Create a new Class Library project in VS, set the framework version to .NET 4.5.2
2. Add a reference to Sage.Platform.WebPortal.Design.dll in C:\Program Files (x86)\Saleslogix\Platform
3. Add a reference to Sage.Platform.Deployment.dll in C:\Program Files (x86)\Saleslogix\Platform
4. Add a reference to Sage.Platform.Projects.dll in C:\Program Files (x86)\Saleslogix\Platform
5. Add a reference to Sage.Platform.Application.dll in C:\Program Files (x86)\Saleslogix\Platform
6. Add a new class to your project that implements the interface Sage.Platform.WebPortal.Design.IDeploymentActionProvider
7. For the GetDeployableItems method, you can just add `return new IShadowCopyItem[0];` if you don't want to deploy any new files
8. Copy the assembly to C:\Program Files (x86)\Saleslogix\Platform
9. Restart Application Architect
10. In Application Architect, expand the Portal Manager and the select the portal you want to add this to, such as the SlxClient portal
11. In the Properties grid with the SlxClient portal selected, you'll see a property for DeploymentActionTypes. Click that to bring up the editor
12. Add your new assebmbly to the list
13. Deploy and your code will execute
