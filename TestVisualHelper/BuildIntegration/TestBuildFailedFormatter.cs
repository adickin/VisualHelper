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
         //string path = RandomPath.Generate(1);
         //string projectName = RandomString.Generate(2);
         //string failedProject = Path.Combine(path, projectName + ".csproj");
         //List<string> failedProjects = new List<string>();
         //failedProjects.Add(failedProject);
         List<string> failedProjects = GenerateFailedProjectList();

         string output = patient_.FormatFailedBuild(failedProjects);

         Assert.AreEqual("", output);
      }

      private string dkdk()
      {
         return "";
      }

      //change function to return a object that contains the full paths as well as just the names.
      //ADAM TODO
      private List<string> GenerateFailedProjectList(int size = 3)
      {
         List<string> failedProjects = new List<string>();

         for(int i = 0; i < size; i++)
         {
            string path = RandomPath.Generate(i);
            string projectName = RandomString.Generate(i);
            string failedProject = Path.Combine(path, projectName + ".csproj");
            failedProjects.Add(failedProject);
         }

         return failedProjects;
      }
   }
}
