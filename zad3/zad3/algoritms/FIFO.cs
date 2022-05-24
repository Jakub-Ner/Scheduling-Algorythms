namespace zad3
{
    public class FIFO : Algorithm
    {
        private int _oldest = 0;
        protected override void PageFault(Reference reference)
        {
            _oldest = _oldest % CONST.Frames;
            var chosenOne = base._frames[_oldest];
            _oldest++;
            chosenOne.Reference = reference.value;
        }
    }
}