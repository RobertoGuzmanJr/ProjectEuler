#Problem 357
options(scipen = 999)
library(numbers) #for sieve

IsPrime <- function(n) { n == 2L || all(n %% 2L:max(2,floor(sqrt(n))) != 0)}

#n must be even, since 1 divides every number we have that 1 + (n/1) = n+1 must be odd to be prime.
#now if n is even, we know that 2 divides it. So we also know that 2 + (n/2) must be prime. if this is true,
#then it also follows that n/2 must be odd, so the number cannot be divisible by 4.
ptm <- proc.time()

N = 100000000

primes = numbers::Primes(N)
eligibleNumbers = primes - 1
eligibleNumbers = eligibleNumbers[((eligibleNumbers/2) %% 2 == 1)]

S = length(eligibleNumbers)
sum = 1

for(i in 1:length(eligibleNumbers)) {
  current = eligibleNumbers[i]
  u = ceiling(sqrt(current))
  isGood = TRUE
  for(j in 2:u) {
    if(current %% j == 0) {
      if(IsPrime((current/j) + j) == FALSE) {
        isGood = FALSE
      }
    }
    if(isGood == FALSE) {
      break
    }
  }
  if(isGood == TRUE) {
    sum = sum + current
  }
  if(i %% 10000 == 0) {
    print(i/S)
  }
}
sum
proc.time() - ptm
