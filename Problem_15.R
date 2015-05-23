#Problem 15: Lattice Paths
PathCounter <- function(M,N)
{
	total = 0
	if (M == 0 || N == 0)
		total = total + 1
	else if (!is.na(squares[M,N]))
		total = total + squares[M,N]
	else
		total = total + PathCounter(M-1,N) + PathCounter(M,N-1)
	return (total)
}

squares <- matrix(ncol = 20, nrow = 20)*0

for (i in 1:20)
{
	for (j in 1:20)
	{
		current = PathCounter(i,j)
		if (is.na(squares[i,j]))
			squares[i,j] = current
		print (i)
		print (j)
	}
}
squares[20,20]
