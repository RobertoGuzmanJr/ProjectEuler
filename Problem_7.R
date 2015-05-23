#Problem 7: 10,001st Prime
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

N = 10001
counter = 1
currentNum = 2

while (counter < N)
{
	currentNum = currentNum + 1
	if (IsPrime(currentNum) == TRUE)
	{
		counter = counter + 1
	}
}	
currentNum	
