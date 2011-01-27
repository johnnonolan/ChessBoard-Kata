Feature: Taking a piece.
In order to play chess
As a Player
I want to be able to take the oppositions piece.

Scenario: Pawn Takes the Knight
Given I have a White Pawn at D3
And I have a Black knight at C4
When the pawn moves to C4 
Then the knight should be taken
And the pawn should be at C4
And I should be shown "Pawn takes Knight. Pawn wins" 

Scenario: Pawn collides with Knight. 
Given I have a White Pawn at C3
And I have a Black knight at C4
When the pawn moves to C4 
Then the knight should be at C4
And the pawn should be at C3
And I should be shown "Pawn collides with Knight. Draw"

Scenario: Knight takes Pawn. 
Given I have a Black knight at D6
And I have a White Pawn at F6
And the Pawn moves to F7
When I move the Knight to F7
Then the pawn should be taken 
And I should be shown "Knight takes Pawn. Knight Wins"
