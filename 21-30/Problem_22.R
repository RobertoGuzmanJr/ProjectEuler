#Problem 22
#Converts a character sring to its ASCII components
asc <- function (x)
{
    strtoi(charToRaw(x),16L)
}

names <- scan("C:/Users/Roberto/Desktop/names.txt",what = "",sep = ",",na.strings = " ")
names <- sort(names)
nameValue = 0
totalScore = 0

for (i in 1:length(names))
{
	x = asc(names[i]) - 64
	y = sum(x)
	totalScore = totalScore + (y*i)
}
totalScore
