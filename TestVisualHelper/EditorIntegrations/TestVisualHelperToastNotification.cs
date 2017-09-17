using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestVisualHelper.Randoms;
using VisualHelper.EditorIntegrations;

namespace TestVisualHelper.EditorIntegrations
{
   [TestFixture]
   public class TestVisualHelperToastNotification
   {
      [Test]
      public void CanDefaultConstruct()
      {
         VisualHelperToastNotification patient = new VisualHelperToastNotification();

         Assert.False(patient.ToastStatus);
         Assert.AreEqual(1, patient.ToastLines.Count);
         Assert.AreEqual(VisualHelperToastNotification.DEFAULT_TOAST_LINE, patient.ToastLines.ElementAt(0));
      }

      [Test]
      public void CanConstructToastNotification1()
      {
         bool toastStatus = false;
         string toastLine1 = RandomString.Generate(1);

         VisualHelperToastNotification patient = new VisualHelperToastNotification(
            toastStatus, toastLine1);

         Assert.AreEqual(toastStatus, patient.ToastStatus);
         Assert.AreEqual(1, patient.ToastLines.Count);
         Assert.AreEqual(toastLine1, patient.ToastLines.ElementAt(0));
      }

      [Test]
      public void CanConstructToastNotification2()
      {
         bool toastStatus = false;
         string toastLine1 = RandomString.Generate(1);
         string toastLine2 = RandomString.Generate(2);

         VisualHelperToastNotification patient = new VisualHelperToastNotification(
            toastStatus, toastLine1, toastLine2);

         Assert.AreEqual(toastStatus, patient.ToastStatus);
         Assert.AreEqual(2, patient.ToastLines.Count);
         Assert.AreEqual(toastLine1, patient.ToastLines.ElementAt(0));
         Assert.AreEqual(toastLine2, patient.ToastLines.ElementAt(1));
      }

      [Test]
      public void CanCompareEquals()
      {
         bool toastStatus = false;
         string toastLine1 = RandomString.Generate(1);
         string toastLine2 = RandomString.Generate(2);

         VisualHelperToastNotification patient = new VisualHelperToastNotification(
            toastStatus, toastLine1, toastLine2);
         VisualHelperToastNotification patient2 = new VisualHelperToastNotification(
            toastStatus, toastLine1, toastLine2);

         Assert.AreEqual(patient, patient2);
      }

      [Test]
      public void CanCompateNotEquals()
      {
         bool toastStatus = false;
         string toastLine1 = RandomString.Generate(1);
         string toastLine2 = RandomString.Generate(2);
         string toastLine3 = RandomString.Generate(2);
         string toastLine4 = RandomString.Generate(2);


         VisualHelperToastNotification patient = new VisualHelperToastNotification(
            toastStatus, toastLine1, toastLine2);
         VisualHelperToastNotification patient2 = new VisualHelperToastNotification(
            toastStatus, toastLine3, toastLine4);

         Assert.AreNotEqual(patient, patient2);
      }
   }
}
