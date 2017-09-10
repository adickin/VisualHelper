using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using VisualHelper.EditorIntegrations;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace VisualHelperPackage.Notificatons
{
   public class WindowsToastNotifications : IToastNotifier
   {
      const String VISUAL_HELPER_NOTIFICATION = "Visual Helper Notification";

      public void ShowToast(String notificationMessage)
      {
         // Get a toast XML template
         XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText01);

         // Fill in the text elements
         XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
         stringElements[0].AppendChild(toastXml.CreateTextNode(notificationMessage));

         //// Specify the absolute path to an image
         String imagePath = "file:///" + Path.GetFullPath(@"Resources\checkmark.jpg");
         XmlNodeList imageElements = toastXml.GetElementsByTagName("image");
         imageElements[0].Attributes.GetNamedItem("src").NodeValue = imagePath;

         // Create the toast and attach event listeners
         ToastNotification toast = new ToastNotification(toastXml);
         toast.ExpirationTime = System.DateTime.Now.AddMilliseconds(10000);

         ToastNotificationManager.CreateToastNotifier(VISUAL_HELPER_NOTIFICATION).Show(toast);
      }

   }
}

