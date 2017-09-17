﻿using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualHelperPackage.EditorIntegrations
{
   public class VsServices
   {

      public bool InitializeServices(
         IServiceProvider serviceProvider)
      {
         bool status = false;

         EnvDte = serviceProvider.GetService(typeof(DTE)) as DTE;


         VSBuildEvents = EnvDte.Events.BuildEvents;


         VsOutputWindow = serviceProvider.GetService(typeof(SVsOutputWindow)) as IVsOutputWindow;

         status =
            (EnvDte != null) &&
            (VSBuildEvents != null) &&
            (VsOutputWindow != null);

         Debug.WriteLine(
            "Services:" +
            "\nEnvDte: " + (EnvDte != null) +
            "\nVSBuildEvents: " + (VSBuildEvents != null) +
            "\nVsOutputWindow: " + (VsOutputWindow != null)
            );

         return status;
      }

      public DTE EnvDte { get; private set; }

      public BuildEvents VSBuildEvents { get; private set; }

      public IVsOutputWindow VsOutputWindow { get; private set; }

   }
}
