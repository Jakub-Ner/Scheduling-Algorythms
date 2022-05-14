using System.Collections.Generic;

namespace zad3
{
    public class LRU : Algorithm
    {
        private List<int> _referenceList;
        private int _currentTime = 0;

        public LRU(List<int> referenceList)
        {
            _referenceList = referenceList;
        }

        public override void Run(int reference)
        {
            base.Run(reference);
            _currentTime++;
        }

        protected override void PageFault(int reference)
        {
            List<Frame> helper = new List<Frame>(_frames);

            int i = _currentTime - 1;
            while (i > 0)
            {
                foreach (var frame in helper)
                {
                    if (helper.Count == 1)
                    {
                        helper[0].Reference = reference;
                        return;
                    }

                    if (_referenceList[i] == frame.Reference)
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