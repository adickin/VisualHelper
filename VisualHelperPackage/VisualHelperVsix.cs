﻿//------------------------------------------------------------------------------
// <copyright file="VSPackage1.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;
using System.Windows.Forms;
using VisualHelperPackage.EditorIntegrations;
using VisualHelper.Container;
using VisualHelperPackage.Notificatons;

namespace VisualHelperPackage
{
   /// <summary>
   /// This is the class that implements the package exposed by this assembly.
   /// </summary>
   /// <remarks>
   /// <para>
   /// The minimum requirement for a class to be considered a valid package for Visual Studio
   /// is to implement the IVsPackage interface and register itself with the shell.
   /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
   /// to do it: it derives from the Package class that provides the implementation of the
   /// IVsPackage interface and uses the registration attributes defined in the framework to
   /// register itself and its components with the shell. These attributes tell the pkgdef creation
   /// utility what data to put into .pkgdef file.
   /// </para>
   /// <para>
   /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
   /// </para>
   /// </remarks>
   [PackageRegistration(UseManagedResourcesOnly = false)]
   [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
   [Guid(VisualHelperVsix.PackageGuidString)]
   [ProvideAutoLoad("ADFC4E64-0397-11D1-9F4E-00A0C911004F")]
   [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
   [ProvideMenuResource("Menus.ctmenu", 1)]
   [ProvideToolWindow(typeof(VisualHelperPackage.Gui.EnvironmentVariableToolWindow))]
   public sealed class VisualHelperVsix : Package
   {
      /// <summary>
      /// VSPackage1 GUID string.
      /// </summary>
      public const string PackageGuidString = "0199134e-2e60-4946-a477-f8c50d8908c3";

      /// <summary>
      /// Initializes a new instance of the <see cref="VSPackage1"/> class.
      /// </summary>
      public VisualHelperVsix()
      {
         // Inside this method you can place any initialization code that does not require
         // any Visual Studio service because at this point the package object is created but
         // not sited yet inside Visual Studio environment. The place to do all the other
         // initialization is the Initialize method.
         visualStudioServices_ = new VsServices();
      }

      #region Package Members

      /// <summary>
      /// Initialization of the package; this method is called right after the package is sited, so this is the place
      /// where you can put all the initialization code that rely on services provided by VisualStudio.
      /// </summary>
      protected override void Initialize()
      {
         base.Initialize();

         visualStudioServices_.InitializeServices(this);

         visualStudioIntegrationsContainer_ = new VsIntegrationsContainer(
            visualStudioServices_);

         visualHelperBusinessLogicContainer_ = new VisualHelperBusinessLogicContainer(
            visualStudioIntegrationsContainer_);
          VisualHelperPackage.Gui.EnvironmentVariableToolWindowCommand.Initialize(this);
      }

      #endregion

      #region Package Variables

      VsServices visualStudioServices_;

      VsIntegrationsContainer visualStudioIntegrationsContainer_;

      VisualHelperBusinessLogicContainer visualHelperBusinessLogicContainer_;
      
      #endregion
   }
}
