#Problem 20: Factorial Digit Sum
number <- (1:200)*0
upperLimit = 100
number[200] = 1
currentNumber = 2
temp = 0
carry = 0

while (currentNumber < upperLimit)
{
	if (currentNumber < 10)
	{
		for (i in 200:1)
		{
			temp = number[i] * currentNumber + carry
			number[i] = temp %% 10
			carry = (temp - number[i]) / 10			
		}
	}
	else
	{
		number_ones = number
		number_tens = number
		for (i in 1:199)
		{
			number_tens[i] = number_tens[i+1]
		}
		number_tens[200] = 0
	
		#do the same thing as above, for ones digit
		ones = currentNumber %% 10
		for (i in 200:1)
		{
			temp = number_ones[i] * ones + carry
			number_ones[i] = temp %% 10
			carry = (temp - number_ones[i]) / 10			
		}
		carry = 0
		temp = 0
		
		#do the same thing as above, for tens digit, except start one digit to left
		tens = (currentNumber - (currentNumber %% 10)) / 10
		for (i in 200:1)
		{
			temp = number_tens[i] * tens + carry
			number_tens[i] = temp %% 10
			carry = (temp - number_tens[i]) / 10
		}
		carry = 0
		temp = 0

		for (j in 200:1)
		{
			if (j==200)
				temp = number_ones[j]
			else
				temp = number_ones[j] + number_tens[j] + carry
			number[j] = temp %% 10
			carry = (temp - temp %% 10) / 10
		}
	}
	carry = 0
	temp = 0
	currentNumber = currentNumber + 1
}

number
factorial(upperLimit-1)
sum(number)
