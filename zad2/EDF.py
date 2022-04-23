from SSTF import SSTF


class EDF(SSTF):
    def __init__(self):
        super().__init__()
        self.list_of_processes.update({"priority": {"waiting": [], "old": [], "new":[]}})

    def find_current(self):
        self.sort(self.list_of_processes["waiting"], self.list_of_processes["new"])

        if self.list_of_processes["priority"]["new"]:
            self.sort(self.list_of_processes["priority"]["waiting"], self.list_of_processes["priority"]["new"])

            if self.list_of_processes["priority"]["waiting"]:
                self.current = self.list_of_processes["priority"]["waiting"][0]
                return True

        elif self.list_of_processes["waiting"]:
            self.current = self.list_of_processes["waiting"][0]
            return True
        else:
            return False

    def move(self):
        super().move()
        trash = []
        for process in self.list_of_processes["priority"]["waiting"]:
            process.expiration_time -= 1

            if process.expiration_time < 0:
                self.unhandled_processes += 1
                self.list_of_processes["priority"]["old"].append(process)

        for t in self.list_of_processes["priority"]["old"]:
            self.list_of_processes["priority"]["waiting"].remove(t)
