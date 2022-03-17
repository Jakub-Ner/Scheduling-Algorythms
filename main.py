import math

from Process import Process, random, N
from FCFS import FCFS
from SJF import SJF
from RR import RR

FCFS = FCFS()
SJF = SJF()
RR = RR()

processes_FCFS = FCFS.processes
processes_SJF = SJF.processes
processes_RR = RR.processes


def add_new_processes(iteration):
    global processes_FCFS
    global processes_SJF
    global processes_RR

    if random.random() > 0.8:
        number_of_new_processes = int(abs(random.gauss(int(math.sqrt(N - iteration)), 30)))
        for i in range(number_of_new_processes):
            new_processes = Process(iteration)
            processes_FCFS.append(new_processes)

            processes_SJF["new"].append(new_processes.copy())
            processes_SJF["new"][- 1].arrival_time = SJF.time[0]

            processes_RR.append(new_processes.copy())
            processes_RR[-1].arrival_time = RR.time[0]


def max_execution_time(list):
    maxi = 0
    for element in list:
        if maxi < element.execution_time_archive:
            maxi = element.execution_time_archive
    return round(maxi, 2)


def max_waiting_time(list):
    maxi = 0
    for element in list:
        if maxi < element.waiting_time:
            maxi = element.waiting_time
    return round(maxi, 2)


def mean_waiting_time(list):
    mean = 0
    for element in list:
        mean += element.waiting_time
    return round(mean / len(list), 2)


if __name__ == '__main__':

    for i in range(1, N):
        FCFS.time[0] += 1
        SJF.time[0] += 1
        RR.time[0] += 1

        add_new_processes(i)

        FCFS.run()
        SJF.run()
        RR.run()

    if len(processes_FCFS) > 0:
        while processes_FCFS[len(processes_FCFS) - 1].status != "terminated":
            FCFS.time[0] += 1
            FCFS.run()

    while len(processes_SJF["current"]) > 0:
        SJF.time[0] += 1
        SJF.run()

    RR.time[0] += 1
    while RR.run():
        RR.time[0] += 1

    processes_SJF = SJF.terminated_processes

    print("\nTotal number of processes: ", len(processes_FCFS))
    print("maxi execution time: ", max_execution_time(processes_SJF))

    print("\nFCFS:")
    print("maxi waiting time : ", max_waiting_time(processes_FCFS))
    print("mean waiting time : ", mean_waiting_time(processes_FCFS))

    print("\nSJF:")
    print("maxi waiting time : ", int(max_waiting_time(processes_SJF)))
    print("mean waiting time : ", int(mean_waiting_time(processes_SJF)))

    print("\nRR:")
    print("maxi waiting time : ", int(max_waiting_time(processes_RR)))
    print("mean waiting time : ", int(mean_waiting_time(processes_RR)))
