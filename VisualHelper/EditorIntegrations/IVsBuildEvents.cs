using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualHelper.EditorIntegrations
{
   public class ProjectBuildEventArgs : EventArgs
   {
      public string Project { get; private set; }
      public bool BuildSuccess { get; private set; }

      public ProjectBuildEventArgs(
         string project,
         bool success)
      {
         Project = project;
         BuildSuccess = success;
      }
   }

   public interface IVsBuildEvents
   {
      event EventHandler BuildStarted;
      event EventHandler BuildFinished;

      event EventHandler ProjectBuildFinished;
   }
}
