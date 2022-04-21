class Process:
    def __init__(self, arrival_time, location):
        self.location = location
        self.arrival_time = arrival_time
        self.waiting_time = 0

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


