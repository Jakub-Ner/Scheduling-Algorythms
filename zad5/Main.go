package main

import (
	"zad5/Algorithm"
	"zad5/CONST"
	"zad5/CPU"
	"zad5/Display"
)

func broadcast(als []Algorithm.Algorithmer, p chan *CPU.Process) {
	newProcess := CPU.NewProcess()
	for _, a := range als {
		p <- newProcess
		a.Tick()
	}
}

func run(a Algorithm.Algorithmer) {
	for {
		a.Manage()
		a.Wait() // finished? so wait for others
	}
}

func main() {
	p := make(chan *CPU.Process, 10)
	waitersNum := 3 // num of als
	waitingList := make(chan int, waitersNum)

	als := []Algorithm.Algorithmer{
		Algorithm.NewLazy(p, &waitingList, " Lazy "),
		Algorithm.NewTrying(p, &waitingList, " Trying "),
		Algorithm.NewHelping(p, &waitingList, " Helping "),
	}

	for _, a := range als {
		go run(a)
	}

	// synchronize and give them the same processes:
	var time uint64 = 1
	counter := waitersNum
	for {
		if counter == waitersNum {
			time++
			broadcast(als, p)
			counter = 0
		}
		// if sb finishes cycle go further
		<-waitingList
		counter++
		// display data
		if time%CONST.Quaint == 0 && counter == 1 {
			stdout := Display.GetStdout()
			stdout.Display(time / uint64(waitersNum))
		}
	}

}
