using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualHelper.Presentation;
using VisualHelper.Values;

namespace TestVisualHelper.Presentation
{
   [TestFixture]
   public class TestEnvironmentVariableToolWindowPresenter
   {
      EnvironmentVariableCollection variableData_;

      EnvironmentVariableToolWindowPresenter patient_;

      [SetUp]
      public void Init()
      {
         variableData_ = new EnvironmentVariableCollection();

         patient_ = new EnvironmentVariableToolWindowPresenter(
            variableData_);
      }

      [Test]
      public void WillReturnCorrectEnvironmentVariableDataContext()
      {
         object context = patient_.EnvironmentVariableDataContext();

         Assert.AreEqual(variableData_, context);
      }
   }
}
