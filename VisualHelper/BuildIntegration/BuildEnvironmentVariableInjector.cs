using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VisualHelper.EditorIntegrations;
using VisualHelper.Values;

namespace VisualHelper.BuildIntegration
{
   public class BuildEnvironmentVariableInjector
   {

      public const string VISUAL_HELPER = "VISUAL_HELPER";

      EnvironmentVariableCollection environmentVariableData_;
      ILogger logger_;

      public BuildEnvironmentVariableInjector(
         EnvironmentVariableCollection environmentVariableData,
         ILogger logger)
      {
         environmentVariableData_ = environmentVariableData;
         logger_ = logger;

         environmentVariableData_.Add(new EnvironmentVariable(VISUAL_HELPER, "SOME VALUE HERE"));


         environmentVariableData_.CollectionChanged += EnvironmentVariableData__CollectionChanged;
         //Environment.SetEnvironmentVariable("VISUAL_HELPER", @"D:\workspace\shairport4w\visualHelperTest_canBeDeleted");

      }

      private void EnvironmentVariableData__CollectionChanged(
         object sender, 
         System.Collections.Specialized.NotifyCollectionChangedEventArgs eventArgs)
      {
         // for some reason, i cant do what im doing here.
         logger_.LogDebug("here adam");
      }
   }
}
