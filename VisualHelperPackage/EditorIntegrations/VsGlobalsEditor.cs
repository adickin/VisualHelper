using EnvDTE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualHelper.EditorIntegrations;
using VisualHelper.Values;

namespace VisualHelperPackage.EditorIntegrations
{
   public class VsGlobalsEditor : IVsGlobalsEditor
   {
      DTE envDte_;
      Globals vsGlobals_;

      public VsGlobalsEditor(
         DTE envDte,
         Globals vsGlobals)
      {
         envDte_ = envDte;
         vsGlobals_ = vsGlobals;
      }

      public void SetGlobalVariable(EnvironmentVariable variable)
      {
         vsGlobals_[variable.VariableName] = variable.VariableValue;

         envDte_.Solution.Globals[variable.VariableName] = variable.VariableValue;
      }
   }
}
