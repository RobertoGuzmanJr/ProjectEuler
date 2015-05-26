#Problem 42
#Enter a number and will return true if the number is triangular
IsTriangular <- function (N)
{
	k = sqrt(1+8*N)
	if (k %% 2 == 1 && k %% 1 == 0)
		return (TRUE)
	else
		return (FALSE)
}

#Converts a character sring to its ASCII components
asc <- function (x)
{
	strtoi(charToRaw(x),16L)
}

words <- scan("C:/Users/Roberto/Desktop/words.txt",what = "character",sep = ",")
numTriangulars = 0

for (i in 1:length(words))
{
	
	s = sum(asc(words[i])) - 64*nchar(words[i])
	if (IsTriangular(s))
	{
		numTriangulars = numTriangulars + 1
		#print(words[i])
	}
}
numTriangulars
