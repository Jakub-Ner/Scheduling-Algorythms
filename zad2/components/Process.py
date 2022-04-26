from random import random


class Process:
    def __init__(self, arrival_time, location, priority=False):
        self.location = location
        self.arrival_time = arrival_time
        self.waiting_time = 0
        self.expiration_time = int(random() * 100000)
        self.priority = priority

    def __repr__(self):
        return str(self)

    def __str__(self):
        return "\n" + str(self.location) + " " + str(self.arrival_time) + " " + str(self.waiting_time)

    def execute(self, current_time):
        self.waiting_time = current_time - self.arrival_time

    def copy(self):
        copy = Process(0)
        copy.arrival_time = self.arrival_time
        copy.waiting_time = 0
        return copy
