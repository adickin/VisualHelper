using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualHelper.BuildIntegration;
using VisualHelper.EditorIntegrations;

namespace VisualHelper.Container
{
   public class VisualHelperBusinessLogicContainer
   {
      IVsIntegrationsContainer vsIntegrationsContainer_;

      BuildIntegrationContainer buildIntegrationContainer_;

      public VisualHelperBusinessLogicContainer(
         IVsIntegrationsContainer vsIntegrationsContainer )
      {
         vsIntegrationsContainer_ = vsIntegrationsContainer;

         buildIntegrationContainer_ = new BuildIntegrationContainer(
            vsIntegrationsContainer_.VsBuildEvents(),
            vsIntegrationsContainer_.ToastNotifier());
      }
   }
}
