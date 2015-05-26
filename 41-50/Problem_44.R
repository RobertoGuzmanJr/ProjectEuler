NthPentagonal <- function(n)
{
	return((n*(3*n-1)/2))
}

IsPentagonal <- function(n)
{
	if(((sqrt(24*n+1)+1)/6) %% 1 == 0) {return (TRUE)}
	return(FALSE)
}

pents = c()
found = FALSE
p_k = 0
n = 1
while(!found)
{
	p_j = NthPentagonal(n)
	pents = c(pents,p_j)
	for(i in 1:n)
	{
		if(IsPentagonal(p_j - pents[i]))
		{
			if(IsPentagonal(p_j + pents[i]))
			{
				found = TRUE
				p_k = pents[i]
			}
		}
	}
	n = n + 1
}
#p_j
#p_k
D = p_j - p_k
D
