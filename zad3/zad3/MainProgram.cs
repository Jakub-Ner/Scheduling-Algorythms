using System;
using zad3.AllocationOfFrames;

namespace zad3
{
    internal static class MainProgram
    {
        internal static Reference[] referenceList;

        public static void Main(string[] args)
        {
            GenerateRefList generate = new GenerateRefList();
            referenceList = generate.generateReferenceList();

            Reference[] cpy = referenceList.Clone() as Reference[];

            Algorithm[] algorithms = new Algorithm[]
            {
                new LRU(), // 0
                // new FIFO(), // 1
                // new OPT(),  // 2
                // new aLRU(), // 3
                // new RAND()  // 4
            };
            Allocation[] allocations = new Allocation[]
            {
                new Equal(),
                new Proportional(),
                new Managed()
            };

            // foreach (var algorithm in algorithms)
            //     Console.Write($"\t{algorithm.GetType().Name, 10}");
            // Console.WriteLine();

            Console.Clear();
            foreach (var allocation in allocations)
            {
                Console.Write("{0, -10}", allocation.GetType().Name);

                // all algorithms are initialized
                // algorithms[0].init(allocation);
                foreach (var algorithm in algorithms)
                {
                    referenceList = cpy.Clone() as Reference[];
                    algorithm.init(allocation);
                    foreach (var reference in referenceList)
                    {
                        algorithm.Run(reference);
                    }
                }

                foreach (var algorithm in algorithms)
                {
                    Console.Write($"Błędow strony: \t{algorithm.FaultCounter,2}");
                    Console.Write($"; Szamotań: {algorithm.ScufleCounter}");
                    if (allocation is Managed)
                        Console.Write($"; Usypień: {((Managed)allocation).SleepCounter}\n");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\nliczba procesow: " + CONST.PagesNum.Count);
            Console.WriteLine("\nliczba odwołań: " + generate.ReferenceNum);
        }
    }
}