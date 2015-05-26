library(gtools)

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

GeneratePrimeCombinations <- function(I)
{
	perms = c("a","b","c","d")
	perms[1] = paste(perms[1],as.character(I %% 10),sep="")
	perms[2] = paste(perms[2],as.character(floor(I/10) %% 10),sep="")
	perms[3] = paste(perms[3],as.character(floor(I/100) %% 10),sep="")
	perms[4] = paste(perms[4],as.character(floor(I/1000) %% 10),sep="")	
	l = permutations(4,4,v = perms)
	result = c()
	for(i in 1:dim(l)[1])
	{
		result = c(result,as.numeric(paste(substr(l[i,1],2,2),substr(l[i,2],2,2),substr(l[i,3],2,2),substr(l[i,4],2,2),sep="")))
	}
	return (result)
}

CheckIncreasingCondition <- function(UniquePrimeList)
{
	n = length(UniquePrimeList)
	M = matrix(ncol = 3,nrow = n*(n-1)/2)
	current = 1
	for(i in 1:n)
	{
		for(j in i:n)
		{
			if(i != j)
			{
				M[current,1] = UniquePrimeList[i]
				M[current,2] = UniquePrimeList[j]
				M[current,3] = UniquePrimeList[j] - UniquePrimeList[i]
				current = current + 1
			}
		}
	}
	M_ordered = M[order(M[,3]),]

	currentDiff = M_ordered[1,3]
	nums = c()
	for(k in 2:dim(M_ordered)[1])
	{
		if(currentDiff == M_ordered[k,3])
		{
			if(M_ordered[k,1] == M_ordered[k-1,2])
			{
				nums = c(nums,M_ordered[k-1,1],M_ordered[k,1],M_ordered[k,2])
				break
			}
		}
		else
		{
			currentDiff = M_ordered[k,3]
		}
	}
	return(nums)
}

Primes = Sieve(10000)
Primes = Primes[Primes > 1000]
Finals = c()

for(i in 1:length(Primes))
{
	PrimeList = c()
	x = Primes[i]
	s = GeneratePrimeCombinations(x)
	for (j in 1:length(s))
	{
		if(is.element(s[j],Primes))
		{
			PrimeList = c(PrimeList,s[j])
		}
	}
	sorted = sort(unique(PrimeList))
	if(length(sorted) > 2)
	{
		f = CheckIncreasingCondition(sorted)
	}
	Finals = c(Finals,f)
}
unique(Finals)
