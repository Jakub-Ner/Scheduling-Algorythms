from CONSTANTS import BIAS


class SJF:
    def __init__(self):
        self.processes = {"new": [], "current": []}
        self.time = [0]
        self.terminated_processes = []

    def run(self):
        self.sort()
        self.time[0] += BIAS
        if 0 < len(self.processes["current"]):
            self.processes["current"][0].status = "active"
            if not self.processes["current"][0].execute(self.time):
                self.terminated_processes.append(self.processes["current"][0])
                self.processes["current"].pop(0)

    def sort(self):
        list = self.processes["current"]

        # condition is needed at the beginning of the simulation
        if len(list) == 0 and len(self.processes["new"]) != 0:
            list.append(self.processes["new"][0])
            self.processes["new"].pop(0)

        for new_element in self.processes["new"]:
            self.binsearch(new_element, list)
        self.processes["new"].clear()

    def binsearch(self, element, list):
        if list[0] != "active":
            # refers to the "first" iteration
            if element.execution_time_archive < list[0].execution_time_archive:
                list.insert(0, element)
                return

        else:
            if element.execution_time_archive < list[1].execution_time_archive:
                list.insert(1, element)
                return

            if element.execution_time_archive > list[-1].execution_time_archive:
                list.append(element)
                return

        start = 1
        end = len(list) - 1
        index = end // 2

        while start <= end:
            if element.execution_time_archive < list[index].execution_time_archive:
                end = index - 1
            else:
                start = index + 1
            index = (start + end) // 2

        list.insert(index + 1, element)
