using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualHelper.EditorIntegrations;

namespace VisualHelper.Core
{
   public class BuildEventNotifier
   {
      IVsBuildEvents buildEvents_;
      IToastNotifier toastNotifier_;

      public BuildEventNotifier(
         IVsBuildEvents buildEvents,
         IToastNotifier toastNotifier)
      {
         buildEvents_ = buildEvents;
         toastNotifier_ = toastNotifier;

         buildEvents_.BuildStarted += BuildEvents__BuildStarted;
         buildEvents_.BuildFinished += BuildEvents_BuildFinished;
      }

      private void BuildEvents__BuildStarted(object sender, EventArgs e)
      {
         toastNotifier_.ShowToast("Build Started");
      }

      private void BuildEvents_BuildFinished(object sender, EventArgs e)
      {
         toastNotifier_.ShowToast("Build Finished");
      }

   }
}
