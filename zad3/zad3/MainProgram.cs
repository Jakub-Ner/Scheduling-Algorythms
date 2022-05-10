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
            generateReferenceList(referenceList);
            
            foreach (int reference in referenceList)
            {
                fifo.Run(reference);
                Console.WriteLine(fifo.FaultCounter);
                
            }
            Console.WriteLine("\nkoniec"+fifo.FaultCounter);
        }
        
       static void generateReferenceList(List<int> l)
        {
            // for (int time = 0; time < CONST.Time; time++)
            // {
            //     l.Add(new Random().Next(CONST.Pages));
            // }
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);
            l.Add(1);
            l.Add(2);
            l.Add(5);
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Add(4);
            l.Add(5);
        }
    }


}