#Problem 39: Integer Right Triangles
#Function to find out the number of integer right triangles with perimeter = p.
numTriangles <- function (p)
{
	if (p %% 2 == 1)
	{
		return (0)
	}

	a = 1
	numSols = 0	

	while (a < p-2)
	{
		b = (2*a*p - p^2)/(2*a-2*p)
		c = p - a - b

		if (b %% 1 == 0 && c %% 1 == 0 && c^2 == (a^2 + b^2) && b > 0 && c > 0)
			numSols = numSols + 1
		a = a + 1
	}

	return (numSols / 2)
}

#given N, find p such that p <= N is the perimeter for a right triangle that maximizes the total number of integer solutions to c^2 = a^2 + b^2
maximizer <- function (N)
{
	maxSol = 0
	maxP = 3

	for (i in 3:N)
	{
		numSols = numTriangles(i)

		if (numSols > maxSol)
		{		
			maxSol = numSols
			#print (maxSol)
			maxP = i
		}
	}

	return (maxP)
}
maximizer(1000)
