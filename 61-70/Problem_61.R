Triangular <- function(n) {return(n*(n+1)/2)}
Square <- function(n) {return(n^2)}
Pentagonal <- function(n) {return(n*(3*n-1)/2)}
Hexagonal <- function(n) {return(n*(2*n-1))}
Heptagonal <- function(n) {return(n*(5*n-3)/2)}
Octagonal <- function(n) {return(n*(3*n-2))}
NumDigits <- function(n) {return(floor(log10(n))+1)}

Triangulars = c()
Squares = c()
Pentagonals = c()
Hexagonals = c()
Heptagonals = c()
Octagonals = c()

T_continue = TRUE
S_continue = TRUE
P_continue = TRUE
Hex_continue = TRUE
Hep_continue = TRUE
O_continue = TRUE

current = 1
while(T_continue || S_continue || P_continue
	|| Hex_continue || Hep_continue || O_continue)
{
	x_1 = Triangular(current)
	x_2 = Square(current)	
	x_3 = Pentagonal(current)
	x_4 = Hexagonal(current)
	x_5 = Heptagonal(current)
	x_6 = Octagonal(current)
	
	if(NumDigits(x_1) < 5) {if(NumDigits(x_1) == 4) Triangulars = c(Triangulars,x_1)}
	else {T_continue = FALSE}

	if(NumDigits(x_2) < 5) {if(NumDigits(x_2) == 4) Squares = c(Squares,x_2)}
	else {S_continue = FALSE}

	if(NumDigits(x_3) < 5) {if(NumDigits(x_3) == 4) Pentagonals = c(Pentagonals,x_3)}
	else {P_continue = FALSE}

	if(NumDigits(x_4) < 5) {if(NumDigits(x_4) == 4) Hexagonals = c(Hexagonals,x_4)}
	else {Hex_continue = FALSE}

	if(NumDigits(x_5) < 5) {if(NumDigits(x_5) == 4) Heptagonals = c(Heptagonals ,x_5)}
	else {Hep_continue = FALSE}

	if(NumDigits(x_6) < 5) {if(NumDigits(x_6) == 4) Octagonals = c(Octagonals,x_6)}
	else {O_continue = FALSE}

	current = current + 1
}

x = sort(unique(union(Octagonals,union(Heptagonals,union(Hexagonals,union(Pentagonals,union(Triangulars,Squares)))))))

finals = matrix(ncol = 6,nrow = length(x))
index = 1
for(i1 in 1:length(x))
{
	for(i2 in 1:length(x))
	{
		if((x[i1] %% 100) == floor(x[i2] / 100))
		{
			for(i3 in 1:length(x))
			{
				if((x[i2] %% 100) == floor(x[i3] / 100))
				{
					for(i4 in 1:length(x))
					{
						if((x[i3] %% 100) == floor(x[i4] / 100))
						{
							for(i5 in 1:length(x))
							{
								if((x[i4] %% 100) == floor(x[i5] / 100))
								{
									for(i6 in 1:length(x))
									{
										if((x[i5] %% 100) == floor(x[i6] / 100))
										{
											if((x[i6] %% 100) == floor(x[i1] / 100))
											{
												f = c(x[i1],x[i2],x[i3],x[i4],x[i5],x[i6])
												if(length(intersect(f,Triangulars)) >= 1 && length(intersect(f,Squares)) >= 1 && length(intersect(f,Pentagonals)) >= 1 &&
													length(intersect(f,Hexagonals)) >= 1 && length(intersect(f,Heptagonals)) >= 1 && length(intersect(f,Octagonals)) >= 1)
												{
													finals[index,] = c(x[i1],x[i2],x[i3],x[i4],x[i5],x[i6])
													index = index + 1
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	
	}
}

finals_types = matrix(ncol = 6,nrow = nrow(finals))
#now for each row, we need to check whether there is one of each of these things.
for(i in 1:nrow(finals))
{
	v = c("","","","","","")
	for(j in 1:ncol(finals))
	{
		if(is.element(finals[i,j],Triangulars)) {v[j] = paste(v[j],"T",sep="")}
		if(is.element(finals[i,j],Squares)) {v[j] = paste(v[j],"S",sep="")}
		if(is.element(finals[i,j],Pentagonals)) {v[j] = paste(v[j],"P",sep="")}
		if(is.element(finals[i,j],Hexagonals)) {v[j] = paste(v[j],"X",sep="")}
		if(is.element(finals[i,j],Heptagonals)) {v[j] = paste(v[j],"H",sep="")}
		if(is.element(finals[i,j],Octagonals)) {v[j] = paste(v[j],"O",sep="")}
	}
	finals_types[i,] = v
}

finals_types
sum(finals[5,])	#found this by manual inspection






