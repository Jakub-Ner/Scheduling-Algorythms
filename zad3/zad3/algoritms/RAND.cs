using System;

namespace zad3
{
    public class RAND : Algorithm
    {
        protected override void PageFault(Reference reference)
        {
            int framesCount = reference.parent.Frames.Count;
            reference.parent.Frames[new Random().Next(framesCount)].Reference = reference.value;
        }
    }
}
