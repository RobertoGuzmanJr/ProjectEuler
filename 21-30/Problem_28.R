#Problem 28: Number Spiral Diagonals
maxLevel = 1001
totalSum = 1
currentLevel = 3

while (currentLevel <= maxLevel)
{
	totalSum = totalSum + 4*currentLevel^2 - 6*currentLevel + 6
	currentLevel = currentLevel + 2
}

totalSum
