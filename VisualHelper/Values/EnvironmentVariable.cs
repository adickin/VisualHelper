using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualHelper.Values
{
   public class EnvironmentVariable : INotifyPropertyChanged
   {

      string variableName;
      string variableValue;

      public event PropertyChangedEventHandler PropertyChanged;

      public EnvironmentVariable()
      {
         variableName = "";
         variableValue = "";
      }

      public EnvironmentVariable(
         string variableName,
         string variableValue)
      {
         this.variableName = variableName;
         this.variableValue = variableValue;
      }

      public string VariableName
      {
         get
         {
            return variableName;
         }
         set
         {
            variableName = value;

            OnPropertyChanged("VariableName");
         }
      }
      public string VariableValue
      {
         get
         {
            return variableValue;
         }
         set
         {
            variableValue = value;
            OnPropertyChanged("VariableValue");
         }
      }

      protected void OnPropertyChanged(string name)
      {
         PropertyChangedEventHandler handler = PropertyChanged;
         if (handler != null)
         {
            handler(this, new PropertyChangedEventArgs(name));
         }
      }
   }
}
