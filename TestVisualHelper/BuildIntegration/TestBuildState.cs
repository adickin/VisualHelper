using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestVisualHelper.Randoms;
using VisualHelper.BuildIntegration;

namespace TestVisualHelper.BuildIntegration
{
   [TestFixture]
   public class TestBuildState
   {
      [Test]
      public void WillCreateDefaultStateCorrectly()
      {
         BuildState patient = new BuildState();

         VerifyState(patient, true, new List<string>());
      }

      [Test]
      public void WillConstructCorrectly()
      {
         bool buildSuccesful = false;
         List<string> failedBuilds = RandomStringList.Generate(1);

         BuildState patient = new BuildState(buildSuccesful, failedBuilds);

         VerifyState(patient, buildSuccesful, failedBuilds);
      }

      [Test]
      public void CanSetBuildSuccessful()
      {
         BuildState patient = new BuildState();
         patient.BuildSuccessful = false;

         patient.BuildSuccessful = true;

         Assert.IsTrue(patient.BuildSuccessful);
      }

      [Test]
      public void CanAddFailedProject()
      {
         BuildState patient = new BuildState();
         string failedProject = RandomString.Generate(1);

         patient.AddFailedProject(failedProject);

         Assert.IsNotEmpty(patient.FailedProjects);
         Assert.AreEqual(patient.FailedProjects.Count, 1);
         Assert.AreEqual(patient.FailedProjects.ElementAt(0), failedProject);
      }

      [Test]
      public void CanAddMultipleFailedProjects()
      {
         BuildState patient = new BuildState();
         List<string> failedProjects = RandomStringList.Generate(1);

         AddFailedProjectsToState(patient, failedProjects);

         CollectionAssert.AreEquivalent(failedProjects, patient.FailedProjects);
      }

      [Test]
      public void CanClearBuildState()
      {
         BuildState patient = new BuildState();
         List<string> failedProjects = RandomStringList.Generate(1);
         AddFailedProjectsToState(patient, failedProjects);
         patient.BuildSuccessful = false;

         patient.ClearState();

         VerifyState(patient, true, new List<string>());
      }

      private void AddFailedProjectsToState(
         BuildState buildState,
         List<string> failedProjects)
      {
         for (int i = 0; i < failedProjects.Count; i++)
         {
            buildState.AddFailedProject(failedProjects.ElementAt(i));
         }
      }

      private void VerifyState(
         BuildState buildState,
         bool buildSuccessful,
         List<string> failedProjects)
      {
         Assert.AreEqual(buildSuccessful, buildState.BuildSuccessful);
         CollectionAssert.AreEqual(failedProjects, buildState.FailedProjects);
      }
   }
}
