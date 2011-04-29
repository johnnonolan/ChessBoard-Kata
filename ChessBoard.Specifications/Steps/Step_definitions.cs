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


        [Given(@"I have a Black Knight at (.*)")]
        public void GivenIHaveABlackKnightAtG8(string position)
        {
            _game.StartKnight(position);
        }

        [Given(@"I have a White Pawn at (.*)")]
        public void GivenIHaveAWhitePawnAtA1(string position)
        {
            _game.StartPawn(position);
        }
        [When(@"I move the Pawn to (.*)")]
        [Given(@"I move the Pawn to (.*)")]
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
            Assert.That(_game.Message.ToLower(), Is.EqualTo("Illegal move".ToLower()));
        }

        [Then(@"I should be shown ""(.*)""")]
        public void ThenIShouldBeShownKnightToF5(string message)
        {
            Assert.That(_game.Message.ToLower(), Is.EqualTo(message.ToLower()));
        }


        [Given(@"the valid moves are")]
        public void GivenTheValidMovesAre(Table table)
        {
            foreach (var row in table.Rows)
            {
                _validMoves.Add(row[0]);
            }
        }


        [Then(@"Pawn should be at (.*)")]
        public void ThenPawnShouldBeAtD7(string position)
        {
            ScenarioContext.Current.Pending();
        }
    }


}
