from abc import abstractmethod
from .Statistics import display_histplot


class Disc:
    def __init__(self):
        self.location = 53
        self.current = None
        self.list_of_processes = {"waiting": [], "old": []}
        self.distance = 0
        self.unhandled_processes = 0

    def __repr__(self):
        print("---", type(self).__name__, " ---")
        print("total distance: ", self.distance)
        display_histplot(self.list_of_processes["old"])
        return ""

    def run(self, time):
        # check if is current
        if self.current is None:
            if not self.has_next():
                return False

            self.find_current()
            try:
                self.list_of_processes["waiting"].remove(self.current)
            except:
                self.list_of_processes["priority"]["waiting"].remove(self.current)

        if self.current.location != self.location:
            self.move()
            self.distance += 1
        else:
            self.current.execute(time)
            self.list_of_processes["old"].append(self.current)
            self.current = None
        return True

    @abstractmethod
    def find_current(self):
        raise NotImplementedError

    @abstractmethod
    def move(self):
        raise NotImplementedError

    @abstractmethod
    def has_next(self):
        raise NotImplementedError
