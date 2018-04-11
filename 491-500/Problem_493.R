options(scipen=999)
#Problem 493
# 
# Let X = count of the colors. Then X = X_0 + X_1 + ... + X_6. Then E[X] = E[X_0] + E[X_1] + ... + E[X_6] = 7*E[X_0] by symmetry.
# Then, we only need to know the probability of choosing that color, since these are indicators.
# 
# So E[X] = 7*P[selecting a color] = 7*(1-P[not selecting a color]) = 7*(1 - (60 choose 20) / (70 choose 20))

7*(1 - choose(60,20)/choose(70,20))
1 - choose(60,20) / choose(70,20)

6.818741802
