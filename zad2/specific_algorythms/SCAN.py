from components.Disc import Disc
from CONSTANTS import SIZE


class SCAN(Disc):
    def __init__(self):
        super().__init__()
        self.direction = "left"
        self.list_of_processes.update({"new": []})

    def helper_find_current(self):
        if self.direction == "right":
            index = 1 + self.binsearch(self, self.list_of_processes["waiting"], False)
        else:
            index = self.binsearch(self, self.list_of_processes["waiting"], False)

        if index == -1: index = 0
        if index >= len(self.list_of_processes["waiting"]): index -= 1

        return self.list_of_processes["waiting"][index]

    def find_current(self):
        self.sort(self.list_of_processes["waiting"], self.list_of_processes["new"])
        if self.list_of_processes["waiting"]:
            self.current = self.helper_find_current()
            return True
        else:
            return False

    def move(self):
        if self.direction == "right":
            # check if it is turning moment
            if self.location < SIZE:
                self.location += 1
            else:
                self.direction = "left"
                self.location -= 1

        else:
            if self.location != 0:
                self.location -= 1
            else:
                self.direction = "right"
                self.location += 1

    def has_next(self):
        if not (self.list_of_processes["waiting"] or self.list_of_processes["new"]):
            return False
        return True

    def sort(self, list, new_list):
        for new_element in new_list:
            self.binsearch(new_element, list)
        new_list.clear()

    def binsearch(self, element, list, insert=True):
        start = 0
        end = len(list) - 1
        index = end // 2

        while start <= end:
            if element.location < list[index].location:
                end = index - 1
            else:
                start = index + 1
            index = (start + end) // 2
        if insert:
            list.insert(index + 1, element)

        else:
            # if index == -1:
            #     index += 1

            return index
