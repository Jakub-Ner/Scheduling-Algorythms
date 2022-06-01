using static zad3.GenerateRefList;

namespace zad3.AllocationOfFrames
{
    public class Equal : Allocation
    {
        public override void init(int Frames)
        {
            base.init(Frames);
            if (processesList.Count == 0) 
                return;
            int Fi = Frames / processesList.Count;
            int rest = Frames % processesList.Count;
            initHelper(Fi, rest);
        }


        public void initHelper(int Fi, int rest)
        {
            foreach (var process in processesList)
            {
                int previousSize = process.Frames.Count;
                for (int i = process.Frames.Count; i < Fi + previousSize; i++)
                    process.Frames.Add(new Frame(i));

                if (rest > 0)
                    process.Frames.Add(new Frame(process.Frames.Count));
                rest--;
            }
        }

        public override void adjustFrames(Process currentProcess)
        {
        }
    }
}