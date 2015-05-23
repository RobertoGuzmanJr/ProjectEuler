#Problem 102: Triangle Containment
data <- read.table(file = "C:/Users/Roberto/Desktop/triangles.txt",header = FALSE, sep = ",")

PointTest <- function (x_1,y_1,x_2,y_2,x_test,y_test)
{
	if (x_2 == x_1 && x_2 <= 0)
		return(1)
	m = (y_2 - y_1) / (x_2 - x_1)
	b = y_2 - m*x_2

	if(sign(y_test - m*x_test - b) == sign(-b))
		return(1)
	return(0)
}

numContained = 0
numTotal = dim(data)[1]

for (i in 1:numTotal)
{
	Test1 = PointTest(data[i,1],data[i,2],data[i,3],data[i,4],data[i,5],data[i,6])
	Test2 = PointTest(data[i,1],data[i,2],data[i,5],data[i,6],data[i,3],data[i,4])
	Test3 = PointTest(data[i,3],data[i,4],data[i,5],data[i,6],data[i,1],data[i,2])

	if (Test1 + Test2 + Test3 == 3)
		numContained = numContained + 1
	print(i)
}
numContained
