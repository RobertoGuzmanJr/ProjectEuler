#load the data and prepare our triangle
dat <- read.table("C:/Users/Roberto/Desktop/triangle.txt",sep="\t")
m <- as.matrix(dat)
numerical = matrix(ncol = 100,nrow = 100)
for(i in 1:dim(m)[1])
{
	row = m[i,]
	j = 1
	currentRow = 1
	while(currentRow <= i)
	{
		numerical[i,currentRow] = as.numeric(substr(row,j,j+1))
		j = j + 3
		currentRow = currentRow + 1
	}	
}

numerical[is.na(numerical)] <- 0

#now for each row, we want to collapse it into the previous row
for(r in 100:2)
{
	for(c in 1:100)
	{
		if(numerical[r-1,c] == 0)
		{
			break
		}
		numerical[r-1,c] = numerical[r-1,c] + max(numerical[r,c],numerical[r,c+1])
	}
}
numerical[1,1]
