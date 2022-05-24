using System.Collections.Generic;

namespace zad3
{
    public class Process
    {
        public int[] references;
        private int next = 0;
        public List<Frame> Frames = new List<Frame>();

        public bool hasNext()
        {
            return next < references.Length;
        }

        public int getNext()
        {
            next++;
            return references[next - 1];
        }
        
    };
}