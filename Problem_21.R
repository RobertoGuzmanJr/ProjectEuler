#Problem 21: Amicable Numbers
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

CreateProperFactorList <- function (n,primes)
{
	FactorList <- c(1)
	residue = n
	current = 1
	while(residue > 1)
	{
		if (residue %% primes[current] == 0)
		{
			NewFactors = primes[current]*FactorList
			FactorList <- c(NewFactors,FactorList,primes[current])
			residue = residue / primes[current]
		}
		else
		{
			current = current + 1
		}
	}
	return(unique(FactorList))
}

N = 10000
primes = Sieve(5*N)
nums = (1:N)*0

for (i in 1:N)
{
	if (nums[i] == 0)
	{
		amic1 = sum(CreateProperFactorList(i,primes)) - i
		amic2 = sum(CreateProperFactorList(amic1,primes)) - amic1
		if (amic2 == i && amic1 != amic2)
		{
			nums[i] = 1
			nums[amic1] = 1
		}
	}
}
which(nums %in% 1)
sum(which(nums %in% 1))-1
