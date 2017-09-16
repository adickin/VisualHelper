using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualHelper.BuildIntegration
{
   public class BuildFailedFormatter : IBuildFailedFormatter
   {
      public string FormatFailedBuild(List<string> failedProjects)
      {
         string failedProjectsString = String.Join(", ", failedProjects);
         string buildFailedString = "(" + failedProjects.Count + "): " + failedProjectsString;

         return buildFailedString;
      }
   }
}
