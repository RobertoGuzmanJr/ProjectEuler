SieveOfErat <- function(N)
{
    if(N == 1) {return(1)}
    vec = c(2:N)
    primes = c()
    upper = ceiling(sqrt(N))
    current = 1
    while(vec[1] <= upper)
    {
        primes = c(primes,vec[1])
        vec = vec[vec %% vec[1] != 0]
    }
    primes = c(primes,vec)
    return(primes)
}

primes = SieveOfErat(1000000)
product = primes[1]

current = 2
while(1==1)
{
	if (product*primes[current] > 1000000) {break}
	product = product*primes[current]
	current = current + 1
}
product
