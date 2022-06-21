package Algorithm

import (
	"zad5/CONST"
	"zad5/CPU"
	"zad5/Display"
)

type lazy struct {
	MCP         *CPU.MultiCoreProcessor
	Time        chan int
	processes   chan *CPU.Process
	waitingList *chan int
	name        string
	askNum      int
}

func NewLazy(p chan *CPU.Process, waitingList *chan int, name string) *lazy {
	Algorithm := lazy{
		MCP:         CPU.NewMultiCoreProcessor(),
		Time:        make(chan int, 3),
		processes:   p,
		waitingList: waitingList,
		name:        name,
	}

	return &Algorithm
}

func (l *lazy) Tick() {
	stdout := Display.GetStdout()
	mean, sdev := l.MCP.GetMeanTraffic()
	stdout.SendStats(mean, sdev, l.askNum)

	l.Time <- 1
}
func (l *lazy) Wait() {
	l.MCP = l.MCP.Execute()

	//time.Sleep(10 * time.Microsecond)
	*l.waitingList <- 1
	<-l.Time
}

func (l *lazy) Manage() {
	p := <-l.processes
	if p == nil {
		return
	}
	done := false
	for i := 0; i < CONST.AskNum; i++ {
		l.askNum++
		if i, ok := Find(l.MCP.CPUs, *p); ok {
			l.MCP.CPUs[i].SetTraffic(*p)
			done = true
			break
		}
	}
	if !done {
		l.MCP.CPUs[p.BirthPlace].SetTraffic(*p)
	}
}
