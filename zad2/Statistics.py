import matplotlib.pyplot as plt
import pandas as pd
import numpy as np
import seaborn as sns

sns.set()


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


def display_histplot(list):
    n = 1
    waiting_list = [value.waiting_time for value in list]
    location_list = [value.location for value in list]

    f, axs = plt.subplots(n, 2, figsize=(18, n * 5))
    sns.histplot(data=waiting_list, ax=axs[0])
    axs[0].set_xlabel("waiting time")

    plt.scatter(location_list, waiting_list)
    axs[1].set_xlabel("location")
    axs[1].set_ylabel("waiting time")

    plt.show()
