using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualHelper.EditorIntegrations;

namespace VisualHelper.Core
{

   public class BuildEventNotifier
   {

      IVsBuildEvents buildEvents_;
      IToastNotifier toastNotifier_;

      bool buildSuccesful_;
      List<string> failedProjects_;

      public BuildEventNotifier(
         IVsBuildEvents buildEvents,
         IToastNotifier toastNotifier)
      {
         buildEvents_ = buildEvents;
         toastNotifier_ = toastNotifier;
         failedProjects_ = new List<string>();

         buildEvents_.BuildStarted += BuildEvents__BuildStarted;
         buildEvents_.BuildFinished += BuildEvents_BuildFinished;

         buildEvents_.ProjectBuildFinished += BuildEvents__ProjectBuildFinished;
      }

      private void BuildEvents__ProjectBuildFinished(object sender, EventArgs e)
      {
         ProjectBuildEventArgs eventArgs = (ProjectBuildEventArgs) e;
         if (!eventArgs.BuildSuccess)
         {
            failedProjects_.Add(eventArgs.Project);
            buildSuccesful_ = false;
         }
      }

      private void BuildEvents__BuildStarted(object sender, EventArgs e)
      {
         buildSuccesful_ = true;
         failedProjects_.Clear();
      }

      private void BuildEvents_BuildFinished(object sender, EventArgs e)
      {
         if (buildSuccesful_)
         {
            toastNotifier_.ShowToast(true, "Build Finished");
         }
         else
         {
            string failedProjectsString = String.Join(", ", failedProjects_);

            string buildFailedString = "Builds Failed(" + failedProjects_.Count + "): " + failedProjectsString;

            toastNotifier_.ShowToast(false, buildFailedString);
         }

      }

   }
}
