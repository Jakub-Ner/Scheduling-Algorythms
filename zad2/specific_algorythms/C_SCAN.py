from .SCAN import SCAN, SIZE


class C_SCAN(SCAN):
    def __init__(self):
        super().__init__()
        self.direction = "right"

    def helper_find_current(self):
        if self.direction == "right":
            index = 1 + self.binsearch(self, self.list_of_processes["waiting"], False)
        else:
            index = self.binsearch(self, self.list_of_processes["waiting"], False)

        if index == -1: index = 0
        if index >= len(self.list_of_processes["waiting"]): index = 0

        return self.list_of_processes["waiting"][index]

    def find_current(self):
        self.sort(self.list_of_processes["waiting"], self.list_of_processes["new"])
        if self.list_of_processes["waiting"]:
            self.current = self.helper_find_current()
            return True
        else:
            return False

    def move(self):
        if self.location < SIZE:
            self.location += 1
        else:
            self.location = 0
            # self.distance += SIZE
