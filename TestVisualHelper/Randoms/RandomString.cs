using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVisualHelper.Randoms
{
   public class RandomString
   {
      static String alphabetString =
         "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.";

      static public string Generate(int seed = 1, int size = 8)
      {
         Random rng = new Random(seed);
         String generatedString = "";
         for(int i = 0; i < size; i++)
         {
            generatedString += alphabetString[rng.Next(0, alphabetString.Length - 1)];
         }
         return generatedString;
      }
   }
}
