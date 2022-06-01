// using System.Collections.Generic;
// using static zad3.GenerateRefList;
//
// namespace zad3.AllocationOfFrames
// {
//     public class Zoned : Proportional
//     {
//         private const int TIME = 35;
//
//         private List<Process> freezedProcesses;
//         private int _time;
//
//         public override void init(int Frames)
//         {
//             base.init(Frames);
//             _time = TIME;
//             freezedProcesses = new List<Process>();
//         }
//
//         private int surplus;
//         public override void adjustFrames(Process dupa)
//         {
//             _time--;
//             if (_time > 0) return;
//
//             _time = TIME;
//             List<Process> waitingProcesses = new List<Process>();
//             surplus = 0;
//             foreach (var process in processesList)
//             {
//                 double rate = process.errors / (double)TIME;
//                 if (rate < L)
//                 {
//                     if (process.Frames.Count > 0)
//                         process.Frames.Remove(process.Frames[0]);
//                     surplus++;
//                     process.errors = 0;
//                 }
//                 else if (rate > U)
//                 {
//                     if (!giveFrame(process))
//                     {
//                         waitingProcesses.Add(process);
//                         // processesList.Remove(process);
//                     }
//                 }
//             }
//
//
//             while (waitingProcesses.Count > 0)
//             {
//                 while (giveFrame(waitingProcesses[0]))
//                 {
//                     waitingProcesses.Remove(waitingProcesses[0]);
//                     if (waitingProcesses.Count == 0) return;
//                 }
//
//                 // maybe we should freeze some processes?
//                 surplus += waitingProcesses[0].Frames.Count;
//                 freezedProcesses.Add(waitingProcesses[0].Copy());
//                 processesList.Remove(waitingProcesses[0]);
//                 waitingProcesses.Remove(waitingProcesses[0]);
//             }
//         }
//         
//         private bool giveFrame(Process process)
//         {
//             if (surplus == 0) return false;
//             surplus--;
//
//             if (freezedProcesses.Count > 0)
//             {
//                 freezedProcesses[0].Frames.Add(new Frame(freezedProcesses[0].Frames.Count));
//
//                 // is time to unfreeze?
//                 if (freezedProcesses[0].Frames.Count >
//                     (int)(proportion(freezedProcesses[0].id, total()) * CONST.Frames))
//                 {
//                     processesList.Add(freezedProcesses[0]);
//                     freezedProcesses.Remove(freezedProcesses[0]);
//                 }
//
//                 return false;
//             }
//
//             process.Frames.Add(new Frame(process.Frames.Count));
//
//             return true;
//         }
//     }
// }