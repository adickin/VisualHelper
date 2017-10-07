using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualHelper.EditorIntegrations;
using VisualHelper.Values;

namespace VisualHelper.BuildIntegration
{
   public class BuildIntegrationContainer : IBuildIntegrationContainer
   {
      BuildState buildState_;
      BuildFailedFormatter buildFailedFormatter_;
      BuildEventNotifier buildEventNotifier_;

      EnvironmentVariableCollection environmentVariableTableData_;
      BuildEnvironmentVariableInjector environmentVariableInjector_;

      public BuildIntegrationContainer(
         IVsBuildEvents buildEvents,
         IToastNotifier toastNotifier,
         ILogger logger)
      {
         buildState_ = new BuildState();
         buildFailedFormatter_ = new BuildFailedFormatter();
         buildEventNotifier_ = new BuildEventNotifier(
            buildEvents,
            toastNotifier,
            buildFailedFormatter_,
            buildState_);

         environmentVariableTableData_ = new EnvironmentVariableCollection();
         environmentVariableInjector_ = new BuildEnvironmentVariableInjector(
            environmentVariableTableData_,
            logger);
      }

      public EnvironmentVariableCollection EnvironmentVariableData()
      {
         return environmentVariableTableData_;
      }
   }
}
