using System;
using zad3.AllocationOfFrames;

namespace zad3
{
    public abstract class Algorithm
    {
        private int _faultInRow;
        private int _scufleCounter;
        private int _faultCounter;
        public int FaultCounter => _faultCounter;
        public int ScufleCounter => _scufleCounter;
        protected Allocation _allocation;

        public virtual void init(Allocation allocation)
        {
            _scufleCounter = 0;
            _faultInRow = 0;
            _faultCounter = 0;
            _allocation = allocation;
            _allocation.init(CONST.Frames);
        }

        protected int FindFrame(Reference reference)
        {
            foreach (var frame in reference.parent.Frames)
            {
                if (frame.Reference == reference.value)
                {
                    _faultInRow = 0;
                    frame.ReferenceBit = 1;
                    return frame.id;
                }
            }
            increaseFaultCounter(reference.parent);

            foreach (var frame in reference.parent.Frames)
                if (frame.Free)
                {
                    frame.Free = false;
                    frame.Reference = reference.value;
                    return frame.id;
                }
            return -1;
        }

        protected void increaseFaultCounter(Process parent)
        {
            _faultInRow++;
            if (_faultInRow > CONST.SCUFLE)
            {
                _scufleCounter++;
                _faultInRow = 0;
            }
            _faultCounter++;
            parent.errors++;
        }

        public virtual void Run(Reference reference)
        {
            if (FindFrame(reference) == -1)
            {
                PageFault(reference);
            }

            if (reference.parent.lastReference == reference)
            {
                int freedFrames = reference.parent.Frames.Count;
                GenerateRefList.processesList.Remove(reference.parent);
                _allocation.init(freedFrames);
            }
            _allocation.adjustFrames(reference.parent);
        }

        protected abstract void PageFault(Reference reference);
    }
}