using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualHelper.EditorIntegrations;

namespace VisualHelper.BuildIntegration
{
   public class BuildIntegrationContainer
   {
      BuildState buildState_;
      BuildFailedFormatter buildFailedFormatter_;

      BuildEventNotifier buildEventNotifier_;

      public BuildIntegrationContainer(
         IVsBuildEvents buildEvents,
         IToastNotifier toastNotifier)
      {
         buildState_ = new BuildState();
         buildFailedFormatter_ = new BuildFailedFormatter();

         buildEventNotifier_ = new BuildEventNotifier(
            buildEvents,
            toastNotifier,
            buildFailedFormatter_,
            buildState_);
      }
   }
}
