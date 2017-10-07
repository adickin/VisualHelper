using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using VisualHelper.Gui;
using VisualHelper.Presentation;
using VisualHelper.Values;

namespace TestVisualHelper.Gui
{
   [TestFixture, Apartment(ApartmentState.STA)]
   public class TestEnvironmentVariableToolWindowControl
   {

      Mock<IEnvironmentVariableToolWindowPresenter> toolWindowPresenter_;

      EnvironmentVariableToolWindowControl patient_;

      [SetUp]
      public void Init()
      {
         toolWindowPresenter_ = new Mock<IEnvironmentVariableToolWindowPresenter>();

         patient_ = new EnvironmentVariableToolWindowControl();

      }

      [Test]
      public void HasControls()
      {
         Assert.NotNull(patient_.wEnvironmentVariableTableLabel);
         Assert.NotNull(patient_.wEnvironmentVariableTableDataGrid);
      }

      [Test]
      public void WillSetupEnvironmentVariableTableDataGridCorrectly()
      {
         Assert.IsFalse(patient_.wEnvironmentVariableTableDataGrid.AutoGenerateColumns);
         Assert.AreEqual("Variable Name", patient_.wEnvironmentVariableTableDataGrid.Columns.ElementAt(0).Header);
         Assert.AreEqual("Variable Value", patient_.wEnvironmentVariableTableDataGrid.Columns.ElementAt(1).Header);
      }

      [Test]
      public void WillSetupDataGridsDataContext()
      {
         EnvironmentVariable variable = new EnvironmentVariable("123", "456");
         ObservableCollection<EnvironmentVariable> dataContext = new ObservableCollection<EnvironmentVariable>();
         toolWindowPresenter_.Setup(x => x.EnvironmentVariableDataContext()).Returns(dataContext);
         bool wasCalled = false;
         patient_.wEnvironmentVariableTableDataGrid.DataContextChanged += (sender, eventArgs) => { wasCalled = true; }; 
         
         patient_.AttachToPresenter(toolWindowPresenter_.Object);

         Assert.AreEqual(true, wasCalled);
         Assert.AreEqual(dataContext, patient_.wEnvironmentVariableTableDataGrid.DataContext);
      }
   }
}
