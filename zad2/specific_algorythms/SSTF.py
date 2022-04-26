from ..components.Disc import Disc


class SSTF(Disc):
    def __init__(self):
        super().__init__()
        self.list_of_processes.update({"new": []})

    def has_next(self):
        if not (self.list_of_processes["waiting"] or self.list_of_processes["new"]):
            return False
        return True

    def find_current(self):
        self.sort(self.list_of_processes["waiting"], self.list_of_processes["new"])
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

    def sort(self, list, new_list, comparator=None):
        if comparator is None:
            comparator = lambda x: x.location - self.location

        for new_element in new_list:
            self.binsearch(new_element, list, comparator)
        new_list.clear()

    def binsearch(self, element, list, comparator):
        start = 0
        end = len(list) - 1
        index = end // 2

        while start <= end:
            if abs(comparator(element)) < abs(comparator(list[index])):
                end = index - 1
            else:
                start = index + 1
            index = (start + end) // 2

        list.insert(index + 1, element)
