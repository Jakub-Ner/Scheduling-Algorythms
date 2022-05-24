namespace zad3
{
    public class FIFO : Algorithm
    {
        private int _oldest = 0;
        protected override void PageFault(Reference reference)
        {
            int framesCount = reference.parent.Frames.Count;
            _oldest = _oldest % framesCount;
            var chosenOne = reference.parent.Frames[_oldest];
            _oldest++;
            chosenOne.Reference = reference.value;
        }
    }
}