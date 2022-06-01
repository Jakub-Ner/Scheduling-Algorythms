using System;
using System.Linq;
using static zad3.GenerateRefList;

namespace zad3.AllocationOfFrames
{

    public class Proportional : Allocation
    {
        public readonly Func<int, double, double> proportion = (i, total) => (CONST.PagesNum[i] / total);
        
        public override void init(int Frames)
        {
            base.init(Frames);
            
            int rest = total();
            int[] Fi = new int[processesList.Count];
            
            for (int i = 0; i < processesList.Count; i++)
            {
                Fi[i] = (int)(proportion(i, total()) * CONST.Frames);
                rest -= Fi[i];
            }
            initHelper(Fi, rest);
        }

        public int total()
        {
            int total = 0;
            for (int i = 0; i < processesList.Count; i++)
            {
                total += CONST.PagesNum[processesList[i].id];
            }
            return total;
        }
        public void initHelper(int[] Fi, int rest)
        {
            int processIndex = 0;
            foreach (var process in processesList)
            {
                int previousSize = process.Frames.Count;
                for(int i = process.Frames.Count; i < Fi[processIndex] + previousSize; i++)
                    process.Frames.Add(new Frame(i));
                
                if (rest > 0) 
                    process.Frames.Add(new Frame(process.Frames.Count));
                rest--;
                processIndex++;
            }
        }

        public override void adjustFrames(Process currentProcess)
        {
        }
    }
}