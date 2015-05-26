#Problem 47: Distinct Prime Factors
Sieve <- function (N)
{
	nums = (2:N)
	upper = ceiling(sqrt(N))
	primes = c()
	while (nums[1] <= upper)
	{
		primes = c(primes,nums[1])
		nums = nums[nums %% nums[1] != 0]
	}
	primes = c(primes,nums)
	return (primes)
}

CountDistinctFactors <- function(N,Primes)
{
	if(is.element(N,Primes))
	{
		return (1)
	}
	NumFactors = 0
	Current = 1
	while(Primes[Current] < N)
	{
		if(N %% Primes[Current] == 0)
		{
			NumFactors = NumFactors + 1
		}
		Current = Current + 1
	}
	return (NumFactors)
}

#do some initialization
N = 2*3*5*7
M = matrix(ncol = 2, nrow = 1000000)
M[1,1] = N
M[1,2] = 4

CurrentRow = 1
DistinctCount = 0
NumDistinctFactors = 4

Primes = Sieve(1000000)

while(DistinctCount < NumDistinctFactors)
{
	#if the number is not NA and not 4, we checked it. Move on
	if(!is.na(M[CurrentRow,2]) && M[CurrentRow,2] != NumDistinctFactors)
	{
		CurrentRow = CurrentRow + 1
		N = N + 1
		DistinctCount = 0
		next()
	}

	#if its NA, then we need to check it and fill it in
	if(is.na(M[CurrentRow,2]))
	{
		M[CurrentRow,2] = CountDistinctFactors(N,Primes)
	}

	#check the value of current. If it matches NumDistinctFactors, increment DistinctCount
	#otherwise, we will want to set DistinctCount to 0 and move on
	if(M[CurrentRow,2] == NumDistinctFactors)
	{
		DistinctCount = DistinctCount + 1		
	}
	else
	{
		DistinctCount = 0
	}
	N = N + 1
	CurrentRow = CurrentRow + 1
	print(N)
}
N
