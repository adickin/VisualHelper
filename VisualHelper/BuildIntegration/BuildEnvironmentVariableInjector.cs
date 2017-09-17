using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualHelper.BuildIntegration
{
   public class BuildEnvironmentVariableInjector
   {

      public const string VISUAL_HELPER = "VISUAL_HELPER";

      /*
       * all that is needed to inject env variables into the build is to just set them once.
       * Should build this to have profiles of environment variables.
       */
      public BuildEnvironmentVariableInjector()
      {

         Environment.SetEnvironmentVariable("VISUAL_HELPER", @"D:\workspace\shairport4w\visualHelperTest_canBeDeleted");

      }

   }
}
