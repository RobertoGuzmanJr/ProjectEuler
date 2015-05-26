#Problem 25: 1000 Digit Fibonacci Number
ptm <- proc.time()
D = 1000
array_2 = (1:D)*0
array_1 = (1:D)*0
N = 2
array_2[D] = 1
array_1[D] = 1

while (array_2[1] == 0)
{
	array_0 = array_2
	carry = 0
	for (i in D:1)
	{
		k = (array_2[i] + array_1[i] + carry) %% 10
		carry = (array_2[i] + array_1[i] + carry) %/% 10
		array_2[i] = k
	}
	N = N + 1
	array_1 = array_0
}
N
ftm <- proc.time() - ptm
ftm
