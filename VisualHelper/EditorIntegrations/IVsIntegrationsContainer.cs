using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualHelper.EditorIntegrations
{
   public interface IVsIntegrationsContainer
   {
      IVsBuildEvents VsBuildEvents();

      IToastNotifier ToastNotifier();

      ILogger Logger();

      IVsGlobalsEditor GlobalsEditor();
   }
}
