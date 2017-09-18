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
      VisualHelperFileSystemLogger fileSystemLogger_;
      VisualHelperLogger logger_;

      VsBuildEventsWrapper buildEventsWrapper_;
      WindowsToastNotifications toastNotifications_;


      public VsIntegrationsContainer(
         VsServices visualStudioServices )
      {
         outputWindowLogger_ = new VisualHelperOutputWindowLogger(
            visualStudioServices.VsOutputWindow);
         fileSystemLogger_ = new VisualHelperFileSystemLogger();
         logger_ = new VisualHelperLogger(
            fileSystemLogger_,
            outputWindowLogger_);

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

      public ILogger Logger()
      {
         return logger_;
      }
   }
}
