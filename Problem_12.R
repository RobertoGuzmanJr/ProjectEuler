#Problem 12: Highly Divisible Triangular Number
#A function that checks whether a given input is prime.
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

#A function to compute the number of divisors of a given number.
numDivisors <- function(N)
{
	if (IsPrime(N))
		return (2)
	prod = 1
	currentValue = N
	currentPrime = 2
	powerValue = 1

	while (currentValue > 1)
	{
		if (IsPrime(currentPrime) && currentValue %% currentPrime == 0)
		{
			currentValue = currentValue / currentPrime
			powerValue = powerValue + 1
		}
		else
		{
			currentPrime = currentPrime + 1
			prod = prod*(powerValue)
			powerValue = 1
		}
	}

	return (prod*powerValue)
}

MaxDivs = 2
Result = 3
n = 3

while (MaxDivs < 500)
{
	tri = n*(n+1)/2
	numDivs = numDivisors(tri)

	if (numDivs > MaxDivs)
	{
		MaxDivs = numDivs
		Result = tri
		print(MaxDivs)
	}

	n = n + 1
}

MaxDivs
Result
