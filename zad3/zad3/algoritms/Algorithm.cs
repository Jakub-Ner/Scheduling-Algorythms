using System;
using System.Collections.Generic;

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

        public void display()
        {
            foreach (var frame in _frames)
            {
                Console.Write(frame.Reference + " ");
            }

            Console.WriteLine();
        }
        protected int FindFrame(Reference reference)
        {
            foreach (var frame in _frames)
            {
                if (frame.Reference == reference.value)
                {
                    frame.ReferenceBit = 1;
                    return frame.id;
                }
                    
            }
            _faultCounter++;
            
            foreach (var frame in _frames)
                if (frame.Free)
                {
                    frame.Free = false;
                    frame.Reference = reference.value;
                    return frame.id;
                }
            return -1;
        }

        public virtual void Run(Reference reference)
        {
            if (FindFrame(reference) == -1)
            {
                PageFault(reference);
            }
        }

        protected abstract void PageFault(Reference reference);
    }
}