from Disc import Disc


class FCFS(Disc):
    def __repr__(self):
        print("--- FCFS ---")
        print("total distance: ", self.distance)
        Disc.__repr__(self)
        return " "

    def find_current(self):
        self.current = self.list_of_processes["waiting"][0]

    def move(self):
        if self.current.location > self.location:
            self.location += 1
        elif self.current.location < self.location:
            self.location -= 1

    def has_next(self):
        if not self.list_of_processes["waiting"]:
            return False
        return True
