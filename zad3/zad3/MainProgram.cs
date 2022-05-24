using System;

namespace zad3
{
    internal static class MainProgram
    {
        internal static Reference[] referenceList;
        
        public static void Main(string[] args)
        {
            referenceList = new GenerateRefList().generateReferenceList();
            Algorithm[] algorithms = new Algorithm[]
                {
                    new FIFO(), // 0
                    new OPT(),  // 1
                    new LRU(),  // 2
                    new aLRU(), // 3
                    new RAND()  // 4
                };


            foreach (var reference in referenceList)
                foreach (var algorithm in algorithms)
                {
                    algorithm.Run(reference);
                }

            foreach (var algorithm in algorithms)
                Console.WriteLine("\n"+ algorithm.GetType().Name + ": " + algorithm.FaultCounter);

        }
        
    }
}