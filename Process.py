import random

from CONSTANTS import *


class Process:
    def __init__(self, arrival_time):
        self.status = ""
        self.arrival_time = arrival_time
        self.waiting_time = 0
        self.execution_time = int(abs(random.gauss(15, 15))) \
                              + (int(random.random() * 100) if random.random() > 0.9 else 1)
        self.execution_time_archive = self.execution_time

    # does the process execute?
    def execute(self, current_time):
        if self.execution_time > 0:
            self.execution_time -= 1
            return True
        else:
            self.waiting_time = current_time[0] - self.arrival_time
            current_time[0] += BIAS
            self.status = "terminated"

            return False

    def display(self):
        print(self.waiting_time)

    def copy(self):
        copy = Process(0)
        copy.status = self.status
        copy.arrival_time = self.arrival_time
        copy.waiting_time = 0
        copy.execution_time = self.execution_time
        copy.execution_time_archive = self.execution_time_archive
        return copy
