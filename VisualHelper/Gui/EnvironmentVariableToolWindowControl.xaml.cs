//------------------------------------------------------------------------------
// <copyright file="EnvironmentVariableToolWindowControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace VisualHelper.Gui
{
   using Presentation;
   using System.Diagnostics.CodeAnalysis;
   using System.Windows;
   using System.Windows.Controls;

   /// <summary>
   /// Interaction logic for EnvironmentVariableToolWindowControl.
   /// </summary>
   public partial class EnvironmentVariableToolWindowControl : UserControl
   {
      IEnvironmentVariableToolWindowPresenter presenter_;

      /// <summary>
      /// Initializes a new instance of the <see cref="EnvironmentVariableToolWindowControl"/> class.
      /// </summary>
      public EnvironmentVariableToolWindowControl()
      {
         this.InitializeComponent();
      }

      public void AttachToPresenter(IEnvironmentVariableToolWindowPresenter presenter)
      {
         presenter_ = presenter;

         wEnvironmentVariableTableDataGrid.DataContext = presenter_.EnvironmentVariableDataContext();
      }

   }
}