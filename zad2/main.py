from random import random, randint, gauss
import math

from CONSTANTS import *
from Process import Process
from FCFS import FCFS

FCFS = FCFS()
number_all_of_processes = 0
time = 0


def add_new_processes(iteration):
    global number_all_of_processes

    if random() > 0.8:
        number_of_new_processes = int(abs(gauss(int(math.sqrt(N - iteration)), 30)))
        number_all_of_processes += number_of_new_processes

        for j in range(number_of_new_processes):
            location = randint(0, SIZE)
            FCFS.list_of_processes["new"].append(Process(time, location))


if __name__ == '__main__':

    for i in range(1, N):
        FCFS.run(time)
        time += 1
        add_new_processes(i)

    while FCFS.run(time):
        time += 1

    import pandas as pd

    print(FCFS)
