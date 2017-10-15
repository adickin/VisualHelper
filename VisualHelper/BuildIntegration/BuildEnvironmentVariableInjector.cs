using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VisualHelper.EditorIntegrations;
using VisualHelper.Values;


namespace VisualHelper.BuildIntegration
{
   public class BuildEnvironmentVariableInjector
   {

      EnvironmentVariableCollection environmentVariableData_;
      IVsGlobalsEditor globalsEditor_;
      ILogger logger_;

      public BuildEnvironmentVariableInjector(
         EnvironmentVariableCollection environmentVariableData,
         IVsGlobalsEditor globalsEditor,
         ILogger logger)
      {
         environmentVariableData_ = environmentVariableData;
         globalsEditor_ = globalsEditor;
         logger_ = logger;

         environmentVariableData_.CollectionChanged += EnvironmentVariableData__CollectionChanged;

         logger_.LogDebug("Current PID COnstructor: " + Process.GetCurrentProcess().Id + " Name: " + Process.GetCurrentProcess().ProcessName);
         //Environment.SetEnvironmentVariable("VISUAL_HELPER", @"D:\workspace\shairport4w\visualHelperTest_canBeDeleted");

      }

      private void EnvironmentVariableData__CollectionChanged(
         object sender, 
         System.Collections.Specialized.NotifyCollectionChangedEventArgs eventArgs)
      {
         if (eventArgs.NewItems != null)
         {
            foreach (EnvironmentVariable newItem in eventArgs.NewItems)
            {
               logger_.LogDebug("Adding variable name: " + newItem.VariableName + " Variable value: " + newItem.VariableValue);

              // ModifiedItems.Add(newItem);

               newItem.PropertyChanged += OnItemPropertyChanged;
            }
         }

         if (eventArgs.OldItems != null)
         {
            foreach (EnvironmentVariable oldItem in eventArgs.OldItems)
            {
               logger_.LogDebug("OLD variable name: " + oldItem.VariableName + " Variable value: " + oldItem.VariableValue);

               //ModifiedItems.Add(oldItem);

               oldItem.PropertyChanged -= this.OnItemPropertyChanged;
            }
         }
      }

      private void OnItemPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
      {
         EnvironmentVariable variable = sender as EnvironmentVariable;
         if(variable != null)
         {
            logger_.LogDebug("Current PID on property change: " + Process.GetCurrentProcess().Id + " Name: " + Process.GetCurrentProcess().ProcessName);

            logger_.LogDebug("Edited variable name: " + variable.VariableName + " Variable value: " + variable.VariableValue);
            //will edit environment variable xml

            Environment.SetEnvironmentVariable(variable.VariableName, variable.VariableValue, EnvironmentVariableTarget.Process);
            globalsEditor_.SetGlobalVariable(variable);

         }
      }
   }
}
