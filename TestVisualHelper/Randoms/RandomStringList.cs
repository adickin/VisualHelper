using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVisualHelper.Randoms
{
   public class RandomStringList
   {
      static public List<string> Generate(int seed = 1, int size = 8)
      {
         List<string> randomStrings = new List<string>();

         for(int i = 0; i < size; i++)
         {
            randomStrings.Add(RandomString.Generate(seed+1, size));
         }

         return randomStrings;
      }
   }
}
