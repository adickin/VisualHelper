using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualHelper.Values;

namespace VisualHelper.EditorIntegrations
{
   public interface IVsGlobalsEditor
   {
      void SetGlobalVariable(EnvironmentVariable variable);
   }
}
