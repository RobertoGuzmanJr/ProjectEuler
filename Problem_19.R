#Problem 19: Counting Sundays
currentDay = 6	#first Sunday is the 6th
currentMonth = 1
currentYear = 1901
numSundays = 0
leapYear = FALSE

while (currentYear < 2001)
{
	#increment the number of Sundays if its the first.
	if (currentDay == 1)
		numSundays = numSundays + 1

	#move on to the next Sunday
	currentDay = currentDay + 7

	#adjust the month
	if (currentMonth == 1 && currentDay > 31)
	{
		currentDay = currentDay - 31
		currentMonth = currentMonth + 1
	}
	else if (currentMonth == 3 && currentDay > 31)
	{
		currentDay = currentDay - 31
		currentMonth = currentMonth + 1
	}
	else if (currentMonth == 4 && currentDay > 30)
	{
		currentDay = currentDay - 30
		currentMonth = currentMonth + 1
	}
	else if (currentMonth == 5 && currentDay > 31)
	{
		currentDay = currentDay - 31
		currentMonth = currentMonth + 1
	}
	else if (currentMonth == 6 && currentDay > 30)
	{
		currentDay = currentDay - 30
		currentMonth = currentMonth + 1
	}
	else if (currentMonth == 7 && currentDay > 31)
	{
		currentDay = currentDay - 31
		currentMonth = currentMonth + 1
	}
	else if (currentMonth == 8 && currentDay > 31)
	{
		currentDay = currentDay - 31
		currentMonth = currentMonth + 1
	}
	else if (currentMonth == 9 && currentDay > 30)
	{
		currentDay = currentDay - 30
		currentMonth = currentMonth + 1
	}
	else if (currentMonth == 10 && currentDay > 31)
	{
		currentDay = currentDay - 31
		currentMonth = currentMonth + 1
	}
	else if (currentMonth == 11 && currentDay > 30)
	{
		currentDay = currentDay - 30
		currentMonth = currentMonth + 1
	}
	else if (currentMonth == 2 && leapYear == TRUE && currentDay > 29)
	{
		currentDay = currentDay - 29
		currentMonth = currentMonth + 1
	}
	else if (currentMonth == 2 && leapYear == FALSE && currentDay > 28)
	{
		currentDay = currentDay - 28
		currentMonth = currentMonth + 1
	}
	else if (currentMonth == 12 && currentDay > 31)
	{
		currentDay = currentDay - 31
		currentMonth = 1
		currentYear = currentYear + 1
	}

	#determine whether it is a leap year
	if (currentYear %% 4 == 0 && currentYear %% 100 != 0)
		leapYear = TRUE
	else if (currentYear %% 4 == 0 && currentYear %% 100 == 0 && currentYear %% 400 == 0)
		leapYear = TRUE
	else
		leapYear = FALSE
}
numSundays
