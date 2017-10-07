using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualHelper.BuildIntegration;

namespace VisualHelper.Presentation
{
   public class PresentationContainer
   {

      public PresentationContainer(IBuildIntegrationContainer buildIntegrationContainer)
      {
         EnvironmentVariableToolWindowPresenter = new EnvironmentVariableToolWindowPresenter(
            buildIntegrationContainer.EnvironmentVariableData());
      }

      public IEnvironmentVariableToolWindowPresenter EnvironmentVariableToolWindowPresenter { get; private set; }
   }
}