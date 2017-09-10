using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualHelper.Core;
using VisualHelper.EditorIntegrations;

namespace VisualHelper.Container
{
   public class VisualHelperBusinessLogicContainer
   {
      IVsIntegrationsContainer vsIntegrationsContainer_;

      BuildEventNotifier buildEventNotifier_;

      public VisualHelperBusinessLogicContainer(
         IVsIntegrationsContainer vsIntegrationsContainer )
      {
         vsIntegrationsContainer_ = vsIntegrationsContainer;

         buildEventNotifier_ = new BuildEventNotifier(
            vsIntegrationsContainer_.VsBuildEvents(),
            vsIntegrationsContainer_.ToastNotifier());
      }
   }
}
