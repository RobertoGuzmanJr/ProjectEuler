ptm <- proc.time()
N1 = 1
N2 = 2
M = 4000000
S = 2
while (N2 < M)
{
    t = N2 + N1
    if (t %% 2 == 0) {S = S + t}
    N1 = N2
    N2 = t
}
print(S)
proc.time() - ptm
