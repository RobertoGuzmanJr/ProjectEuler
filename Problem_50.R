Sieve <- function(N)
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

upperLimit = 1000000
primes = Sieve(upperLimit)
p_max = primes[length(primes)]
q_max = which(primes == primes[primes > ((p_max + 1)/2)][1])

###variables used to track the best solution
longestSequence = 0
bestPrime = 0
longestStart = 0

for(i in 1:q_max)
{
	currentTotal = primes[i]
	currentSequenceLength = 1
	currentIndex = i
	while(currentTotal < upperLimit)
	{
		currentIndex = currentIndex + 1
		currentTotal = currentTotal + primes[currentIndex]
		currentSequenceLength = currentSequenceLength + 1
		if(currentSequenceLength > longestSequence && currentTotal %in% primes)
		{
			bestPrime = currentTotal
			longestSequence = currentSequenceLength
			longestStart = currentIndex
		}
	}
}
bestPrime
