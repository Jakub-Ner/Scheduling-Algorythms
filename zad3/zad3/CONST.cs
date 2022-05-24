using System;
using System.Collections.Generic;

namespace zad3
{
    public static class CONST
    {
        // public static int Frames => 2; // <- the higher, the closest results
        public static int DistanceOfReferenceLocality => 5;
        public static int SizeOfBaseReferenceLocality => 3;
        public static double chanceOfLocality => 0.3;
        
        
         /* processes: */
         public static List<int> ReferencesNum = new List<int>();
         public static List<int> PagesNum = new List<int>();
         
         public static void generate()
         {
             for (int i = 0; i < 100; i++) // for 100 iterations, over 20k processes
             {
                 ReferencesNum.Add(new Random().Next(10, (i*i)%1000 + 10 ));
                 PagesNum.Add(new Random().Next(10, (i*i)%100 + 10 ));
             }
         }
    }
}