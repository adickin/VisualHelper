using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestVisualHelper.Randoms;
using VisualHelper.Values;

namespace TestVisualHelper.Values
{
   [TestFixture]
   public class TestEnvironmentVariable
   {
      [Test]
      public void WillCreateDefaultVariableCorrectly()
      {
         EnvironmentVariable patient = new EnvironmentVariable();

         VerifyState(patient, "", "");
      }

      [Test]
      public void WillInitializeEnvironmentVariableCorrectly()
      {
         string variableName = RandomString.Generate(1);
         string variableValue = RandomString.Generate(1);

         EnvironmentVariable patient = new EnvironmentVariable(variableName, variableValue);

         VerifyState(patient, variableName, variableValue);
      }

      [Test]
      public void CanSetVariableName()
      {
         string variableName = RandomString.Generate(1);
         EnvironmentVariable patient = new EnvironmentVariable();

         patient.VariableName = variableName;

         VerifyState(patient, variableName, "");
      }

      [Test]
      public void CanSetVariableValue()
      {
         string variableValue = RandomString.Generate(1);
         EnvironmentVariable patient = new EnvironmentVariable();

         patient.VariableValue = variableValue;

         VerifyState(patient, "", variableValue);
      }

      [Test]
      public void WillNotifyWhenVariableNameChanged()
      {
         string variableName = RandomString.Generate(1);
         EnvironmentVariable patient = new EnvironmentVariable();
         bool wasCalled = false;
         patient.PropertyChanged += (sender, eventArgs) => { wasCalled = true; };

         patient.VariableName = variableName;

         Assert.AreEqual(true, wasCalled);
      }

      [Test]
      public void WillNotifyWhenVariableValueChanged()
      {
         string variableValue = RandomString.Generate(1);
         EnvironmentVariable patient = new EnvironmentVariable();
         bool wasCalled = false;
         patient.PropertyChanged += (sender, eventArgs) => { wasCalled = true; };

         patient.VariableValue = variableValue;

         Assert.AreEqual(true, wasCalled);
      }

      private void VerifyState(
         EnvironmentVariable patient,
         string variableName,
         string variableValue)
      {
         Assert.AreEqual(patient.VariableName, variableName);
         Assert.AreEqual(patient.VariableValue, variableValue);
      }
   }
}
