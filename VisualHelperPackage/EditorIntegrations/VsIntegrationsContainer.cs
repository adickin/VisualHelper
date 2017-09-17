using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualHelper.EditorIntegrations;
using VisualHelperPackage.Notificatons;

namespace VisualHelperPackage.EditorIntegrations
{
   public class VsIntegrationsContainer : IVsIntegrationsContainer
   {
      VisualHelperOutputWindowLogger outputWindowLogger_;

      VsBuildEventsWrapper buildEventsWrapper_;
      WindowsToastNotifications toastNotifications_;


      public VsIntegrationsContainer(
         VsServices visualStudioServices )
      {
         outputWindowLogger_ = new VisualHelperOutputWindowLogger(
            visualStudioServices.VsOutputWindow);

         buildEventsWrapper_ = new VsBuildEventsWrapper(
            visualStudioServices.VSBuildEvents);
         toastNotifications_ = new WindowsToastNotifications(
            visualStudioServices.EnvDte);
      }

      public IVsBuildEvents VsBuildEvents()
      {
         return buildEventsWrapper_;
      }

      public IToastNotifier ToastNotifier()
      {
         return toastNotifications_;
      }
   }
}
