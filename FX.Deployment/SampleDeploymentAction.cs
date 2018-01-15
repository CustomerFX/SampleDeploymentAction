using System;
using System.Linq;
using System.ComponentModel;
using System.DirectoryServices;
using System.IO;
using System.Text;
using Sage.Platform.Application;
using Sage.Platform.Data;
using Sage.Platform.WebPortal.Design;

namespace FX.Deployment
{
    public class SampleDeploymentAction : IDeploymentActionProvider
    {
        public string Name => "Sample Deployment Action Provider";
        public bool RunOnBackgroundBuilds => true;

        public IShadowCopyItem[] GetDeployableItems(PortalBase portal, BackgroundWorker worker)
        {
            // CREATE FILES TO DEPLOY TO THE TARGET FOLDER HERE 

            // if you don't want to deploy any files to the target reutrn an empty array
            // return new IShadowCopyItem[0];

            // create a memory stream with the contents of the file to write to the deployment folder 
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream, Encoding.UTF8, 0x200);
            writer.Write("DEPLOYED " + DateTime.Now + ": This is the contents of the file I am wrting out to the deployment folder");
            writer.Flush(); // flush streamwriter to the stream

            // return the array of ShadowCopyItems, you can add as many files to this array as you need 
            return new IShadowCopyItem[] { new ShadowCopyItem("_mysamplefile.txt", stream) };
        }

        public void BeforeDeployment(PortalBase application, BackgroundWorker worker)
        {
        }

        public void AfterDeployment(PortalBase application, BackgroundWorker worker, object deployment)
        {
            // log to output window 
            var log = ApplicationContext.Current.Services.Get<IOutputWindowService>().Get("default");
            log.LogInformation("INFO  - Running After Deployment action from " + Name);

            // get current connection to saleslogix database if needed 
            var dataService = ApplicationContext.Current.Services.Get<IDataService>();

            // iterate through the targets for the deployment
            foreach (var target in (deployment as Sage.Platform.Deployment.Deployment).Targets.Where(x => x.IsActive))
            {
                // locate the matching portal for this target 
                var targetPortal = target.Portals.FirstOrDefault(x => x.PortalApp.PortalAlias == application.PortalAlias);
                if (targetPortal == null) continue;

                // Now you can do whatever you need with the details for this portal deployment 

                // Deployment directory 
                var deployFolder = target.GetFolderName(targetPortal);

                // Current connection string to database 
                var connString = dataService.GetConnectionString();
            }
        }

        public void SetupDeployment(DirectoryEntry virtualDirectory, PortalBase application, BackgroundWorker worker)
        {
        }
    }
}
