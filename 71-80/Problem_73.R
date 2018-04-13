#problem 73
# Naive Euclid algorithm
gcd <- function(a, b)
{
  rk_1 <- a;
  rk_2 <- b;
  # Recurrence Formula:  r_k =  r_k-1 modulo r_k-2
  # Increment k until r_k-2 == 0 
  while(rk_2 != 0) {
    rk      <- rk_1%%rk_2; # remainder
    rk_1    <- rk_2;       # proceed in recurrence
    rk_2    <- rk;
  }
  return(rk_1)
}

ptm <- proc.time()

d_max = 12000
lower = (1/3)
upper = (1/2)
numTotal = 0

for(d in d_max:2) {
  for(n in floor(d/3):ceiling(d/2)) {
    if(gcd(n,d) == 1) {
      frac = n / d
      if(lower < frac & frac < upper) {
        numTotal = numTotal + 1        
      }
    }
  }
  print(d)
}
numTotal

proc.time() - ptm
