using System;
using System.Collections.Generic;

namespace zad3
{
    public class GenerateRefList
    {
        private int size;
        private int PagesNum;
        private int ReferenceNum = 0;

        private List<Processes> processes = new List<Processes>(CONST.PagesNum.Count);

        public int[] generateReferenceList()
        {
            CONST.generate();
            
            generateProcesses();
             return shuffleProcesses();
        }

        private int[] shuffleProcesses()
        {
            int[] referenceList = new int[ReferenceNum];

            for (int i = 0; i < ReferenceNum; i++)
            {
                int indexOfNext = new Random().Next(processes.Count);
                if (!processes[indexOfNext].hasNext())
                {
                    processes.Remove(processes[indexOfNext]);
                    indexOfNext = new Random().Next(processes.Count);
                }

                referenceList[i] = processes[indexOfNext].getNext();
            }

            return referenceList;
        }

        private void generateProcesses()
        {
            int minimalIndex = 0;
            int maxIndex = 0;
            int i;

            for (int j = 0; j < CONST.ReferencesNum.Count; j++)
            {
                size = 0;
                processes.Add(new Processes());
                processes[j].references = new int[CONST.ReferencesNum[j]];
                ReferenceNum += CONST.ReferencesNum[j];
                maxIndex = minimalIndex + CONST.PagesNum[j];

                for (i = 0; i < CONST.ReferencesNum[j]; i++)
                {
                    processes[j].references[i] = getRef(minimalIndex, maxIndex, i, j);
                }

                minimalIndex += CONST.PagesNum[j];
            }

            PagesNum = maxIndex;
        }

        private int getRef(int min, int max, int numOfElements, int j)
        {
            int reference = 0;

            if (numOfElements > 0 && new Random().NextDouble() < CONST.chanceOfLocality)
                size = CONST.SizeOfBaseReferenceLocality;

            if (size > 0)
            {
                size--;
                int minimalIndex;
                if (numOfElements < CONST.DistanceOfReferenceLocality)
                    minimalIndex = 0;
                else minimalIndex = numOfElements - CONST.DistanceOfReferenceLocality;
                
                int index = new Random().Next(minimalIndex, numOfElements);
                return processes[j].references[index];
            }

            return new Random().Next(min, max);
        }


        class Processes
        {
            public int[] references;
            private int next = 0;

            public bool hasNext()
            {
                return next < references.Length;
            }

            public int getNext()
            {
                next++;
                return references[next - 1];
            }
        };
    }
}