using System;
using System.Collections.Generic;
using System.Linq;

namespace zad3
{
    public class GenerateRefList
    {
        private int size;
        public int PagesSum;
        public int ReferenceNum = 0;

        private static List<Process> _processesList = new List<Process>(CONST.PagesNum.Count);
        public static List<Process> processesList => new List<Process>(_processesList);
        public Reference[] generateReferenceList()
        {
            CONST.generate();

            generateProcesses();
            return shuffleProcesses();
        }

        private Reference[] shuffleProcesses()
        {
            Reference[] referenceList = new Reference[ReferenceNum];
            List<int> aliveLists = Enumerable.Range(0, _processesList.Count).ToList();
                
            for (int i = 0; i < ReferenceNum; i++)
            {
                int indexOfNext = aliveLists[new Random().Next(aliveLists.Count)];
                while (!_processesList[indexOfNext].hasNext())
                {
                    aliveLists.Remove(indexOfNext); // <- aliveLists[x] = indexOfNext
                    indexOfNext = aliveLists[new Random().Next(aliveLists.Count)];
                }

                referenceList[i] = new Reference(_processesList[indexOfNext]);
                _processesList[indexOfNext].lastReference = referenceList[i];
            }

            _processesList.ForEach(process => process.references = null);
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
                _processesList.Add(new Process(j));
                _processesList[j].references = new int[CONST.ReferencesNum[j]];
                ReferenceNum += CONST.ReferencesNum[j];
                maxIndex = minimalIndex + CONST.PagesNum[j];

                for (i = 0; i < CONST.ReferencesNum[j]; i++)
                {
                    _processesList[j].references[i] = getRef(minimalIndex, maxIndex, i, j);
                }

                minimalIndex += CONST.PagesNum[j];
            }

            PagesSum = maxIndex;
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
                return _processesList[j].references[index];
            }

            return new Random().Next(min, max);
        }

    }
}