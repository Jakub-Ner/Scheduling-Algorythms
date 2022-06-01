using System.Collections.Generic;

namespace zad3
{
    public class Process
    {
        public int id;
        public int time;
        public int[] references;
        private int next = 0;
        public Reference lastReference;
        public int errors = 0;
        public List<Frame> Frames;


        public Process(int id)
        {
            Frames = new List<Frame>();
            this.id = id;
        }

        public Process Copy()
        {
            Process newProcess = new Process(id);
            newProcess.errors = 0;
            newProcess.lastReference = lastReference;
            newProcess.Frames = new List<Frame>();
            return newProcess;
        }

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