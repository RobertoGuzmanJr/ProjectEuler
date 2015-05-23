isPalindrome <- function(N)
{
    x = toString(N)
    upper = floor(nchar(x)/2)
    for(i in 1:upper)
    {
        if(substr(x,i,i) != substr(x,nchar(x)-i+1,nchar(x)-i+1)) {return(FALSE)}
    }
    return(TRUE)
}

is3DigitDivisible <- function(N)
{
    if(N < 100^2 || N > 999^2) {return(FALSE)}
    for(i in 100:999)
    {
        if(N %% i == 0)
        {
            if(nchar(toString(N / i)) == 3)
            {
                return(TRUE)
            }
        }
    }
    return(FALSE)
}

ptm <- proc.time()
found = 0
for(i in seq(from=997997,to=10000, by =-11))
{
    if(isPalindrome(i))
    {
        if(is3DigitDivisible(i))
        {
            found = i
            break
        }
    }
}
found
proc.time() - ptm
