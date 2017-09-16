using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualHelper.EditorIntegrations;

namespace VisualHelper.BuildIntegration
{

   public class BuildEventNotifier
   {

      IVsBuildEvents buildEvents_;
      IToastNotifier toastNotifier_;
      IBuildFailedFormatter buildFailedFormatter_;
      BuildState buildState_;

      public BuildEventNotifier(
         IVsBuildEvents buildEvents,
         IToastNotifier toastNotifier,
         IBuildFailedFormatter buildFailedFormatter,
         BuildState buildState)
      {
         buildEvents_ = buildEvents;
         toastNotifier_ = toastNotifier;
         buildFailedFormatter_ = buildFailedFormatter;
         buildState_ = buildState;

         buildEvents_.BuildStarted += BuildEvents__BuildStarted;
         buildEvents_.BuildFinished += BuildEvents_BuildFinished;

         buildEvents_.ProjectBuildFinished += BuildEvents__ProjectBuildFinished;
      }

      private void BuildEvents__ProjectBuildFinished(object sender, EventArgs e)
      {
         ProjectBuildEventArgs eventArgs = (ProjectBuildEventArgs) e;
         if (!eventArgs.BuildSuccess)
         {
            buildState_.AddFailedProject(eventArgs.Project);
            buildState_.BuildSuccessful = false;
         }
      }

      private void BuildEvents__BuildStarted(object sender, EventArgs e)
      {
         buildState_.ClearState();
      }

      private void BuildEvents_BuildFinished(object sender, EventArgs e)
      {
         if (buildState_.BuildSuccessful)
         {
            toastNotifier_.ShowToast(true, "Build Finished");
         }
         else
         {
            string buildFailedString = buildFailedFormatter_.FormatFailedBuild(buildState_.FailedProjects);

            toastNotifier_.ShowToast(false, "Build Failed" + buildFailedString);
         }

      }

   }
}
