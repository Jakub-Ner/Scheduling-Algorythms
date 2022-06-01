using static zad3.GenerateRefList;

namespace zad3.AllocationOfFrames
{

    public abstract class Allocation
    {
        
        public abstract void adjustFrames(Process currentProcess);

        public virtual void init(int Frames)
        {
            if (Frames == CONST.Frames)
                foreach (Process process in processesList)
                {
                    process.Frames.Clear();
                    process.errors = 0;
                }
        }
    }
}