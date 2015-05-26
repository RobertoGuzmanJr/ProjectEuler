#A function that checks whether a given input is prime.
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

#checks for any even digits in the number
EvenCheck <- function (N)
{
	numDigits = floor(log10(N)) + 1

	if (numDigits == 1)
		return (N)

	digits = (1:numDigits)*0
	
	for (i in numDigits:1)
	{
		digits[numDigits-i+1] = (N %% 10^i) %/% 10^(i-1)		
	}

	even = FALSE
	for (k in 1:numDigits)
	{
		if (digits[k] %% 2 == 0)
		{
			even = TRUE
			break
		}
	}
	return(even)
}

#takes in a number and rotates the number one digit to the right
RotateRight <- function (N)
{
	numDigits = floor(log10(N)) + 1

	if (numDigits == 1)
		return (N)

	digits = (1:numDigits)*0
	
	for (i in numDigits:1)
	{
		digits[numDigits-i+1] = (N %% 10^i) %/% 10^(i-1)		
	}

	newDigits = (1:numDigits)*0
	newDigits[2:numDigits] = digits[1:numDigits-1]
	newDigits[1] = digits[numDigits]
	return (as.integer(paste(newDigits, collapse = '')))
}

#enter in a number and this will return all the circular primes below that N
startTime <- Sys.time()
N = 100
foundPrimes = (1:100)*0
foundPrimes[1] = 2
foundPrimes[2] = 3
foundPrimes[3] = 5
foundPrimes[4] = 7
place = 5
i = 11

while (i < 1000000)
{
	if (!EvenCheck(i))
	{
	print(i)
	t = floor(log10(i))+1
		if (IsPrime(i))
		{
			found = FALSE
			start = 1
			while (foundPrimes[start] != 0)
			{
				if (foundPrimes[start] == i)
					found = TRUE
				start = start + 1
			}
			
			if (found == FALSE)
			{
				temp = (1:t)*0
				counter = 0
				x = i
				for (j in 1:t)
				{
					x = RotateRight(x)
					if (IsPrime(x))
					{
						counter = counter + 1
						temp[j] = x
					}
					if (!IsPrime(x))
						break
				}
				if (counter == t)
				{
					#print (i)
					foundPrimes[(place):(place+t)] = temp[1:t]
					place = place + t
				}
			}
		}
	}
	i = i + 2
}
length(unique(foundPrimes))-1
endTime <- Sys.time()
timeTaken <- startTime - endTime
timeTaken
