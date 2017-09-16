using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualHelper.BuildIntegration
{
   public class BuildState
   {
      public BuildState()
      {
         BuildSuccessful = true;
         FailedProjects = new List<string>();
      }

      public BuildState(
         bool buildSuccessful,
         List<string> failedProjects)
      {
         BuildSuccessful = buildSuccessful;
         FailedProjects = failedProjects;
      }

      public void ClearState()
      {
         BuildSuccessful = true;
         FailedProjects.Clear();
      }

      public void AddFailedProject(string failedProject)
      {
         FailedProjects.Add(failedProject);
      }

      public bool BuildSuccessful { get; set; }
      public List<string> FailedProjects { get; private set; }
   }
}
