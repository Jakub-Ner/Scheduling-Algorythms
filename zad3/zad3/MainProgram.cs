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
            aLRU alru = new aLRU();
            RAND rand = new RAND();

            generateReferenceList(referenceList);

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

        static void generateReferenceList(List<int> l)
        {
            for (int time = 0; time < CONST.DistanceOfReferenceLocality; time++)
                l.Add(new Random().Next(CONST.Pages));


            int size = 0;
            for (int time = CONST.DistanceOfReferenceLocality; time < CONST.Time; time++)
            {
                if ( new Random().NextDouble() < CONST.chanceOfLocality)
                    size = CONST.SizeOfBaseReferenceLocality;

                if (size > 0)
                {
                    int index = new Random().Next(time - CONST.DistanceOfReferenceLocality, time);
                    l.Add(l[index]);
                }
                else
                    l.Add(new Random().Next(CONST.Pages));

                size--;
            }
            // for (int i = 0; i < CONST.Time; i++)
            // {
            //     Console.Write(l[i] + " ");
            // }
        }

        static void generateDemoReferenceList(List<int> l)
        {
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