#Problem 45: Triangular, Pentagonal and Hexagonal
found = FALSE
N = 144

while (found == FALSE)
{
	H = N*(2*N-1)

	T = sqrt(1+8*H)/2 - (1/2)
	P = sqrt(1+24*H)/6 + (1/6)

	if (T %% 1 == 0 && P %% 1 == 0)
		found = TRUE

	N = N + 1
}

H
