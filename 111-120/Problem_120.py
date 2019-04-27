#PROBLEM 120
from array import *

import time
start = time.time()

r = []

for a in range(3, 1001):
    RemainderSeries = [2]
    n = 1
    r_max = 2
    found = False
    while not found:
        new_r = (2 * a * n) % (a * a)
        if new_r > r_max:
            r_max = new_r
        if new_r in RemainderSeries:
            r.append(r_max)
            found = True
        else:
            RemainderSeries.append(new_r)
            n = n + 2
print(sum(r))
end = time.time()
print(end - start)
