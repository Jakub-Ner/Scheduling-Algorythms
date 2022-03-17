from FCFS import FCFS
from CONSTANTS import QUANTUM, SWITCHING


class RR(FCFS):
    def __init__(self):
        super().__init__()
        self.quantum = QUANTUM
        self.nr_of_terminated = 0

    def _round_(self, value):
        return value % len(self.processes)

    def switch(self):
        if self.quantum == 0:
            self.i += self._round_(self.i + 1)
            self.time[0] += SWITCHING
            self.quantum = QUANTUM

    def run(self):
        self.switch()
        bound = len(self.processes)
        if self.processes:
            while self.processes[self._round_(self.i)].status == "terminated":
                self.i += 1
                bound -= 1
                if bound == 0:
                    return False

        if bound > 0:
            super().run()
        return True
