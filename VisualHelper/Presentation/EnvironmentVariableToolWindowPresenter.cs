using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualHelper.Values;

namespace VisualHelper.Presentation
{
   public class EnvironmentVariableToolWindowPresenter : IEnvironmentVariableToolWindowPresenter
   {
      EnvironmentVariableCollection environmentVariableData_;

      public EnvironmentVariableToolWindowPresenter(
         EnvironmentVariableCollection environmentVariableData)
      {
         environmentVariableData_ = environmentVariableData;
      }

      public object EnvironmentVariableDataContext()
      {
         return environmentVariableData_;
      }
   }
}
