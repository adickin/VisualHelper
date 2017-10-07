using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualHelper.EditorIntegrations;

namespace VisualHelperPackage.EditorIntegrations
{
   public class VisualHelperFileSystemLogger : ILogger
   {

      public const string LOGFILE_NAME = "VisualHelper.log";
      public const string VISUAL_HELPER_LOG_FOLDER = @"VisualHelper\Logs";

      string pathToLogFileFolder_;
      string logFilePath_;
      FileStream logFileStream_;
      StreamWriter streamWriter_;

      public VisualHelperFileSystemLogger()
      {
         string pathToUserFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
         pathToLogFileFolder_ = Path.Combine(pathToUserFolder, VISUAL_HELPER_LOG_FOLDER);
         logFilePath_ = Path.Combine(pathToLogFileFolder_, DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss-") + LOGFILE_NAME);
         Initialize();
      }

      private bool Initialize()
      {
         bool success = true;

         try
         {
            Directory.CreateDirectory(pathToLogFileFolder_);

            logFileStream_ = new FileStream(
               logFilePath_, 
               FileMode.OpenOrCreate,
               FileAccess.Write, 
               FileShare.Read);

            streamWriter_ = new StreamWriter(logFileStream_);
            streamWriter_.AutoFlush = true;
         }
         catch(Exception e)
         {
            success = false;
            Debug.WriteLine("Failed to create log file: " + logFilePath_ + ". Exception: " + e.ToString());
         }

         return success;
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
         streamWriter_.Write("[" + DateTime.Now.ToString() + "] " + type + ": " + message + Environment.NewLine);
         //using (StreamWriter s = new StreamWriter(logFileStream_))
         //{
         //   s.WriteLine("[" + DateTime.Now.ToString() + "] " + type + ": " + message + Environment.NewLine);
         //}
      }
   }
}
