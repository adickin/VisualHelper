using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualHelper.BuildIntegration
{
   public class BuildFailedFormatter : IBuildFailedFormatter
   {
      public string FormatFailedBuild(List<string> failedProjectPaths)
      {
         if(failedProjectPaths.Count == 0)
         {
            return "";
         }

         List<string> projectNames = new List<string>();
         foreach(string projectPath in failedProjectPaths)
         {
            projectNames.Add(Path.GetFileNameWithoutExtension(projectPath));
         }

         string formattedProjectNames = String.Join(", ", projectNames);

         return "Projects Failed("+ projectNames.Count +"): " + formattedProjectNames;
      }
   }
}
