#Problem 205: Dice Game
probCalc <- function (k,s,n)
{
	if (k < n)
		return (0)
	total = 0
	max = floor((k-n)/s)
	for (i in 0:max)
	{
		total = total + ((-1)^i)*(choose(n,i))*(choose(k-s*i-1,n-1))
	}
	return (total / s^n)
}

totalProb = 0

for (j in 9:36)
{
	for (k in 6:36)
	{
		if (k < j)
			totalProb = totalProb + probCalc(j,4,9)*probCalc(k,6,6)
	}
}

totalProb
