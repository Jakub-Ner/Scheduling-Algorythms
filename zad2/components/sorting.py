
def bubble_sort(self, list, new_list):
    for i in range(len(list) - 1):
        for j in range(len(list) - 1 - i):
            if abs(list[j].location - self.location) > abs(list[j + 1].location - self.location):
                list[j], list[j + 1] = list[j + 1], list[j]