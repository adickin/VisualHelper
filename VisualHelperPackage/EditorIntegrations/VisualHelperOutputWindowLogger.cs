using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualHelper.EditorIntegrations;

namespace VisualHelperPackage.EditorIntegrations
{
   public class VisualHelperOutputWindowLogger : ILogger
   {

      public const string VISUAL_HELPER_OUTPUT_WINDOW_TITLE = "Visual Helper";

      IVsOutputWindowPane outputWindowPane_;

      public VisualHelperOutputWindowLogger(
         IVsOutputWindow vsOutputWindow)
      {
         Guid outputWindowGuid = new Guid(Guids.VISUAL_HELPER_OUTPUT_WINDOW_GUID);

         vsOutputWindow.CreatePane(ref outputWindowGuid, VISUAL_HELPER_OUTPUT_WINDOW_TITLE, 1, 1);
         vsOutputWindow.GetPane(ref outputWindowGuid, out outputWindowPane_);
      }

      public void LogDebug(string message)
      {
         Log("Debug", message);
      }

      public void LogWarning(string message)
      {
         Log("Warning", message);
      }

      public void LogError(string message)
      {
         Log("Error", message);
      }

      private void Log(string type, string message)
      {
         outputWindowPane_.OutputString("[" + DateTime.Now.ToString() + "] "+ type +": " + message + Environment.NewLine);
      }
   }
}
