#Problem 40: Champernowne's constant
nthDigit <- function (n)
{
	total = 0
	currentNum = 1

	while (total < n)
	{
		total = total + floor(log10(currentNum)) + 1
		currentNum = currentNum + 1
	}
	
	if (total - n == 0)
		return ((currentNum - 1) %% 10)
	else
	{
		numDigits = floor(log10(currentNum)) + 1
		ordinalDigit = numDigits - (total - n)
		return ((currentNum %/% (10^(numDigits - ordinalDigit)) %% 10))
	}
}

product = 1

for (i in 0:6)
	product = product * nthDigit(10^i)

product
