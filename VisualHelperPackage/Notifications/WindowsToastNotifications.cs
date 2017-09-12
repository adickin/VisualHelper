using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
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

      private string GetImagePath(string image)
      {
         return Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), 
            image);
      }

      public void ShowToast(bool positiveNotification, String notificationMessage)
      {
         // Get a toast XML template
         XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText01);

         // Fill in the text elements
         XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
         stringElements[0].AppendChild(toastXml.CreateTextNode(notificationMessage));

         //// Specify the absolute path to an image
         string imagePath = "";
         if(positiveNotification)
         {
            imagePath = "file:///" + GetImagePath(@"Resources\checkmark.jpg");
         }
         else
         {
            imagePath = "file:///" + GetImagePath(@"Resources\redXMark.jpg");
         }

         XmlNodeList imageElements = toastXml.GetElementsByTagName("image");
         imageElements[0].Attributes.GetNamedItem("src").NodeValue = imagePath;

         // Create the toast and attach event listeners
         ToastNotification toast = new ToastNotification(toastXml);
         toast.ExpirationTime = System.DateTime.Now.AddMilliseconds(10000);

         ToastNotificationManager.CreateToastNotifier(VISUAL_HELPER_NOTIFICATION).Show(toast);
      }

   }
}

