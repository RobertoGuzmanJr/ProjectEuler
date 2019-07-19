#PROBLEM #75
#a = k*(m^2 - n^2)
#b = k*2*m*n
#c = k*(m^2 + n^2)

#where m > n > 0

#primitive <--> m and n are coprime and both not odd

gcd <- function(x,y) {
  r <- x%%y;
  return(ifelse(r, gcd(y, r), y))
}

perimeter_max = 1500000
lengths = c(1:perimeter_max)*0
upper_limit = sqrt(perimeter_max/2)

m = 2
n = 0

while(m < upper_limit)
{
	#if even, start n to odd
	if(m %% 2 == 0)
	{
		n = 1
	}
	#if odd, start n to even
	else
	{
		n = 2
	}
	while(n < m)
	{
		#m and n need to be coprime
		if(gcd(m,n) == 1)
		{
			A = m^2 - n^2
			B = 2*m*n
			C = m^2 + n^2 
			perimeter = A + B + C
			while(perimeter <= perimeter_max)
			{
				lengths[perimeter] = lengths[perimeter] + 1
				perimeter = perimeter + (A+B+C)
			}
		}
		n = n + 2
	}
	m = m + 1
}
length(lengths[lengths == 1])
