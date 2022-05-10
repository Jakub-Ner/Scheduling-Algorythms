using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace zad3
{
    public abstract class Algorithm
    {
        protected List<Frame> _frames = new List<Frame>();
        private int _faultCounter; 
        public int FaultCounter => _faultCounter;

        protected Algorithm()
        {
            _faultCounter = 0;
            for(int i=0; i< CONST.Frames; i++)
                _frames.Add(new Frame(i));
        }
        
        protected int FindFrame(int reference)
        {
            foreach (var frame in _frames)
            {
                if (frame.Free) return frame.id;
                if (frame.Reference == reference) return frame.id;
            }
            return -1;
        }

        public void Run(int reference)
        {
            int tmp = FindFrame(reference);
            if (tmp != -1)
            {
                _frames[tmp].Free = false;
                _frames[tmp].Reference = reference;
            }
            else
            {
                PageFault(reference);
                _faultCounter++;
            }
        }

        protected abstract void PageFault(int reference);
    }
}