Feature: Boundaries of the board.
In order to obey the rules of Chess
As a Move Taker
I want to be prevented from entering moves outside the boundary of the board.

Scenario: Pawn at top.
Given I have A White Pawn at A8 
When I try and move to A9
Then I should be warned of an illegal move message.

Scenario: Knight heads off board
Given I have a Black knight at G8
When I try and move to I7
Then I should be warned of an illegal move message.

Scenario: Pawn moves legally.
Given I have A White Pawn at a7 
When I try and move to a8
Then I should be shown "Pawn to A8"
And Pawn should be at A8.

Scenario: Knight moves legally
Given I have a Black knight at G8
When I try and move to H6
Then I should be shown "Knight to H6"
And Knight should be at H6.

Feature: Moving the Pawn.
In order to play chess
As a Player
I want to move the Pawn legally.

Scenario: Pawn Starts on home row.
Given the game has just started 
And the Pawn is on B2
And the Knight is at G8
When I move to B3
Then I should be shown “Pawn to B3”
And Pawn should be at B3.

Given the game has just started
And the Pawn is on E2
And the Knight is at G8
When I move to E4
Then I should be shown “Pawn to E4”
And Pawn should be at E4.

Given the game has not just started
And the Pawn is on D2
And the Knight is at G8
When I move to D4
Then I should be shown "Pawn cannot move 2 spaces unless it in the first round and is on the home row."
And Pawn should be at D2.

Scenario: Pawn tries taking move when nothing to capture
Given the Pawn is on D7
And the Knight is at G8
When I move to C8
Then I should be shown “Pawn cannot diagonally unless it is capturing a piece.”
And Pawn should be at D7.

Feature: Moving the Knight.
In order to play chess
As a Player
I want to move the Knight legally.

Scenario: Moving the knight legally
Given It is the knight’s turn
And the knight is at D4
When I move to F5
Then I should be shown “Knight to F5”

Feature: Taking a piece.
In order to play chess
As a Player
I want to be able to take the oppositions piece.

Scenario:  Pawn Takes the Knight
Given It is the pawn’s turn.
And the pawn is at D3
And the knight is at C4
When the pawn moves to C4 
Then the knight should be taken
And the pawn should be at C4
And I should be shown. “Pawn takes Knight. Pawn wins” 

Scenario: Pawn collides with Knight. 
Given It is the pawn’s turn.
And the pawn is at C3
And the knight is at C4
When the pawn moves to C4 
Then the knight should be At C4
And the pawn should be at C3
And I should be shown. "Pawn collides with Knight. Draw."

Scenario: Knight takes Pawn. 
Given it is the Knights turn
And the Pawn is at F7
And the Knight is at D6
When I move to F7
Then the pawn should be taken 
And I should be shown "Knight takes Pawn. Knight Wins"
