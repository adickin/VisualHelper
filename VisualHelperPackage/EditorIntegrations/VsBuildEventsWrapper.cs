using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualHelper.EditorIntegrations;

namespace VisualHelperPackage.EditorIntegrations
{
   public class VsBuildEventsWrapper : IVsBuildEvents
   {
      BuildEvents vsBuildEvents_;

      public event EventHandler BuildStarted;
      public event EventHandler BuildFinished;

      public event EventHandler ProjectBuildFinished;

      public VsBuildEventsWrapper(
         BuildEvents vsBuildEvents )
      {
         vsBuildEvents_ = vsBuildEvents;

         vsBuildEvents_.OnBuildProjConfigDone += VsBuildEvents__OnBuildProjConfigDone;

         vsBuildEvents_.OnBuildBegin += VsBuildEvents__OnBuildBegin;
         vsBuildEvents_.OnBuildDone += VsBuildEvents__OnBuildDone;

      }

      private void VsBuildEvents__OnBuildProjConfigDone(
         string Project, 
         string ProjectConfig, 
         string Platform, 
         string SolutionConfig, 
         bool Success)
      {
         ProjectBuildFinished(this, new ProjectBuildEventArgs(
            Project,
            Success));
      }

      private void VsBuildEvents__OnBuildBegin(vsBuildScope Scope, vsBuildAction Action)
      {
         BuildStarted(this, new EventArgs());
      }

      private void VsBuildEvents__OnBuildDone(vsBuildScope Scope, vsBuildAction Action)
      {
         BuildFinished(this, new EventArgs() );
      }
   }
}
