package Algorithm

import (
	"zad5/CONST"
	"zad5/CPU"
	"zad5/Display"
)

type helping struct {
	MCP         *CPU.MultiCoreProcessor
	Time        chan int
	processes   chan *CPU.Process
	waitingList *chan int
	name        string
	askNum      int
}

func NewHelping(p chan *CPU.Process, waitingList *chan int, name string) *helping {
	Algorithm := helping{
		MCP:         CPU.NewMultiCoreProcessor(),
		Time:        make(chan int, 3),
		processes:   p,
		waitingList: waitingList,
		name:        name,
	}

	return &Algorithm
}

func (l *helping) Tick() {
	stdout := Display.GetStdout()
	mean, sdev := l.MCP.GetMeanTraffic()
	stdout.SendStats(mean, sdev, l.askNum)

	l.Time <- 1
}
func (l *helping) Wait() {
	l.MCP = l.MCP.Execute()

	//time.Sleep(10 * time.Microsecond)
	*l.waitingList <- 1
	<-l.Time
}

func (l *helping) Manage() {
	p := <-l.processes
	if p == nil {
		return
	}

	cpu := &l.MCP.CPUs[p.BirthPlace]
	if cpu.SetTraffic(*p) {
		if cpu.Traffic < CONST.R {
			if i, ok := Find(l.MCP.CPUs, *p); !ok {
				l.askNum++
				tiredCpu := l.MCP.CPUs[i]
				cpu.SetTraffic(tiredCpu.Processes[0])
				tiredCpu.Processes = append(tiredCpu.Processes[:0], tiredCpu.Processes[1:]...)
			}
		}
		return
	}
	for i := 0; i < CONST.AskNum; i++ {
		l.askNum++
		if i, ok := Find(l.MCP.CPUs, *p); ok {
			l.MCP.CPUs[i].SetTraffic(*p)
		}
	}
}
