#76: Counting Summations
Pentagonal <- function(n) {return(n*(3*n-1)/2)}

#By Euler's Pentagonal Number Theorem, we have that:
#
#	P(n) = P(n - p_1) + P(n - p_2) - P(n - p_3) - P(n - p_4)...
#	P(n) = SUM(k != 0) (-1)^(k-1)*P(n - p_k)
# where p_k is the kth pentagonal number

Upper = 101 #index starts at 0, so we need to assume that results[1] is the number of ways to write 0, so we go to 101.
results = (1:Upper)*0
results[1] = 1

for(i in 2:Upper)
{
	k = 1
	S = 0
	while(i - Pentagonal(k) > 0)
	{
		S = S + ((-1)^(k-1))*results[i-Pentagonal(k)]
		if(k < 0) {k = (-1*k) + 1}
		else {k = -1*k}
	}
	results[i] = S	
}

results[101] - 1	#subtract 1 since one of these is illegal (100 by itself).
