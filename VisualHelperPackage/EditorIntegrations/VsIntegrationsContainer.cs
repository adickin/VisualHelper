﻿using System;
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
      VsBuildEventsWrapper buildEventsWrapper_;
      WindowsToastNotifications toastNotifications_;

      public VsIntegrationsContainer(
         VsServices visualStudioServices )
      {
         buildEventsWrapper_ = new VsBuildEventsWrapper(visualStudioServices.VSBuildEvents);
         toastNotifications_ = new WindowsToastNotifications();
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
