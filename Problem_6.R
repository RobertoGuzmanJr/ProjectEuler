#Problem 6: Sum Square Difference
#takes the sum of the first N numbers from 1 to N, and then returns the square of that sum
SumSquared <- function (N)
{
	result <- ((1 + N)*(N/2))^2
	result
}

#squares the numbers from 1 to N and then adds them together
SumSquares <- function (N)
{
	result <- (N/6)*(N+1)*(2*N+1)
	result
}

result <- SumSquared(100) - SumSquares(100)
result
