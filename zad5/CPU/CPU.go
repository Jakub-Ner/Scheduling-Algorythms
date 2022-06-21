package CPU

import (
	"math"
	"zad5/CONST"
)

type CPU struct {
	Traffic   float64 // 0.0 - 1.0
	Processes []Process
}
type MultiCoreProcessor struct {
	CPUs *[CONST.CPUNum]CPU
}

func NewMultiCoreProcessor() *MultiCoreProcessor {
	var cpus [CONST.CPUNum]CPU
	return &MultiCoreProcessor{&cpus}

}
func (cpus *MultiCoreProcessor) Execute() *MultiCoreProcessor {
	for i, _ := range cpus.CPUs {
		cpus.CPUs[i] = *cpus.CPUs[i].execute()
	}
	return cpus
}

func (CPU *CPU) execute() *CPU {
	for i := 0; i < len(CPU.Processes); i++ {
		CPU.Processes[i].Duration--

		if CPU.Processes[i].Duration <= 0 {
			CPU.Traffic -= CPU.Processes[i].Weight
			CPU.Processes = append(CPU.Processes[:i], CPU.Processes[i+1:]...)
			i--
		}
	}
	return CPU
}

func (CPU *CPU) SetTraffic(p Process) bool {
	if CPU.Traffic+p.Weight > 1.0 {
		return false
	}

	CPU.Processes = append(CPU.Processes, p)
	CPU.Traffic += p.Weight
	return true
}

func (cpus *MultiCoreProcessor) GetMeanTraffic() (float64, float64) {
	suma := 0.0
	for _, cpu := range cpus.CPUs {
		suma += cpu.Traffic
	}
	mean := suma / CONST.CPUNum
	stdev := 0.0

	for _, cpu := range cpus.CPUs {
		stdev += math.Pow(mean-cpu.Traffic, 2)
	}
	stdev = math.Sqrt(stdev / CONST.CPUNum)
	return mean, stdev
}
