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
