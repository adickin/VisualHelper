//------------------------------------------------------------------------------
// <copyright file="EnvironmentVariableToolWindow.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace VisualHelperPackage.Gui
{
   using System;
   using System.Runtime.InteropServices;
   using Microsoft.VisualStudio.Shell;
   using VisualHelper.Gui;

   /// <summary>
   /// This class implements the tool window exposed by this package and hosts a user control.
   /// </summary>
   /// <remarks>
   /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
   /// usually implemented by the package implementer.
   /// <para>
   /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
   /// implementation of the IVsUIElementPane interface.
   /// </para>
   /// </remarks>
   /// 

   [Guid("15b2c695-4014-48e5-b379-127dd58c8b3c")]
   public class EnvironmentVariableToolWindow : ToolWindowPane
   {

      public EnvironmentVariableToolWindowControl windowControl_;
      /// <summary>
      /// Initializes a new instance of the <see cref="EnvironmentVariableToolWindow"/> class.
      /// </summary>
      public EnvironmentVariableToolWindow() : base(null)
      {
         this.Caption = "EnvironmentVariableToolWindowControl";

         // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
         // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
         // the object returned by the Content property.
         windowControl_ = new VisualHelper.Gui.EnvironmentVariableToolWindowControl();
         //control.dataGrid.CanUserAddRows = true;
         windowControl_.wEnvironmentVariableTableDataGrid.DataContext = 
            new System.Collections.ObjectModel.ObservableCollection<VisualHelper.Values.EnvironmentVariable>();
         this.Content = windowControl_;


      }
   }
}
