using System;
using System.Collections.Generic;

namespace zad3
{
    public class GenerateRefList
    {
        private int size;
        private int PagesNum;
        private int ReferenceNum = 0;

        private static List<Process> processesList = new List<Process>(CONST.PagesNum.Count);

        public Reference[] generateReferenceList()
        {
            CONST.generate();

            generateProcesses();
            return shuffleProcesses();
        }

        private Reference[] shuffleProcesses()
        {
            Reference[] referenceList = new Reference[ReferenceNum];

            for (int i = 0; i < ReferenceNum; i++)
            {
                int indexOfNext = new Random().Next(processesList.Count);
                if (!processesList[indexOfNext].hasNext())
                {
                    processesList.Remove(processesList[indexOfNext]);
                    indexOfNext = new Random().Next(processesList.Count);
                }

                referenceList[i] = new Reference(processesList[indexOfNext]);
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
                processesList.Add(new Process());
                processesList[j].references = new int[CONST.ReferencesNum[j]];
                ReferenceNum += CONST.ReferencesNum[j];
                maxIndex = minimalIndex + CONST.PagesNum[j];

                for (i = 0; i < CONST.ReferencesNum[j]; i++)
                {
                    processesList[j].references[i] = getRef(minimalIndex, maxIndex, i, j);
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
                return processesList[j].references[index];
            }

            return new Random().Next(min, max);
        }

    }
}