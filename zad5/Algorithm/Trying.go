package Algorithm

import (
	"zad5/CONST"
	"zad5/CPU"
	"zad5/Display"
)

type trying struct {
	MCP         *CPU.MultiCoreProcessor
	Time        chan int
	processes   chan *CPU.Process
	waitingList *chan int
	name        string
	askNum      int
}

func NewTrying(p chan *CPU.Process, waitingList *chan int, name string) *trying {
	Algorithm := trying{
		MCP:         CPU.NewMultiCoreProcessor(),
		Time:        make(chan int, 3),
		processes:   p,
		waitingList: waitingList,
		name:        name,
	}

	return &Algorithm
}

func (l *trying) Tick() {
	stdout := Display.GetStdout()
	mean, sdev := l.MCP.GetMeanTraffic()
	stdout.SendStats(mean, sdev, l.askNum)

	l.Time <- 1
}
func (l *trying) Wait() {
	l.MCP = l.MCP.Execute()

	//time.Sleep(10 * time.Microsecond)
	*l.waitingList <- 1
	<-l.Time
}

func (l *trying) Manage() {
	p := <-l.processes
	if p == nil {
		return
	}
	if l.MCP.CPUs[p.BirthPlace].SetTraffic(*p) {
		return
	}

	for i := 0; i < CONST.AskNum; i++ {
		l.askNum++
		if j, ok := Find(l.MCP.CPUs, *p); ok {
			l.MCP.CPUs[j].SetTraffic(*p)
			break
		}
	}

}
