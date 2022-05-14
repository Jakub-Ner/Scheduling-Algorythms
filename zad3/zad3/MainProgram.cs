using System;
using System.Collections.Generic;

namespace zad3
{
    internal class MainProgram
    {
        public static void Main(string[] args)
        {
            List<int> referenceList = new List<int>();
            
            FIFO fifo = new FIFO();
            OPT opt = new OPT(referenceList);
            LRU lru = new LRU(referenceList);
            RAND rand = new RAND();
            
            generateReferenceList(referenceList);
            
            foreach (int reference in referenceList)
            {
                // fifo.Run(reference);
                // opt.Run(reference);
                // lru.Run(reference);
                rand.Run(reference);
                Console.WriteLine(rand.FaultCounter);
            }
            Console.WriteLine("\nkoniec: "+ rand.FaultCounter);
        }
        
       static void generateReferenceList(List<int> l)
        {
            // for (int time = 0; time < CONST.Time; time++)
            // {
            //     l.Add(new Random().Next(CONST.Pages));
            // }
            l.Add(1 - 1);
            l.Add(2 - 1);
            l.Add(3 - 1);
            l.Add(4 - 1);
            l.Add(1 - 1);
            l.Add(2 - 1);
            l.Add(5 - 1);
            l.Add(1 - 1);
            l.Add(2 - 1);
            l.Add(3 - 1);
            l.Add(4 - 1);
            l.Add(5 - 1);
        }
    }
}