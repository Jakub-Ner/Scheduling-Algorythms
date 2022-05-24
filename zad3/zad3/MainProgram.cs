using System;
using System.Collections.Generic;

namespace zad3
{
    internal static class MainProgram
    {
        public static void Main(string[] args)
        {
            List<int> referenceList = new List<int>();

            FIFO fifo = new FIFO();
            OPT opt = new OPT(referenceList);
            LRU lru = new LRU(referenceList);
            aLRU alru = new aLRU();
            RAND rand = new RAND();

            GenerateRefList.generateReferenceList(referenceList);

            foreach (int reference in referenceList)
            {
                fifo.Run(reference);
                opt.Run(reference);
                lru.Run(reference);
                alru.Run(reference);
                rand.Run(reference);
            }
        
            Console.WriteLine("\nfifo : " + fifo.FaultCounter);
            Console.WriteLine("\nopt : " + opt.FaultCounter);
            Console.WriteLine("\nlru : " + lru.FaultCounter);
            Console.WriteLine("\nalru: " + alru.FaultCounter);
            Console.WriteLine("\nrand : " + rand.FaultCounter);
        }

        
        
    }
}