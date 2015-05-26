#Problem 24
Target = 1000000
Current = 0
InitialString = "0123456789"
InitialLength = nchar(InitialString)
SolutionString = ""
Index = 1

while (Current <= Target && InitialLength > 0)
{
    if (Current + factorial(InitialLength-1) < Target)
    {
        Index = Index + 1
        Current = Current + factorial(InitialLength-1)
    }
    else if (Current + factorial(InitialLength-1) >= Target)
    {
        x = substr(InitialString,Index,Index)
        SolutionString = paste(SolutionString,x)
        InitialString = sub(x,"",InitialString)
        InitialLength = InitialLength - 1
        Index = 1
    }
    else
    {
        break
    }
}
SolutionString
