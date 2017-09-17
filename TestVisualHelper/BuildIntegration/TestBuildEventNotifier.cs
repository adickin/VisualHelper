using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VisualHelper.BuildIntegration;
using VisualHelper.EditorIntegrations;
using Moq;
using TestVisualHelper.Randoms;

namespace TestVisualHelper.BuildIntegration
{
   [TestFixture]
   public class TestBuildEventNotifier
   {
      Mock<IVsBuildEvents> vsBuildEvents_;
      Mock<IToastNotifier> toastNotifier_;
      Mock<IBuildFailedFormatter> buildFailedFormatter_;
      BuildState buildState_;

      BuildEventNotifier patient_;

      [SetUp]
      public void Init()
      {
         vsBuildEvents_ = new Mock<IVsBuildEvents>();
         toastNotifier_ = new Mock<IToastNotifier>();
         buildFailedFormatter_ = new Mock<IBuildFailedFormatter>();
         buildState_ = new BuildState();

         CreatePatient(buildState_);
      }

      [Test]
      public void WillNotifyBuildFinishedSuccessfully()
      {
         VisualHelperToastNotification expectedNotification = new VisualHelperToastNotification(
            true, BuildEventNotifier.BUILD_SUCCESS_STRING);

         vsBuildEvents_.Raise(x => x.BuildFinished += null, new EventArgs());

         toastNotifier_.Verify(x => x.ShowToast(expectedNotification));
      }

      [Test]
      public void WillClearBuildStateOnBuildStarted()
      {
         vsBuildEvents_.Raise(x => x.BuildStarted += null, new EventArgs());

         Assert.True(buildState_.BuildSuccessful);
         Assert.IsEmpty(buildState_.FailedProjects);
      }

      [Test]
      public void WillNotAddFailedProjectIfProjectBuildIsSuccessful()
      {
         vsBuildEvents_.Raise(x => x.ProjectBuildFinished += null, new ProjectBuildEventArgs(
            RandomString.Generate(1), true));

         Assert.True(buildState_.BuildSuccessful);
         Assert.IsEmpty(buildState_.FailedProjects);
      }

      [Test]
      public void WillAddFailedProjectIfProjectBuildIsNotSuccessful()
      {
         string project = RandomString.Generate(1);

         vsBuildEvents_.Raise(x => x.ProjectBuildFinished += null, new ProjectBuildEventArgs(
            project, false));

         Assert.AreEqual(buildState_.FailedProjects.Count, 1);
         Assert.AreEqual(buildState_.FailedProjects.ElementAt(0), project);
      }

      [Test]
      public void WillMarkBuildAsUnsuccesfulWhenProjectBuildFails()
      {
         string project = RandomString.Generate(1);

         vsBuildEvents_.Raise(x => x.ProjectBuildFinished += null, new ProjectBuildEventArgs(
            project, false));

         Assert.False(buildState_.BuildSuccessful);
      }

      [Test]
      public void WillAskBuildFailedFormatterToFormatFailedProjects()
      {
         List<string> failedProjects = RandomStringList.Generate(1);
         buildState_ = new BuildState(false, failedProjects);
         CreatePatient(buildState_);

         vsBuildEvents_.Raise(x => x.BuildFinished += null, new EventArgs());

         buildFailedFormatter_.Verify( x => x.FormatFailedBuild(failedProjects));
      }

      [Test]
      public void WillShowToastWithFormattedBuildFailedString()
      {
         List<string> failedProjects = RandomStringList.Generate(1);
         buildState_ = new BuildState(false, failedProjects);
         CreatePatient(buildState_);
         string formattedBuildFailed = RandomString.Generate(1);
         MakeBuildFailedFormatterReturn(formattedBuildFailed);
         VisualHelperToastNotification expectedNotification = new VisualHelperToastNotification(
            false, BuildEventNotifier.BUILD_FAILED_STRING, formattedBuildFailed);

         vsBuildEvents_.Raise(x => x.BuildFinished += null, new EventArgs());

         toastNotifier_.Verify(x => x.ShowToast(expectedNotification));
      }

      private void CreatePatient(
         BuildState state)
      {
         patient_ = new BuildEventNotifier(
            vsBuildEvents_.Object,
            toastNotifier_.Object,
            buildFailedFormatter_.Object,
            state);
      }

      private void MakeBuildFailedFormatterReturn(string formattedBuildString)
      {
         buildFailedFormatter_.Setup(x => x.FormatFailedBuild(It.IsAny<List<string>>())).Returns(formattedBuildString);
      }
   }
}

