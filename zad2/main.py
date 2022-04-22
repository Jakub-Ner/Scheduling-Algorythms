from random import random, randint, gauss
import math

from CONSTANTS import *
from Process import Process
from FCFS import FCFS
from SSTF import SSTF
from SCAN import SCAN
from C_SCAN import C_SCAN

FCFS = FCFS()
SSTF = SSTF()
SCAN = SCAN()
C_SCAN = C_SCAN()

number_all_of_processes = 0
time = 0


def add_new_processes(iteration):
    global number_all_of_processes

    if random() > 0.99:
        number_of_new_processes = int(gauss(10, 3))
        number_all_of_processes += number_of_new_processes

        for j in range(number_of_new_processes):
            location = randint(0, SIZE)
            FCFS.list_of_processes["waiting"].append(Process(time, location))
            SSTF.list_of_processes["new"].append(Process(time, location))
            SCAN.list_of_processes["new"].append(Process(time, location))
            C_SCAN.list_of_processes["new"].append(Process(time, location))


for location in [98, 183, 37, 122, 14, 124, 65, 67]:
    FCFS.list_of_processes["waiting"].append(Process(time, location))
    SSTF.list_of_processes["new"].append(Process(time, location))
    SCAN.list_of_processes["new"].append(Process(time, location))
    C_SCAN.list_of_processes["new"].append(Process(time, location))

if __name__ == '__main__':

    for i in range(1, N):
        # FCFS.run(time)
        # SSTF.run(time)
        SCAN.run(time)
        time += 1
        # add_new_processes(i)
        # C_SCAN.run(time)

    # temp = time
    # while FCFS.run(time):
    #     time += 1
    #
    # time = temp
    # while SSTF.run(time):
    #     time += 1
    #
    # time = temp
    while SCAN.run(time):
        time += 1

        # time = temp
    # while C_SCAN.run(time):
    #     time += 1


    print("number of processes: ", len(C_SCAN.list_of_processes["old"]))
    # print(FCFS)
    # print(SSTF)
    # print(SCAN)
    print(C_SCAN)