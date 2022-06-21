package CPU

import (
	"github.com/krux02/turnt-octo-wallhack/math32"
	"math/rand"
	"time"
	"zad5/CONST"
)

type Process struct {
	BirthPlace int
	Weight     float64
	Duration   int
}

func NewProcess() *Process {
	rand.Seed(time.Now().UnixNano())
	if rand.Int()%100 > 80 {
		return nil
	}
	random := rand.Float32() * 4
	tmp := float64(math32.Gauss(random))

	for tmp < 0.5 {
		tmp *= 10
	}
	pB := rand.Int() % CONST.CPUNum
	return &Process{Weight: tmp, Duration: rand.Int() % 10000, BirthPlace: pB}

}
