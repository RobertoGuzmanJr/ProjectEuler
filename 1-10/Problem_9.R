#Problem 9: Special Pythagorean Triplet
#Find a pythagorean triplet such that a^2 + b^2 = c^2 and a+b+c = N. Return a*b*c.
Main <- function (N)
{
	for (A in 1:N)
	{
		B = (N^2 - 2*N*A)/(2*N-2*A)
		C = N - A - B
			
		if ((A^2 + B^2 == C^2) && A != 0 && B != 0 && C != 0 && A%%1==0 && B%%1==0 && C%%1==0)
			return (A*B*C)
	}
}
Main(1000)
