#Problem 16: Power Digit Sum

number = (1:303)*0
number[303] = 1
carry = 0

for (i in 1:1000)
{
	for (j in 303:1)
	{
		if (number[j] == 0 && carry > 0)
		{
			number[j] = carry
			carry = 0
		}
		else if (number[j]*2 + carry >= 10)
		{
			number[j] = (number[j]*2 + carry) %% 10
			carry = 1
		}
		else
		{
			number[j] = number[j]*2 + carry
			carry = 0
		}
	}
}
sum(number)
