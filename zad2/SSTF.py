from Disc import Disc


class SSTF(Disc):
    def __init__(self):
        super().__init__()
        self.list_of_processes.update({"new": []})

    def __repr__(self):
        print("--- FCFS ---")
        print("total distance: ", self.distance)
        Disc.__repr__(self)
        return " "

    def has_next(self):
        if not (self.list_of_processes["waiting"] or self.list_of_processes["new"]):
            return False
        return True

    def find_current(self):
        self.sort()
        if self.list_of_processes["waiting"]:
            self.current = self.list_of_processes["waiting"][0]
            return True
        else:
            return False

    def move(self):
        if self.current.location > self.location:
            self.location += 1
        elif self.current.location < self.location:
            self.location = -1

    def run(self, time):
        self.should_find_current = True
        return super().run(time)

    def sort(self):
        list = self.list_of_processes["waiting"]

        for i in range(len(list) - 1):
            for j in range(len(list) - 1 - i):
                if abs(list[j].location - self.location) >  abs(list[j + 1].location - self.location):
                    list[j], list[j+1] = list[j+1], list[j]

        # condition is needed at the beginning of the simulation
        if len(list) == 0 and len(self.list_of_processes["new"]) != 0:
            list.append(self.list_of_processes["new"][0])
            self.list_of_processes["new"].pop(0)

        for new_element in self.list_of_processes["new"]:
            self.binsearch(new_element, list)
        self.list_of_processes["new"].clear()

    def binsearch(self, element, list):
        start = 0
        end = len(list) - 1
        index = end // 2

        while start <= end:
            if abs(self.location - element.location) < abs(self.location - list[index].location):
                end = index - 1
            else:
                start = index + 1
            index = (start + end) // 2

        list.insert(index + 1, element)
