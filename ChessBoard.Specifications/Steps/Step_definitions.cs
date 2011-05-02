using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ChessBoard.Specifications.Steps
{
    [Binding]
    public class Step_definitions
    {
        Game _game;
        List<string> _validMoves = new List<string>();
        
        [BeforeScenario]
        public void SetUpGame()
        {
            _game = new Game();
        }



        [Given(@"the Knight is at (.*)")]
        [Given(@"I have a Black Knight at (.*)")]
        public void GivenIHaveABlackKnightAtG8(string position)
        {
            _game.StartKnight(position);
        }

        [Given(@"the Pawn is on (.*)")]
        [Given(@"I have a White Pawn at (.*)")]
        public void GivenIHaveAWhitePawnAtA1(string position)
        {
            _game.StartPawn(position);
        }
        [When(@"I move the Pawn to (.*)")]
        [Given(@"I move the Pawn to (.*)")]
        [Given(@"the Pawn moves to (.*)")]
        [When(@"the Pawn moves to (.*)")]
        public void GivenIMoveThePawnTo(string position)
        {
            _game.MovePawn(position);
        }


        
        [When(@"I move the Knight to (.*)")]
        public void WhenIMoveTheKnightTo(string position)
        {
            _game.MoveKnight(position);
        }



        [Then(@"I should be warned of an illegal move message")]
        public void ThenIShouldBeWarnedOfAnIllegalMoveMessage()
        {
            Assert.That(_game.Message.ToLower(), Is.StringContaining("Illegal move".ToLower()));
        }

        [Then(@"I should be shown ""(.*)""")]
        public void ThenIShouldBeShownKnightToF5(string message)
        {
            Assert.That(_game.Message.ToLower(), Is.StringContaining(message.ToLower()));
        }


        [Given(@"the valid moves are")]
        public void GivenTheValidMovesAre(Table table)
        {
            _validMoves.Clear();
            foreach (var row in table.Rows)
            {
                _validMoves.Add(row[0]);
            }
        }

        [Given(@"the valid moves are (.*)")]        
        public void GivenTheValidMovesAreD8(string move)
        {
            _validMoves.Add(move); // no need to this
        }


        [Then(@"the Pawn should be at (.*)")]
        [Then(@"Pawn should be at (.*)")]
        public void ThenPawnShouldBeAtD7(string position)
        {
            Assert.That(_game.PawnPosition, Is.EqualTo(position));
        }

        [Then(@"the Knight should be at (.*)")]
        public void ThenTheKnightShouldBeAtC4(string position)
        {
            Assert.That(_game.KnightPosition, Is.EqualTo(position));
        }


        [Given(@"the game has just started")]
        public void GivenTheGameHasJustStarted()
        {
            _game = new Game();
        }

        [Given(@"the game has not just started")]
        public void GivenTheGameHasNotJustStarted()
        {
            //note this needs knowledge of future steps (brittle). 
            _game.StartPawn("D1");
            _game.StartKnight("E7");
            _game.MovePawn("D2");
            _game.MoveKnight("G8");
        }

        [Then(@"the Pawn should be taken")]
        public void ThenThePawnShouldBeTaken()
        {
            Assert.That(_game.PawnPosition, Is.EqualTo("Taken"));
        }

        [Then(@"the Knight should be taken")]
        public void ThenTheKnightShouldBeTaken()
        {
            Assert.That(_game.KnightPosition, Is.EqualTo("Taken"));
        }



    }


}
