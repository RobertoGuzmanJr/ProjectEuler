#Problem #58
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

i = 0
total = 1
numPrime = 0
r = 1

while(r >= .10)
{
	i = i + 1
	LR = (2*i + 1)^2
	LL = LR - 2*i
	UL = LL - 2*i
	UR = UL - 2*i

	total = total + 4
	if(IsPrime(LL)) {numPrime = numPrime + 1}
	if(IsPrime(UL)) {numPrime = numPrime + 1}
	if(IsPrime(UR)) {numPrime = numPrime + 1}

	r = numPrime / total
	print(r)
	print(numPrime)
}

i
sqrt(LR)
