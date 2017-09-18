using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolkit.FileSystem;

namespace TestToolkit.FileSystem
{
   [TestFixture]
   public class TestFileSystemUtilities
   {
      private FileSystemUtilities patient_;

      [SetUp]
      public void Init()
      {
         patient_ = new FileSystemUtilities();
      }

      [Test]
      public void InitialTest()
      {
         Assert.True(true);
      }
   }
}
