using System;

namespace zad3
{
    public class RAND : Algorithm
    {
        protected override void PageFault(int reference)
        {
            _frames[new Random().Next(CONST.Frames)].Reference = reference;
        }
    }
}
