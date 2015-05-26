IsPrime <- function (N)
{
	if (N == 1)
		return (FALSE)
	
	if (N == 2 || N == 3)
		return (TRUE)

	if (N %% 2 == 0 || N %% 3 == 0)
		return (FALSE)

	Start = 5
	Stop = ceiling(sqrt(N))

	while (Start <= Stop)
	{
		if (N %% Start == 0)
			return (FALSE)

		Start = Start + 2
	}

	return (TRUE)
}
