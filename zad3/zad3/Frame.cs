namespace zad3
{
    public class Frame
    {
        public readonly int id;
        public bool Free { get; set; } = true;
        public int ReferenceBit { get; set; } = 0;
        public int Reference { get; set; }
        
        public Frame(int id)
        {
            this.id = id;
            this.Reference = -1;
        }
    }
}