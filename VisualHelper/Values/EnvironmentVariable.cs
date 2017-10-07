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

      string variableName_;
      string variableValue_;

      public event PropertyChangedEventHandler PropertyChanged;

      public EnvironmentVariable()
      {
         variableName_ = "";
         variableValue_ = "";
      }

      public EnvironmentVariable(
         string variableName,
         string variableValue)
      {
         variableName_ = variableName;
         this.variableValue_ = variableValue;
      }

      public string VariableName
      {
         get
         {
            return variableName_;
         }
         set
         {
            variableName_ = value;

            OnPropertyChanged("VariableName");
         }
      }
      public string VariableValue
      {
         get
         {
            return variableValue_;
         }
         set
         {
            variableValue_ = value;
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
