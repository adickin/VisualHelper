using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualHelper.BuildIntegration
{
   public interface IBuildFailedFormatter
   {
      string FormatFailedBuild(List<string> failedBuilds);
   }
}
