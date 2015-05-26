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
 
ptm <- proc.time()
M = 600851475143
N = sqrt(M)
primes = SieveOfErat(N)
largestFact = 0
for (i in length(primes):1)
{
    if(M %% primes[i] == 0)
    {
        largestFact = primes[i]
        break
    }
}
print(largestFact)
proc.time() - ptm
