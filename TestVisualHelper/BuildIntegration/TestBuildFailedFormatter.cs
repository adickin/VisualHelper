using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestVisualHelper.Randoms;
using VisualHelper.BuildIntegration;

namespace TestVisualHelper.BuildIntegration
{
   [TestFixture]
   public class TestBuildFailedFormatter
   {
      BuildFailedFormatter patient_;

      [SetUp]
      public void Init()
      {
         patient_ = new BuildFailedFormatter();
      }

      [Test]
      public void WillNotFormatEmptyFailedBuildsList()
      {
         List<string> failedBuilds = new List<string>();

         string output = patient_.FormatFailedBuild(failedBuilds);

         Assert.IsEmpty(output);
      }

      [Test]
      public void WillFormatBuildFailedListCorrectly()
      {
         var failedProjects = GenerateFailedProjectList();

         string output = patient_.FormatFailedBuild(failedProjects.Item2);

         Assert.AreEqual(ExpectedFailedBuildFormattedString(failedProjects.Item1), output);
      }

      private string ExpectedFailedBuildFormattedString(List<string> projectNames)
      {
         string failedNamesString = String.Join(", ", projectNames);

         return "Projects Failed("+projectNames.Count+"): " + failedNamesString;
      }

      private Tuple<List<string>, List<string>> GenerateFailedProjectList(int size = 3)
      {
         List<string> failedProjectPaths = new List<string>();
         List<string> failedProjectNames = new List<string>();

         for (int i = 0; i < size; i++)
         {
            string path = RandomPath.Generate(i);
            string projectName = RandomString.Generate(i);
            string failedProject = Path.Combine(path, projectName + ".csproj");
            failedProjectPaths.Add(failedProject);
            failedProjectNames.Add(projectName);
         }

         return new Tuple<List<string>, List<string>>(failedProjectNames, failedProjectPaths);
      }
   }
}
