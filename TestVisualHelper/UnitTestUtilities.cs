
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestVisualHelper.Randoms;

namespace TestVisualHelper
{
   public class UnitTestUtilities
   {
      public static DirectoryInfo CreateTemporaryDirectory(int seed = 1)
      {
         string tempPath = Path.GetTempPath();
         tempPath += RandomString.Generate(seed);
         DirectoryInfo dirInfo = Directory.CreateDirectory(tempPath);
         if(!dirInfo.Exists)
         {
            Console.WriteLine("Directory creation failed: " + tempPath);
         }
         else
         {
            Console.WriteLine("Directory Created at: " + tempPath );

         }
         return dirInfo;
      }
      
      public static List<string> CreateRandomEmptyFilesInDirectory(
         string directoryPath,
         int numberOfFiles = 3, 
         int seed = 1)
      {
         List<string> createdFiles = new List<string>();
         for(int i = 0; i < numberOfFiles; i++)
         {
            string fileToCreate = directoryPath + @"\" + RandomString.Generate(i + seed);
            File.Create(fileToCreate).Close();
            createdFiles.Add(fileToCreate);
         }
         return createdFiles;
      }
   }
}
