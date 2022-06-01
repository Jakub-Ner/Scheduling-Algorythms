using System;
using System.Collections.Generic;
using System.Reflection;
using static zad3.GenerateRefList;

namespace zad3.AllocationOfFrames
{
    public class Managed : Proportional
    {
        private const double L = 0.3;
        private const double U = 0.8;
        private const int TIME = 100;
        public int sleep = 0;
        
        private List<Process> freezedProcesses;
        private int _time;

        public override void init(int Frames)
        {
            base.init(Frames);
            _time = TIME;
            freezedProcesses = new List<Process>();
        }

        private int surplus;

        public override void adjustFrames(Process currentProcess)
        {
            _time--;
            currentProcess.time++;

            if (_time > 0) return;

            _time = TIME;
            List<Process> waitingProcesses = new List<Process>();
            surplus = 0;
            foreach (var process in processesList)
            {
                double t = process.time;
                double rate = process.errors / (double)process.time;
                if (rate < L)
                {
                    if (process.Frames.Count > 0)
                        process.Frames.Remove(process.Frames[0]);
                    surplus++;
                }
                else if (rate > U)
                {
                    if (!giveFrame(process))
                    {
                        waitingProcesses.Add(process);
                        // processesList.Remove(process);
                    }
                }

                process.errors = 0;
                process.time = 0;
            }


            while (waitingProcesses.Count > 0)
            {
                while (giveFrame(waitingProcesses[0]))
                {
                    waitingProcesses.Remove(waitingProcesses[0]);
                    if (waitingProcesses.Count == 0) return;
                }

                // maybe we should freeze some processes?
                Console.Write("USYPIANIE ");
                sleep++;
                surplus += waitingProcesses[0].Frames.Count;
                freezedProcesses.Add(waitingProcesses[0].Copy());
                processesList.Remove(waitingProcesses[0]);
                waitingProcesses.Remove(waitingProcesses[0]);

                while (surplus > 0)
                {
                    if (waitingProcesses.Count == 0) return;
                    giveFrame(waitingProcesses[0], true);
                    waitingProcesses.Remove(waitingProcesses[0]);
                }
            }
        }

        private bool giveFrame(Process process = null, bool flag=false)
        {
            if (surplus == 0) return false;
            surplus--;

            if (!flag && freezedProcesses.Count > 0)
            {
                freezedProcesses[0].Frames.Add(new Frame(freezedProcesses[0].Frames.Count));

                // is time to unfreeze?
                if (freezedProcesses[0].Frames.Count >
                    (int)(proportion(freezedProcesses[0].id, total()) * CONST.Frames))
                {
                    processesList.Add(freezedProcesses[0]);
                    freezedProcesses.Remove(freezedProcesses[0]);
                }

                return false;
            }

            if (process != null)
                process.Frames.Add(new Frame(process.Frames.Count));

            return true;
        }
    }
}