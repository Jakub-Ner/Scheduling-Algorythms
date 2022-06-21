package Algorithm

import (
	"math/rand"
	"time"
	"zad5/CONST"
	"zad5/CPU"
)

type Algorithmer interface {
	Manage() // what we're gonna do
	Tick()
	Wait()
}

func Find(CPUs *[CONST.CPUNum]CPU.CPU, p CPU.Process) (int, bool) {
	rand.Seed(time.Now().UnixNano())

	index := p.BirthPlace
	for ; index == p.BirthPlace; index = rand.Int() % len(CPUs) {
	}

	if CPUs[index].Traffic > CONST.Threshold {
		return index, false
	}
	return index, true
}
