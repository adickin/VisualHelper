using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualHelper.EditorIntegrations
{
   public class VisualHelperToastNotification
   {
      public const string DEFAULT_TOAST_LINE = "Default Toast Notification";

      public VisualHelperToastNotification()
      {
         ToastStatus = false;
         ToastLines = new List<string>();
         ToastLines.Add(DEFAULT_TOAST_LINE);
      }

      public VisualHelperToastNotification(
         bool toastStatus,
         string toastLine1)
      {
         ToastStatus = toastStatus;
         ToastLines = new List<string>();
         ToastLines.Add(toastLine1);
      }

      public VisualHelperToastNotification(
         bool toastStatus,
         string toastLine1,
         string toastLine2)
      {
         ToastStatus = toastStatus;
         ToastLines = new List<string>();
         ToastLines.Add(toastLine1);
         ToastLines.Add(toastLine2);
      }

      public override bool Equals(object obj)
      {
         bool areEqual = false;
         if(obj.GetType() == GetType() && obj != null)
         {
            VisualHelperToastNotification castedObj = obj as VisualHelperToastNotification;
            areEqual = 
               (ToastStatus == castedObj.ToastStatus) &&
               (ToastLines.SequenceEqual(castedObj.ToastLines));
         }
         return areEqual;
      }

      public override int GetHashCode()
      {
         int hashCode = ToastStatus.GetHashCode() ^ ToastLines.GetHashCode();
         return hashCode;
      }

      public bool ToastStatus { get; private set; }
      public List<string> ToastLines { get; private set; }

   }
}
