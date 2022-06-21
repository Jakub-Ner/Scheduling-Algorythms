package Display

import (
	"fmt"
	"sync"
	"zad5/CONST"
)

var once sync.Once

// type global
type stdout struct {
	Stdout  chan float64
	counter uint64
	means   [3]float64
	stdevs  [3]float64
	askNum  [3]int
}

var (
	instance stdout
)

func GetStdout() *stdout {
	once.Do(func() { // <-- atomic, does not allow repeating
		instance = stdout{
			make(chan float64, 1), // <-- thread safe
			0,
			[3]float64{},
			[3]float64{},
			[3]int{},
		}

		instance.heading()
	})
	return &instance
}

func (stdout *stdout) SendStats(mean float64, stdev float64, askNum int) {
	stdout.means[stdout.counter%3] += mean
	stdout.stdevs[stdout.counter%3] += stdev
	stdout.askNum[stdout.counter%3] += askNum - stdout.askNum[stdout.counter%3]

	stdout.counter++
}

func (stdout *stdout) Display(time uint64) {
	var _HEIGHT uint64 = 30_000 // how often we should add heading
	if time%_HEIGHT == 0 {
		stdout.heading()
	}
	fmt.Printf("%23d|", time)

	for i, mean := range stdout.means {
		mean = mean / float64(CONST.Quaint)
		fmt.Printf("%7.2f|", mean)

		stdev := stdout.stdevs[i] / float64(CONST.Quaint)
		fmt.Printf("%7.2f|", stdev)

		fmt.Printf("%7d|", stdout.askNum[i])

	}
	fmt.Println()
	stdout.clear()

}
func (stdout stdout) heading() {
	fmt.Println(Blue)
	heading := [4]string{"time", "      Lazy ", "    Trying ", "    Helping "}
	for _, col := range heading {
		fmt.Printf("%-23s|", col)
	}
	fmt.Println(Reset)
}

func (stdout *stdout) clear() {
	stdout.counter = 0
	for i, _ := range stdout.means {
		stdout.means[i] = 0.0
		stdout.stdevs[i] = 0.0
		stdout.askNum[i] = 0
	}
}
