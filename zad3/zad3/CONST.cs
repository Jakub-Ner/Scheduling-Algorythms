using System;
using System.Collections.Generic;

namespace zad3
{
    public static class CONST
    {
        public static int Frames => 7_00; // <- the higher, the closest results
        public static int DistanceOfReferenceLocality => 10;
        public static int SizeOfBaseReferenceLocality => 3;
        public static double chanceOfLocality => 0.1;
        
        
         /* processes: */
         public static List<int> ReferencesNum = new List<int>();
         public static List<int> PagesNum = new List<int>();
         public static int SCUFLE = 50;

         public static void generate()
         {
             for (int i = 0; i < 200; i++) // for 100 iterations, over 20k processes
             {
                 int range = (i % 99 == 1) ? 10_000 : 1_000;
                 ReferencesNum.Add(new Random().Next(10, (i*i)%range + 10 ));
                 PagesNum.Add(new Random().Next(10, (i*i)%range/10 + 10 ));
             }
         }
    }
}