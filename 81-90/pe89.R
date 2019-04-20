data <- read.table("C:/Users/Rob Guzman/Desktop/p089_roman.txt")

mapLetterToValue <- function(v)
{
  if(v == 'M')
    return(1000)
  else if(v == 'D')
    return(500)
  else if(v == 'C')
    return(100)
  else if(v == 'L')
    return(50)
  else if(v == 'X')
    return(10)
  else if(v == 'V')
    return(5)
  else
    return(1)
}

transformToNumber <- function (x)
{
  s = 0
  end = nchar(x)
  i = 1
  while(i <= end)
  {
    if(i < end && substr(x,i,i) == 'I' && substr(x,i+1,i+1) == 'V')
    {
      s = s + 4
      i = i + 2
    }
    else if(i < end && substr(x,i,i) == 'I' && substr(x,i+1,i+1) == 'X')
    {
      s = s + 9
      i = i + 2
    }
    else if(i < end && substr(x,i,i) == 'X' && substr(x,i+1,i+1) == 'L')
    {
      s = s + 40
      i = i + 2
    }
    else if(i < end && substr(x,i,i) == 'X' && substr(x,i+1,i+1) == 'C')
    {
      s = s + 90
      i = i + 2
    }
    else if(i < end && substr(x,i,i) == 'C' && substr(x,i+1,i+1) == 'D')
    {
      s = s + 400
      i = i + 2
    }
    else if(i < end && substr(x,i,i) == 'C' && substr(x,i+1,i+1) == 'M')
    {
      s = s + 900
      i = i + 2
    }
    else
    {
      s = s + mapLetterToValue(substr(x,i,i))
      i = i + 1
    }
  }
  return(s)
}

compact <- function(x)
{
  c = 0
  #count the digits at the thousands place and beyond
  c = c + (x %/% 1000)
  x = x %% 1000
  #count the number of characters to get the hundreds place
  if(x %/% 100 == 9)
  {
    c = c + 2
  }
  else if(x %/% 100 == 8)
  {
    c = c + 4
  }
  else if (x %/% 100 == 7)
  {
    c = c + 3
  }
  else if (x %/% 100 == 6)
  {
    c = c + 2
  }
  else if (x %/% 100 == 5)
  {
    c = c + 1
  }
  else if (x %/% 100 == 4)
  {
    c = c + 2
  }
  else if (x %/% 100 == 3)
  {
    c = c + 3
  }
  else if (x %/% 100 == 2)
  {
    c = c + 2
  }
  else if (x %/% 100 == 1)
  {
    c = c + 1
  }
  x = x %% 100
  #count the number of characters to get the tens place
  if(x %/% 10 == 9)
  {
    c = c + 2
  }
  else if(x %/% 10 == 8)
  {
    c = c + 4
  }
  else if (x %/% 10 == 7)
  {
    c = c + 3
  }
  else if (x %/% 10 == 6)
  {
    c = c + 2
  }
  else if (x %/% 10 == 5)
  {
    c = c + 1
  }
  else if (x %/% 10 == 4)
  {
    c = c + 2
  }
  else if (x %/% 10 == 3)
  {
    c = c + 3
  }
  else if (x %/% 10 == 2)
  {
    c = c + 2
  }
  else if (x %/% 10 == 1)
  {
    c = c + 1
  } 
  x = x %% 10
  if(x  == 9)
  {
    c = c + 2
  }
  else if(x == 8)
  {
    c = c + 4
  }
  else if (x  == 7)
  {
    c = c + 3
  }
  else if (x  == 6)
  {
    c = c + 2
  }
  else if (x == 5)
  {
    c = c + 1
  }
  else if (x == 4)
  {
    c = c + 2
  }
  else if (x  == 3)
  {
    c = c + 3
  }
  else if (x == 2)
  {
    c = c + 2
  }
  else if (x == 1)
  {
    c = c + 1
  }
  return(c)
}

data <- as.data.frame(data)
vect <- data[,1]
vect <- as.vector(vect)
newVect <- character(length(vect))

old_char_count = 0
new_char_count = 0
for(i in 1:length(vect))
{
  word = vect[i]
  old_char_count = old_char_count + nchar(word)
  
  new_char_count = new_char_count + compact(transformToNumber(word))
  
}

old_char_count - new_char_count


