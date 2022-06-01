using System.Collections.Generic;
using System.ComponentModel;
using zad3.AllocationOfFrames;

namespace zad3
{
    public class LRU : Algorithm
    {
        private Reference[] _referenceList; 
        int _currentTime = 0;

        public LRU()
        {
            _referenceList = MainProgram.referenceList;
        }

        public override void init(Allocation allocation)
        {
            _currentTime = 0;
            _referenceList = MainProgram.referenceList;
            base.init(allocation);
        }
        
        public override void Run(Reference reference)
        {
            base.Run(reference);
            _currentTime++;
        }

        protected override void PageFault(Reference reference)
        {
            List<Frame> helper = new List<Frame>(reference.parent.Frames);

            int i = _currentTime - 1;
            while (i > 0)
            {
                foreach (var frame in helper)
                {
                    if (helper.Count == 1)
                    {
                        helper[0].Reference = reference.value;
                        return;
                    }

                    if (_referenceList[i].value == frame.Reference)
                    {
                        helper.Remove(frame);
                        break;
                    }
                }
                i--;
            }
        }
    }
}