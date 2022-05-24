namespace zad3
{
    public class aLRU : Algorithm
    {
        protected override void PageFault(Reference reference)
        {
            for (int i = 0; i < 2; i++)
            {
                foreach (var frame in _frames)
                {
                    if (frame.ReferenceBit == 0)
                    {
                        frame.Reference = reference.value;
                        frame.ReferenceBit = 1;
                        return;
                    }
                    frame.ReferenceBit = 0;
                }
            }
        }
    }
}