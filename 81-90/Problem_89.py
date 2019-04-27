#PROBLEM 89
import time
start = time.time()

def MapLetterToValue (l):
    if l == 'M':
        return 1000
    elif l == 'D':
        return 500
    elif l == 'C':
        return 100
    elif l == 'L':
        return 50
    elif l == 'X':
        return 10
    elif l == 'V':
        return 5
    else:
        return 1

def TransformToNumber (x):
    s = 0
    end = len(x)
    i = 0

    while i < end:
        #handle the special cases
        if i < end-1 and x[i] == 'I' and x[i+1] == 'V':
            s += 4
            i += 2
        elif i < end-1 and x[i] == 'I' and x[i+1] == 'X':
            s += 9
            i += 2
        elif i < end-1 and x[i] == 'X' and x[i+1] == 'L':
            s += 40
            i += 2
        elif i < end-1 and x[i] == 'X' and x[i+1] == 'C':
            s += 90
            i += 2
        elif i < end-1 and x[i] == 'C' and x[i+1] == 'D':
            s += 400
            i += 2
        elif i < end-1 and x[i] == 'C' and x[i+1] == 'M':
            s += 900
            i += 2
        #handle the regular cases
        else:
            s += MapLetterToValue(x[i])
            i += 1
    return s

def RomanCount(x):
    c = 0

    #count the digits at the thousands place and beyond
    c += (x // 1000)
    x = x % 1000

    #count the number of characters to get the hundreds place
    if x // 100 == 9 or x // 100 == 6 or x // 100 == 4 or x // 100 == 2:
        c += 2
    elif x // 100 == 8:
        c += 4
    elif x // 100 == 7 or x // 100 == 3:
        c += 3
    elif x // 100 == 5 or x // 100 == 1:
        c += 1
    x = x % 100

    #count the number of characters to get the tens place
    if x // 10 == 9 or x // 10 == 6 or x // 10 == 4 or x // 10 == 2:
        c += 2
    elif x // 10 == 8:
        c += 4
    elif x // 10 == 7 or x // 10 == 3:
        c += 3
    elif x // 10 == 5 or x // 10 == 1:
        c += 1
    x = x % 10

    #count the number of characters to get the ones place
    if x == 9 or x == 6 or x == 4 or x == 2:
        c += 2
    elif x == 8:
        c += 4
    elif x == 7 or x == 3:
        c += 3
    elif x == 5 or x == 1:
        c += 1
    return c

f = open("C:/Users/Rob Guzman/Desktop/Personal/PE/p089_roman.txt","r")
words = f.read().split()

old_char_count = 0
new_char_count = 0

for word in words:
    old_char_count += len(word)
    new_char_count += RomanCount(TransformToNumber(word))

print(old_char_count - new_char_count)
end=time.time()
print(end-start)
