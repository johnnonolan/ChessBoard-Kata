Feature: Moving the Knight.
In order to play chess
As a Player
I want to move the Knight legally.

Scenario: Moving the knight legally
Given I have a Black knight at D4
And I have a White pawn at A1
And the pawn moves to A2
When I move to F5
Then I should be shown "Knight to F5"
