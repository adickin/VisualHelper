using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualHelper.EditorIntegrations;

namespace VisualHelperPackage.EditorIntegrations
{
   public class VisualHelperLogger : ILogger
   {
      ILogger fileSystemLogger_;
      ILogger consoleLogger_;

      public VisualHelperLogger(
         ILogger fileSystemLogger,
         ILogger consoleLogger)
      {
         fileSystemLogger_ = fileSystemLogger;
         consoleLogger_ = consoleLogger;
      }

      public void LogDebug(string message)
      {
         fileSystemLogger_.LogDebug(message);
         consoleLogger_.LogDebug(message);
      }

      public void LogWarning(string message)
      {
         fileSystemLogger_.LogWarning(message);
         consoleLogger_.LogWarning(message);
      }

      public void LogError(string message)
      {
         fileSystemLogger_.LogError(message);
         consoleLogger_.LogError(message);
      }
      
   }
}
