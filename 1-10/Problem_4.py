 #PROBLEM 4
from math import floor
import time
start = time.time()

def IsPalindrome (N):
    for i in range(0,len(N)):
        if N[i] != N[len(N)-1-i]:
            return False
    return True

def Is3DigitDivisible (N):
    if (N < 100 ** 2 | N > 999 ** 2):
        return False
    for i in range(100, 1000):
        if N % i == 0:
            M = (int)(N / i);
            if M >= 100 and M <= 999:
                return True

found = False

for i in range(997997, 10000, -11):
    if(IsPalindrome(str(i))):
        if(Is3DigitDivisible(i)):
            found = True
            result = i
            break

print(result)
end=time.time()
print(end-start)
