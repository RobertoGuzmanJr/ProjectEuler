#Problem 85
#formula for the number of rectangles on M rows and N columns is given by:

#F(M,1) = TRIANGULAR(M)
#F(M,N) = F(M,N-1) + TRIANGULAR(M)*N

#2000000 = n(n+1)/2 or 4000000 = n(n+1) = n^2 + n

#n^2 + n - 4000000 = 0

#only need to go as high as the 2000th triangular number.

largest = 2000
limit = 2000000
diff = 2000000
result = 0
triangular = (1:largest)*1

for(i in 1:length(triangular))
{
triangular[i] = (i)*(i+1)/2
}

M = 1
N = 1

while(M <= largest)
{
if(N == 1)
{
T = triangular[M]
}
else
{
T = T + triangular[M]*N
}
if(abs(T - limit) < diff)
{
diff = abs(T - limit)
result = M*N
}
if(M == N)
{
N = 1
M = M + 1
T = 0
}
else
{
N = N + 1
}
}
print(result)
