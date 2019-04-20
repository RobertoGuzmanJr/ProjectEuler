r = c()

#(a???1)n + (a+1)n mod (a^2)

for(a in 3:1000)
{
  remainderSeries = c(2)
  n = 1
  r_max = 2
  found = FALSE
  while(!found)
  {
    new_r = (2*a*n)%%(a*a)
    if(new_r > r_max)
    {
      r_max = new_r
    }
    if(new_r %in% remainderSeries)
    {
      r = c(r,r_max)
      found = TRUE
    }
    else
    {
      remainderSeries = c(remainderSeries,new_r)
      n = n + 2
    }
  }
}
sum(r)
