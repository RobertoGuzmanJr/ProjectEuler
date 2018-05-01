#Turn off scientific notation
options(scipen=999)

#Load the data
data <- read.csv(file="C:/Users/Rob Guzman/Desktop/Budget.csv")

#Append a new column to this dataframe for the period that the row belongs to
data$Period = paste(as.character(data$Month.Name),as.character(data$Year),sep="-")

#Filter out all rows that are not valid
data = data[data$Period != "-NA",]

#Separate out the periods for each
periods = unique(data$Period)
numPeriods = length(periods)

#Separate out the categories
categories = unique(as.character(data$Category))
numCategories = length(categories)

#Get the period total saved or spent
PeriodTotalSaved = aggregate(Total ~ Period, data, sum)
PeriodTotalSaved[,2] = PeriodTotalSaved[,2]*-1

print(paste("The average amount saved per period is: ",as.character(mean(PeriodTotalSaved[,2])),sep=""))
print(paste("The median amount saved per period is: ",as.character(median(PeriodTotalSaved[,2])),sep=""))

#For each category, see the average.
CategoryAverageYearToDate1 = aggregate(Total ~ Category, data, sum)
CategoryAverageYearToDate2 = aggregate(Total ~ Category, data, mean)
CategoryAverageYearToDate1[,2] = CategoryAverageYearToDate1[,2] / numPeriods

#method 1 = take the total for the category and divide by the number of periods.
print("The average per category (method 1) is:")
CategoryAverageYearToDate1
#method 2 = take the average of the expenses for each category.
print("The average per category (method 2) is:")
CategoryAverageYearToDate2

#For each category, see the most recent date money was spent on it, as well as the oldest date money was spent on it.
CategoryEarliestExpense = aggregate(Year + (1/100)*Month ~ Category, data, min)
colnames(CategoryEarliestExpense) = c("Category","Earliest_Period")
print("The earliest period that each category appears is:")
CategoryEarliestExpense

CategoryMostRecentExpense = aggregate(Year + (1/100)*Month ~ Category, data, max)
colnames(CategoryMostRecentExpense) = c("Category","MostRecent_Period")
print("The most recent period that each category appears is:")
CategoryMostRecentExpense

#Analyze each category and create a plot
CategorySpentToDate = aggregate(Total ~ Month+Year+Category, data, sum)
CategorySpentToDate$Period = as.Date(paste(CategorySpentToDate$Year,CategorySpentToDate$Month,"1",sep="-"))

for(c in 1:length(categories)) {
  currentCategory = categories[c]
  multiplier = 1.0
  if(currentCategory == "INCOME") {
    multiplier = -1.0
  }
  d = CategorySpentToDate[CategorySpentToDate$Category == currentCategory,]
  d = d[order(d$Period),]
  d$Total = multiplier*d$Total
  d$Date_Adj = as.Date(paste(d$Year,d$Month,"01",d$Year,sep="/"))
  pdf(paste("Total vs Time For ",currentCategory,".pdf",sep=""))
  plot(x = d$Date_Adj, y= d$Total,main = paste("Total vs Time For ",currentCategory,sep=""),
       xlab = "Date",ylab = "Total in $")
  lines(d$Date_Adj[order(d$Date_Adj)], d$Total[order(d$Date_Adj)], xlim=range(d$Date_Adj), ylim=range(d$Total), pch=16)
  lines(stats::lowess(d$Total),col = "Red") #smoothing line
  dev.off()
}