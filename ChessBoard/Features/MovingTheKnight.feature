Feature: Moving the Knight.
In order to play chess
As a Player
I want to move the Knight legally.

Scenario: Moving the knight legally
Given I have a Black knight at D4
And I have a White pawn at A1
And I move the Pawn to A2
When I move the Knight to F5
Then I should be shown "Knight to F5"


Scenario Outline: Illegal Move
Given I have a Black knight at D4
And the valid moves are 
|move|
|B3|
|B5|
|C2|
|C6|
|E2|
|E6|
|F3|
|F5|
And I have a White pawn at A1
And I move the Pawn to A2
When I move the Knight to <Position>
Then I should be shown "Illegal Move"

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
|B4|
|B6|
|B7|
|B8|
|C1|
|C3|
|C4|
|C5|
|C7|
|C8|
|D1|
|D2|
|D3|
|D4|
|D5|
|D6|
|D7|
|D8|
|E1|
|E3|
|E4|
|E5|
|E7|
|E8|
|F1|
|F2|
|F4|
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
