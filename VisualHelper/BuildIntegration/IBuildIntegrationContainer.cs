using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualHelper.Values;

namespace VisualHelper.BuildIntegration
{
   public interface IBuildIntegrationContainer
   {
      EnvironmentVariableCollection EnvironmentVariableData();
   }
}
