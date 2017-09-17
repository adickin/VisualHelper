using EnvDTE;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
      private DTE dteService_;

      public WindowsToastNotifications(DTE dteService)
      {
         dteService_ = dteService;
      }

      public void ShowToast(VisualHelperToastNotification notification)
      {
         ToastTemplateType toastType = DetermineToastType(notification.ToastLines.Count);
         XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastType);


         XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
         for(int i = 0; i < notification.ToastLines.Count; i++)
         {
            stringElements[i].AppendChild(toastXml.CreateTextNode(notification.ToastLines.ElementAt(i)));
         }

         string imagePath = GetNotificationImagePath(notification.ToastStatus);

         XmlNodeList imageElements = toastXml.GetElementsByTagName("image");
         imageElements[0].Attributes.GetNamedItem("src").NodeValue = imagePath;

         // Create the toast and attach event listeners
         ToastNotification toast = new ToastNotification(toastXml);
         toast.ExpirationTime = System.DateTime.Now.AddMilliseconds(10000);

         string solutionName = GetSolutionName();
         ToastNotificationManager.CreateToastNotifier(solutionName).Show(toast);
      }

      private string GetSolutionName()
      {
         return Path.GetFileNameWithoutExtension(dteService_.Solution.FullName);
      }

      private ToastTemplateType DetermineToastType(int numberOfLines)
      {
         ToastTemplateType type = ToastTemplateType.ToastText01;
         if( numberOfLines == 1)
         {
            type = ToastTemplateType.ToastImageAndText01;
         }
         else if(numberOfLines == 2 )
         {
            type = ToastTemplateType.ToastImageAndText02;
         }
         return type;
      }

      private string GetNotificationImagePath(bool positiveNotification)
      {
         string imagePath = "";
         if (positiveNotification)
         {
            imagePath = "file:///" + GetImagePath(@"Resources\checkmark.jpg");
         }
         else
         {
            imagePath = "file:///" + GetImagePath(@"Resources\redXMark.jpg");
         }
         return imagePath;
      }

      private string GetImagePath(string image)
      {
         return Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            image);
      }
   }
}

