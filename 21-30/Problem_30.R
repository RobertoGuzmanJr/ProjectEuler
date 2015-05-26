#Problem #30: Digit Fifth Powers
nums <- (1:100)*0
numDigits = 1
placeHolder <- (1:6)*0
currentPos = 1

for (i in 1:354294)
{
	numDigits = floor(log10(i))+1
	for (j in 1: numDigits)
	{
		placeHolder[1+(numDigits-j)] = i %% 10^(j) %/% 10^(j-1) 	
	}
	placeHolder = placeHolder^5

	if (sum(placeHolder) == i)
	{
		nums[currentPos] = i
		currentPos = currentPos + 1
	}
}

sum(nums) - 1
