ptm <- proc.time()   
N = 999         
stop = N/3          
S = 0
 
for (i in 1:stop)
{
    #if 5 times i is divisible by 3, or we are above 199, add just the 3 term
    #otherwise, add the ith 3 term and the ith 5 term.
    if (5*i %% 3 == 0 || i > 199)
    {
        S = S + 3*i
    }
    else
    {
        S = S + 3*i + 5*i
    }
}
print(S)            
proc.time() - ptm
