from .SCAN import SCAN


class FD_SCAN(SCAN):
    def __init__(self):
        super().__init__()
        self.current_priority = None
        self.list_of_processes.update({"priority": {"waiting": [], "old": [], "new": []}})

    def find_current(self):
        self.sort(self.list_of_processes["waiting"], self.list_of_processes["new"])

        if self.list_of_processes["priority"]["new"]:
            self.sort(self.list_of_processes["priority"]["waiting"], self.list_of_processes["priority"]["new"])

            if self.list_of_processes["priority"]["waiting"]:
                self.current_priority = self.list_of_processes["priority"]["waiting"][0]
                return True

        if self.list_of_processes["waiting"]:
            self.current = self.list_of_processes["waiting"][0]
            return True
        else:
            return False

    def move(self):
        if self.current_priority and self.current_priority.location == self.location:
            self.current.execute(0)  # <-change
            self.list_of_processes["priority"]["old"].append(self.current_priority)
            self.current_priority = None
        else:
            super().move()

        trash = []
        for process in self.list_of_processes["priority"]["waiting"]:
            process.expiration_time -= 1

            if process.expiration_time < 0:
                self.unhandled_processes += 1
                self.list_of_processes["priority"]["old"].append(process)
                trash.append(process)

        for t in trash:
            self.list_of_processes["priority"]["waiting"].remove(t)

    def sort(self, list, new_list):
        # bubble sort
        for i in range(len(list) - 1):
            for j in range(len(list) - 1 - i):
                if abs(list[j].location - self.location) > abs(list[j + 1].location - self.location):
                    list[j], list[j + 1] = list[j + 1], list[j]

        super().sort(list, new_list)
