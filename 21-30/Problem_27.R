#Problem 27: Quadratic Primes
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

numSols = 0
currentStreak = 0
finalA = 0
finalB = 0
b = -999
a = -999
sol = 0
n = 0
End = FALSE

while (b < 1000)
{
	if (IsPrime(abs(b)))
	{
		a = -999
		while(a < 1000)
		{
			n = 0

			while (End == FALSE)
			{
				sol = n^2 + a*n + b
				
				if (IsPrime(abs(sol)) == FALSE)
				{
					End = TRUE
				}
	
				if (End == FALSE)
				{
					currentStreak = currentStreak + 1
					n = n + 1
				}
			}

			if (currentStreak > numSols)
			{
				numSols = currentStreak
				finalA = a
				finalB = b
			}
			currentStreak = 0
			End = FALSE
			a = a + 2
		}
	}
	b = b + 2
}
finalA*finalB
