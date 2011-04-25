Feature: Moving the Pawn.
In order to play chess
As a Player
I want to move the Pawn legally.

Scenario: Pawn Starts on home row.
Given the game has just started 
And the Pawn is on B2
And the Knight is at G8
When I move the Pawn to B3
Then I should be shown "Pawn to B3"
And Pawn should be at B3

Given the game has just started
And the Pawn is on E2
And the Knight is at G8
When I move the Pawn to E4
Then I should be shown "Pawn to E4"
And Pawn should be at E4

Given the game has not just started
And the Pawn is on D2
And the Knight is at G8
When I move the Pawn to D4
Then I should be shown "Pawn cannot move 2 spaces unless it in the first round and is on the home row."
And Pawn should be at D2

Scenario: Pawn tries taking move when nothing to capture
Given I have a White Pawn at D7
And I have a Black Knight at G8
When I move the Pawn to C8
Then I should be shown "Pawn cannot diagonally unless it is capturing a piece."
And Pawn should be at D7

Scenario Outline: Pawn moves illegally
Given I have a White Pawn at D7
And I have a Black Knight at G8
And the valid moves are D8
When I move the Pawn to <Position>
Then I should be shown "illegal move"
And Pawn should be at D7


Scenarios: Positions
|Position|
|A1|
|A2|
|A3|
|A4|
|A5|
|A6|
|A7|
|A8|
|B1|
|B2|
|B3|
|B4|
|B5|
|B6|
|B7|
|B8|
|C1|
|C2|
|C3|
|C4|
|C5|
|C6|
|C7|
|C8|
|D1|
|D2|
|D3|
|D4|
|D5|
|D6|
|D7|
|E1|
|E2|
|E3|
|E4|
|E5|
|E7|
|E8|
|F1|
|F2|
|F3|
|F4|
|F5|
|F6|
|F7|
|F8|
|G1|
|G2|
|G3|
|G4|
|G5|
|G6|
|G7|
|G8|
|H1|
|H2|
|H3|
|H4|
|H5|
|H6|
|H7|
|H8|

