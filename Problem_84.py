#Let's simulate this situation.

import math as m
import random as rand

#roll 2 s-sided dice.
def Roll(s):
    return([rand.randint(1,s),rand.randint(1,s)])

#takes in a roll and determines whether we have rolled doubles.
def RolledDoubles(l):
    if l[0] == l[2]:
        return True
    return False

#Community Chest (2/16 cards):
#WLOG: LET'S DEFINE THE CONVENTION THAT:
#0 == Advance to GO
#1 == Go to JAIL

#Chance (10/16 cards):
#WLOG: LET'S DEFINE THE CONVENTION THAT:
#0 == Advance to GO
#1 == Go to JAIL
#2 == Go to C1
#3 == Go to E3
#4 == Go to H2
#5 == Go to R1
#6 == Go to next R (railway company)
#7 == Go to next R
#8 == Go to next U (utility company)
#9 == Go back 3 squares.

#INITIALIZE THE BOARD
Board = list()
for i in range(0,40):
    Board.append(0)

CH = [i for i in range(16)]
CC = [i for i in range(16)]

rand.shuffle(CH)
rand.shuffle(CC)

CH_pos = 0
CC_pos = 0

NumTurns = 9000000
NumDoubles = 0
NumSides = 6
CurrentSpace = 0 #Start on GO

for i in range(0,NumTurns):
    #Roll the Dice.
    d = Roll(NumSides)

#Check for doubles, and incremental accordingly, or reset.
    if RolledDoubles is True:
        NumDoubles += 1
    else:
        NumDoubles = 0

    #If there are three doubles, then we go to Jail and reset the doubles. Nothing else happens.
    if NumDoubles == 3:
        CurrentSpace = 10
        Board[CurrentSpace] += 1
        NumDoubles = 0

    else:
        #Take the rest of the roll.
        CurrentSpace += (d[0] + d[1])

        #If we go over the range, fix the number so that it wraps around.
        if CurrentSpace >= 40:
            CurrentSpace -= 40

        #Now what happens deoends on what we landed on. The special spaces are GTJ, CC* and CH*.
        #Let's handle the special spaces, and then as a last case use the regular spaces.

        #Start with CC*. If we land on one of these, there is a 14/16 chance of remaining, but there are two options
        #which move us to other spaces.
        if CurrentSpace == 2 or CurrentSpace == 17 or CurrentSpace == 33:
            #draw a card to see what we do.
            card = CC[CC_pos]

            #Case where we go to GO.
            if card == 0:
                CurrentSpace = 0
            #Case where we go to Jail.
            elif card == 1:
                CurrentSpace = 10

            #Increment the deck.
            if CC_pos == 15:
                CC_pos = 0
            else:
                CC_pos += 1

            #Give credit to the space.
            Board[CurrentSpace] += 1

        #Now we need to deal with each of the CH* spaces on their own, since they are location dependent.
        #Start with CH1
        elif CurrentSpace == 7:
            #draw a card to see what we do.
            card = CH[CH_pos]

            #Case where we go to GO.
            if card == 0:
                CurrentSpace = 0
            #Case where we go to Jail.
            elif card == 1:
                CurrentSpace = 10
            #Case where we go to C1.
            elif card == 2:
                CurrentSpace = 11
            #Case where we go to E3.
            elif card == 3:
                CurrentSpace = 24
            #Case where we go to H2.
            elif card == 4:
                CurrentSpace = 39
            #Case where we go to R1.
            elif card == 5:
                CurrentSpace = 5
            #Case where we go to next R (next railway).
            elif card == 6:
                CurrentSpace = 15
            #Case where we go to next R (next railway).
            elif card == 7:
                CurrentSpace = 15
            #Case where we go to next U (next utility).
            elif card == 8:
                CurrentSpace = 12
            #Case where we go back 3 spaces.
            elif card == 9:
                CurrentSpace = 4

            #Increment the deck.
            if CH_pos == 15:
                CH_pos = 0
            else:
                CH_pos += 1

            #Give credit to the space.
            Board[CurrentSpace] += 1

        # Now CH2
        elif CurrentSpace == 22:
            # draw a card to see what we do.
            card = CH[CH_pos]

            # Case where we go to GO.
            if card == 0:
                CurrentSpace = 0
            # Case where we go to Jail.
            elif card == 1:
                CurrentSpace = 10
            # Case where we go to C1.
            elif card == 2:
                CurrentSpace = 11
            # Case where we go to E3.
            elif card == 3:
                CurrentSpace = 24
            # Case where we go to H2.
            elif card == 4:
                CurrentSpace = 39
            # Case where we go to R1.
            elif card == 5:
                CurrentSpace = 5
            # Case where we go to next R (next railway).
            elif card == 6:
                CurrentSpace = 25
            # Case where we go to next R (next railway).
            elif card == 7:
                CurrentSpace = 25
            # Case where we go to next U (next utility).
            elif card == 8:
                CurrentSpace = 28
            # Case where we go back 3 spaces.
            elif card == 9:
                CurrentSpace = 19

            # Increment the deck.
            if CH_pos == 15:
                CH_pos = 0
            else:
                CH_pos += 1

            # Give credit to the space.
            Board[CurrentSpace] += 1

        # Now CH3
        elif CurrentSpace == 36:
            # draw a card to see what we do.
            card = CH[CH_pos]

            # Case where we go to GO.
            if card == 0:
                CurrentSpace = 0
            # Case where we go to Jail.
            elif card == 1:
                CurrentSpace = 10
            # Case where we go to C1.
            elif card == 2:
                CurrentSpace = 11
            # Case where we go to E3.
            elif card == 3:
                CurrentSpace = 24
            # Case where we go to H2.
            elif card == 4:
                CurrentSpace = 39
            # Case where we go to R1.
            elif card == 5:
                CurrentSpace = 5
            # Case where we go to next R (next railway).
            elif card == 6:
                CurrentSpace = 5
            # Case where we go to next R (next railway).
            elif card == 7:
                CurrentSpace = 5
            # Case where we go to next U (next utility).
            elif card == 8:
                CurrentSpace = 12
            # Case where we go back 3 spaces.
            elif card == 9:
                #Now we land on a CC space!
                # draw a card to see what we do.
                card2 = CC[CC_pos]

                # Case where we go to GO.
                if card2 == 0:
                    CurrentSpace = 0
                # Case where we go to Jail.
                elif card2 == 1:
                    CurrentSpace = 10

                # Increment the deck.
                if CC_pos == 15:
                    CC_pos = 0
                else:
                    CC_pos += 1

            # Increment the deck.
            if CH_pos == 15:
                CH_pos = 0
            else:
                CH_pos += 1

            # Give credit to the space.
            Board[CurrentSpace] += 1

        #Now the special space of GTJ.
        elif CurrentSpace == 30:
            CurrentSpace = 10

            #Give credit to the space.
            Board[CurrentSpace] += 1

        #Finally, the regular case.
        else:
            Board[CurrentSpace] += 1


t = sum(Board)
result = [i/t for i in Board]

print(result)
