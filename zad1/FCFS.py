from CONSTANTS import SWITCHING
class FCFS:
    def __init__(self):
        self.processes = []
        self.time = [0]
        self.i = 0

    def run(self):
        if self.i < len(self.processes):
            if not self.processes[self.i].execute(self.time):
                self.i += 1
                self.time[0] += SWITCHING
