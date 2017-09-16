using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVisualHelper.Randoms
{
   public class RandomPath
   {
      static string driveLetter = @"C:";//random enough for now.

      static public string Generate(int seed, int pathDepth = 3)
      {
         string randomPath = driveLetter;
         for(int i = 0; i < pathDepth; i++)
         {
            randomPath += Path.PathSeparator + RandomString.Generate(seed + i);
         }

         return randomPath;
      }
   }
}
