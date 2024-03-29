from random import random, randint, gauss

from CONSTANTS import *
from components.Process import Process
from specific_algorythms.FCFS import FCFS
from specific_algorythms.SSTF import SSTF
from specific_algorythms.SCAN import SCAN
from specific_algorythms.C_SCAN import C_SCAN
from specific_algorythms.EDF import EDF

FCFS = FCFS()
SSTF = SSTF()
SCAN = SCAN()
C_SCAN = C_SCAN()
EDF = EDF()

number_all_of_processes = 0
time = 0


def add_new_processes(iteration):
    global number_all_of_processes

    if random() > 0.98:
        number_of_new_processes = int(gauss(10, 3))
        number_all_of_processes += number_of_new_processes

        for j in range(number_of_new_processes):
            location = randint(0, SIZE)
            FCFS.list_of_processes["waiting"].append(Process(time, location))
            SSTF.list_of_processes["new"].append(Process(time, location))
            SCAN.list_of_processes["new"].append(Process(time, location))
            C_SCAN.list_of_processes["new"].append(Process(time, location))

            if random() > 0.85:
                EDF.list_of_processes["priority"]["new"].append(Process(time, location))
            else:
                EDF.list_of_processes["new"].append(Process(time, location, True))


def run():
    global time
    for i in range(1, N):
        FCFS.run(time)
        SSTF.run(time)
        SCAN.run(time)
        C_SCAN.run(time)
        EDF.run(time)

        time += 1
        add_new_processes(i)

    temp = time
    while FCFS.run(time):
        time += 1

    time = temp
    while SSTF.run(time):
        time += 1

    time = temp
    while SCAN.run(time):
        time += 1

    time = temp
    while C_SCAN.run(time):
        time += 1

    time = temp
    while EDF.run(time):
        time += 1


if __name__ == '__main__':
    run()

    print("number of processes: ", len(EDF.list_of_processes["old"]))
    print(FCFS)
    print(SSTF)
    print(SCAN)
    print(C_SCAN)
    print(EDF)
