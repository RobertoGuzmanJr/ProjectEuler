#Problem 41: Pandigital Primes
#A function that checks whether a given input is prime.
library(gtools)
IsPrime <- function (N)
{
	if (N == 1)
		return (FALSE)
	
	if (N == 2 || N == 3)
		return (TRUE)

	if (N %% 2 == 0 || N %% 3 == 0)
		return (FALSE)

	Start = 5
	Stop = ceiling(sqrt(N))

	while (Start <= Stop)
	{
		if (N %% Start == 0)
			return (FALSE)

		Start = Start + 2
	}

	return (TRUE)
}

#input is the number of digits, and the result is an array 
#with all the combinations of digits
PandigitalGenerate <- function (n)
{
	output <- matrix(nrow = factorial(n),ncol = 1)
	data <- permutations(n,n,set=TRUE, repeats.allowed=FALSE)

	for (i in 1:dim(data)[1])
	{
		for (j in 1:dim(data)[2])
		{
			if (j == 1)
				value = data[i,j]*(10^(n-j))
			else
				value = value + data[i,j]*(10^(n-j))
		}

		output[i] = value
	}

	return (output)
}

#find the largest pandigitalPrime
start = 9
largest = 0
currentPos = 0
	
while (largest == 0 && start > 0)
{
	pan = PandigitalGenerate(start)
	currentPos = length(pan)
	while (currentPos > 0 && largest == 0)
	{
		value = pan[currentPos]
			
		if (IsPrime(value))
			largest = value
		currentPos = currentPos - 1
	}

	start = start - 1
}
largest

