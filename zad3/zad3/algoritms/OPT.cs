using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Permissions;

namespace zad3
{
    public class OPT : Algorithm
    {
        private Reference[] _referenceList;
        private int _currentTime = 0;
        
        public OPT()
        {
            _referenceList = MainProgram.referenceList;
        }

        public override void Run(Reference reference)
        {
            base.Run(reference);
            _currentTime++;
        }

        protected override void PageFault(Reference reference)
        {
            List<Frame> helper = new List<Frame>(reference.parent.Frames);

            int i = _currentTime + 1;
            while (i < _referenceList.Length)
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
                i++;
            }
        }
    }
}