using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualHelperPackage.EditorIntegrations
{
   public class VsServices
   {

      public bool InitializeServices(
         IServiceProvider serviceProvider)
      {
         bool status = false;

         EnvDte = serviceProvider.GetService(typeof(DTE)) as DTE;


         VSBuildEvents = EnvDte.Events.BuildEvents;

         status =
            (EnvDte != null);// &&
            //(buildStatusCallback_ != null);

         if(!status)
         {
            System.Console.WriteLine(
               "ERROR: Unable to acquire visual studio services required");
         }
         else
         {
            System.Console.WriteLine("Successfully acquired visual studio services.");

         }

         return status;
      }

      public DTE EnvDte { get; private set; }

      public BuildEvents VSBuildEvents { get; private set; }
   }
}
