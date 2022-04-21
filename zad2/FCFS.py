from Disc import Disc


class FCFS(Disc):
    def __repr__(self):
        print("--- FCFS ---")
        Disc.__repr__(self)

    def find_current(self):
        self.current = self.list_of_processes["new"][0]

    def move(self):
        if self.current.location > self.location:
            self.location += 1
        elif self.current.location < self.location:
            self.location -= 1
