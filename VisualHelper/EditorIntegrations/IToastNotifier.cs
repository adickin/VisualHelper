using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualHelper.EditorIntegrations
{
   public interface IToastNotifier
   {
      void ShowToast(bool positiveNotification, string notificationMessage);
   }
}
