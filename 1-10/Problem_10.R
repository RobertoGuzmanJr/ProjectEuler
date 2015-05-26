#Problem 10: Summation of Primes
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

primes = SieveOfErat(2000000)
sum(as.numeric(primes))
