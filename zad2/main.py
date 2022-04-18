from random import random, randint, gauss
import math

from CONSTANTS import *

processes_FCFS = []
processes_SSTF = []
processes_SCAN = []
number_all_of_processes = 0
time = 0


def add_new_processes(iteration):
    global processes_FCFS
    global processes_SSTF
    global processes_SCAN
    global number_all_of_processes

    if random() > 0.8:
        number_of_new_processes = int(abs(gauss(int(math.sqrt(N - iteration)), 30)))
        number_all_of_processes += number_of_new_processes

        for j in range(number_of_new_processes):
            location = randint(0, SIZE)
            processes_FCFS.append(location)


if __name__ == '__main__':

    for i in range(1, N):
        time += 1
        add_new_processes(i)

        FCFS.run()
        SJF.run()
        RR.run()
