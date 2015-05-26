#Problem 17: Number Letter Counters
#Find the total number of characters
N = 1000
nums <- matrix((1:N),ncol = 2,nrow = N)
nums <- as.data.frame(nums)
names(nums) <- c("Number","Written")
nums[,2] <- 0
	
#insert base values
nums[1,2] <- "one"
nums[2,2] <- "two"
nums[3,2] <- "three"
nums[4,2] <- "four"
nums[5,2] <- "five"
nums[6,2] <- "six"
nums[7,2] <- "seven"
nums[8,2] <- "eight"
nums[9,2] <- "nine"
nums[10,2] <- "ten"
nums[11,2] <- "eleven"
nums[12,2] <- "twelve"
nums[13,2] <- "thirteen"
nums[14,2] <- "fourteen"
nums[15,2] <- "fifteen"
nums[16,2] <- "sixteen"
nums[17,2] <- "seventeen"
nums[18,2] <- "eighteen"
nums[19,2] <- "nineteen"
nums[20,2] <- "twenty"
nums[30,2] <- "thirty"
nums[40,2] <- "forty"
nums[50,2] <- "fifty"
nums[60,2] <- "sixty"
nums[70,2] <- "seventy"
nums[80,2] <- "eighty"
nums[90,2] <- "ninety"
nums[100,2] <- "hundred"	
nums[1000,2] <- "one thousand"
	
hundreds = 0
tens = 0
ones = 0

hundreds_text = ""
tens_text = ""
ones_text = ""

for (i in 1:N)
{
	if (nums[i,2] == 0)
	{
		hundreds = nums[i,1] %/% 100
		tens = (nums[i,1] %/% 10) - hundreds*10
		ones = (nums[i,1] - (hundreds*100 + tens*10))
		hundreds_text = ""
		tens_text = ""
		ones_text = ""			
		if (hundreds > 0 && tens > 0 && ones > 0)
		{
			if (tens == 1)
			{
				hundreds_text = paste(nums[hundreds,2],nums[100,2])
				tens_text = paste("and",nums[10+ones,2])
			}
			else
			{
				hundreds_text = paste(nums[hundreds,2],nums[100,2])
				tens_text = paste("and",nums[10*tens,2])
				ones_text = nums[ones,2]
			}
		}
		else if (hundreds > 0 && tens > 0 && ones == 0)
		{
			hundreds_text = paste(nums[hundreds,2],nums[100,2])
			tens_text = paste("and",nums[10*tens,2])
		}
		else if (hundreds > 0 && tens == 0 && ones > 0)
		{
			hundreds_text = paste(nums[hundreds,2],nums[100,2])
			ones_text = paste("and",nums[ones,2])
		}

		else if (hundreds > 0 && tens == 0 && ones == 0)
		{
			hundreds_text = paste(nums[hundreds,2],nums[100,2])
		}
		
		else if (hundreds == 0 && tens > 0 && ones > 0)
		{
			if (tens == 1)
			{
				tens_text = nums[10+ones,2]
			}
			else
			{
				tens_text = nums[10*tens,2]
				ones_text = nums[ones,2]
			}
		}
		else
		{
			ones_text = nums[ones,2]
		}
		nums[i,2] = paste(hundreds_text,tens_text,ones_text)
	}
}
sum(nchar(gsub(" ","",nums[,2],fixed = TRUE))) + 3 #3 is to account for the extra one in one-hundred
