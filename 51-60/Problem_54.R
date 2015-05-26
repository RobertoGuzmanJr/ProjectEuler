#Problem 54
GenerateValues <- function (mat,rowIndex,start)
{
	returnVector = (1:5)*0
	for (i in start:(start + 4))
	{
		x = substr(mat[rowIndex,i],1,1)
		if (x == "T")
			returnVector[i-start+1] = 10
		else if (x == "J")
			returnVector[i-start+1] = 11
		else if (x == "Q")
			returnVector[i-start+1] = 12
		else if (x == "K")
			returnVector[i-start+1] = 13
		else if (x == "A")
			returnVector[i-start+1] = 14
		else
			returnVector[i-start+1] = x
	}
	return(sort(as.numeric(returnVector)))
}

GenerateSuits <- function (mat,rowIndex,start)
{
	returnVector = (1:5)*0
	for (i in start:(start + 4))
	{
		x = substr(mat[rowIndex,i],2,2)
		returnVector[i-start+1] = x
	}
	return(sort(returnVector))
}

testStraight <- function (inputVector)
{
	isStraight = TRUE
	for (i in 2:5)
	{
		if (inputVector[i] - inputVector[i-1] != 1)
		{
			isStraight = FALSE
			break
		}
	}
	return(isStraight)
}

testFlush <- function (inputVector)
{
	if (length(unique(inputVector)) == 1)
		return (TRUE)
	else
		return (FALSE)
}

testFourOfAKind <- function (inputVector)
{
	if (length(unique(inputVector)) != 2)
		return (FALSE)
	else if(inputVector[2] == inputVector[4] && inputVector[2] == inputVector[3] && inputVector[2] == inputVector[1])
	{
		return(TRUE)
	}
	else if(inputVector[2] == inputVector[4] && inputVector[2] == inputVector[3] && inputVector[2] == inputVector[5])
	{
		return (TRUE)
	}
	else
		return (FALSE)
}

testFullHouse <- function (inputVector)
{
	if (length(unique(inputVector)) > 2)
		return(FALSE)
	else if (inputVector[1] == inputVector[2] && inputVector[4] == inputVector[5] &&
			inputVector[3] == inputVector[2] && inputVector[1] != inputVector[5])
	{
		return(TRUE)
	}
	else if (inputVector[1] == inputVector[2] && inputVector[4] == inputVector[5] &&
			inputVector[3] == inputVector[4] && inputVector[1] != inputVector[5])
	{
		return (TRUE)
	}
	else
		return (FALSE)
}

testThreeOfAKind <- function (inputVector)
{
	if (length(unique(inputVector)) > 3)
		return(FALSE)
	else if (inputVector[1] == inputVector[2] && inputVector[2] == inputVector[3] &&
			inputVector[4] != inputVector[3] && inputVector[5] != inputVector[3] &&
			inputVector[4] != inputVector[5])
	{
		return(TRUE)
	}
	else if (inputVector[2] == inputVector[3] && inputVector[3] == inputVector[4] &&
			inputVector[1] != inputVector[3] && inputVector[5] != inputVector[3] &&
			inputVector[1] != inputVector[5])
	{
		return(TRUE)
	}
	else if (inputVector[3] == inputVector[4] && inputVector[4] == inputVector[5] &&
			inputVector[1] != inputVector[3] && inputVector[2] != inputVector[3] &&
			inputVector[1] != inputVector[2])
	{
		return(TRUE)
	}
	else
		return(FALSE)
}

testTwoPair <- function (inputVector)
{
	if (length(unique(inputVector)) != 3)
		return(FALSE)
	else if(inputVector[1] == inputVector[2] && inputVector[3] == inputVector[4])
	{
		return(TRUE)
	}
	else if (inputVector[1] == inputVector[2] && inputVector[4] == inputVector[5])
	{
		return(TRUE)
	}
	else if (inputVector[2] == inputVector[3] && inputVector[4] == inputVector[5])
	{
		return(TRUE)
	}
	else
		return(FALSE)		

}

testOnePair <- function (inputVector)
{
	if (length(unique(inputVector)) == 4)
		return(TRUE)
	else
		return(FALSE)
}

ComputeHandValue <- function (valueVector,suitVector)
{
	result = (1:2)*0-1

	#check for a straight flush
	if (testStraight(valueVector) && testFlush(suitVector))
	{
		result[1] = 8
		result[2] = valueVector[5]
	}
	#check for a 4 of a kind
	else if (testFourOfAKind(valueVector) && result[1] == -1)
	{
		result[1] = 7
		result[2] = valueVector[3]
	}
	#check for a full house
	else if (testFullHouse(valueVector) && result[1] == -1)
	{
		result[1] = 6
		result[2] = valueVector[3]
	}
	#check for a flush
	else if (testFlush(suitVector) && result[1] == -1)
	{
		result[1] = 5
		result[2] = valueVector[5]
	}
	#check for a straight
	else if (testStraight(valueVector) && result[1] == -1)
	{
		result[1] = 4
		result[2] = valueVector[5]
	}
	#check for a three of a kind
	else if (testThreeOfAKind(valueVector) && result == -1)
	{
		result[1] = 3
		result[2] = valueVector[3]
	}
	#check for two pairs
	else if (testTwoPair(valueVector) && result == -1)
	{
		result[1] = 2
		result[2] = max(valueVector[2],valueVector[4])
	}
	#check for one pair
	else if (testOnePair(valueVector) && result == -1)
	{
		result[1] = 1
		if (valueVector[1] == valueVector[2])
			result[2] = valueVector[1]
		else if (valueVector[2] == valueVector[3])
			result[2] = valueVector[2]
		else if (valueVector[3] == valueVector[4])
			result[2] = valueVector[3]
		else
			result[2] = valueVector[4]
	}
	#assign the high card
	else
	{
		result[1] = 0
		result[2] = valueVector[5]
	}
	return(result)
}

hands <- read.table("C:/Users/Roberto/Desktop/poker.txt",sep = " ")
hands = as.matrix(hands)
numPlayer1Wins = 0

for (i in 1:dim(hands)[1])
{
	player1Values = GenerateValues(hands,i,1)
	player2Values = GenerateValues(hands,i,6)
	player1Suits = GenerateSuits(hands,i,1)
	player2Suits = GenerateSuits(hands,i,6)
	player1Res = ComputeHandValue(player1Values,player1Suits)
	player2Res = ComputeHandValue(player2Values,player2Suits)

	if (player1Res[1] > player2Res[1])
	{
		numPlayer1Wins = numPlayer1Wins + 1
	}
	else if (player1Res[1] == player2Res[1] && player1Res[2] > player2Res[2])
	{
		numPlayer1Wins = numPlayer1Wins + 1
	}
	else if (player1Res[1] == player2Res[1] && player1Res[2] == player2Res[2])
	{
		print(i)
		settled = FALSE
		j = 5
		while (!settled)
		{
			if (player1Values[j] > player2Values[j])
			{
				settled = TRUE
				numPlayer1Wins = numPlayer1Wins + 1
			}
			if (player1Values[j] < player2Values[j])
			{
				settled = TRUE
			}
			
			j = j-1
		}
	}
}
numPlayer1Wins
