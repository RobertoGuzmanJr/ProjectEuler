n = 1
t = 0

while(n <= 100)
{
	for(r in 1:n)
	{
		if(choose(n,r) > 1000000)
		{	
			t = t + 1
		}
	}
	n = n + 1
}
t
