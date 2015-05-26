#Problem 14: Longest Collatz Sequence
maxValue = 1000000
CollatzBucket <- matrix (ncol = 2, nrow = maxValue)
CollatzBucket[,1] = (1:maxValue)
CollatzBucket[,2] = (1:maxValue)*0
currentStarter = 2
sequenceLength = 0
longestStarter = 2
longestSequenceLength = 1
value = 0
while(currentStarter < maxValue)
{
	if (CollatzBucket[currentStarter,2] == 0)
	{
		value = currentStarter
		sequenceLength = 1
		while(value > 1)
		{
			if (value %% 2 == 0)
				value = value / 2
			else
				value = 3*value + 1
			sequenceLength = sequenceLength + 1
			if (value <= maxValue)
				CollatzBucket[value,2] = 1
		}
		if (sequenceLength > longestSequenceLength)
		{
			longestStarter = currentStarter
			longestSequenceLength = sequenceLength
		}
	}
	currentStarter = currentStarter + 1
	print(currentStarter)
}
longestStarter
longestSequenceLength
