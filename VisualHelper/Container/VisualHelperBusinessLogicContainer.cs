using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualHelper.BuildIntegration;
using VisualHelper.EditorIntegrations;
using VisualHelper.Presentation;

namespace VisualHelper.Container
{
   public class VisualHelperBusinessLogicContainer
   {
      IVsIntegrationsContainer vsIntegrationsContainer_;

      BuildIntegrationContainer buildIntegrationContainer_;

      public PresentationContainer presentationContainer_;

      public VisualHelperBusinessLogicContainer(
         IVsIntegrationsContainer vsIntegrationsContainer )
      {
         vsIntegrationsContainer_ = vsIntegrationsContainer;

         buildIntegrationContainer_ = new BuildIntegrationContainer(
            vsIntegrationsContainer_);

         presentationContainer_ = new PresentationContainer(
            buildIntegrationContainer_);
      }
   }
}
