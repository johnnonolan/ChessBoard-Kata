using System;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ChessBoard
{
    [Binding]
    public class Steps
    {
        Game _game;
        string[] _validMoves;


        //TODO: unhappy path for knight and pawn
        [BeforeScenario]
        public void BeforeFeature()
        {
            _game = new Game();
        }

 
        [Given(@"I have a White [Pp]awn at (.*)")]
        public void GivenIHaveAWhitePawnAtA7(string location)
        {
            _game.SetWhitesStartLocation(location);
        }

        [Given(@"the valid moves are (.*)")]
        public void GivenTheValidMovesAre(string validMoves)
        {
            _validMoves = validMoves.Split(',');
        }



        [Given(@"I have a Black knight at (.*)")]
        public void GivenIHaveABlackKnightAtG8(string location)
        {
            _game.SetBlacksStartLocation(location);
        }


        [Then(@"I should be warned of an illegal move message")]
        public void ThenIShouldBeWarnedOfAnIllegalMoveMessage()
        {
            Assert.That(_game.Message, Is.EqualTo("Illegal move! Try again"));
        }

        [Then(@"the pawn should be at (.*)")]
        [Then(@"Pawn should be at (.*)")]
        public void ThenPawnShouldBeAt(string location)
        {
            Assert.That(_game.WhitePawn.Location, Is.EqualTo(location));
        }

        [Then(@"the knight should be at (.*)")]
        public void ThenTheKnightShouldBeAt(string location)
        {
            Assert.That(_game.BlackKnight.Location, Is.EqualTo(location));
        }


        [Then(@"Knight should be at (.*)")]
        public void ThenKnightShouldBeAtH6(string location)
        {
            Assert.That(_game.BlackKnight.Location, Is.EqualTo(location));
        }

        [When(@"I move the Pawn to (.*)")]
        [Given(@"I move the Pawn to (.*)")]
        [Given(@"I move the Knight to (.*)")]
        [When(@"I move the Knight to (.*)")]        
        public void WhenITryAndMoveToA8(string location)
        {
             _game.NextMove(location);
        }

        [Then(@"I should be shown ""(.*)""")]
        public void ThenIShouldBeShownPawnToA8(string message)
        {
            Assert.That(_game.Message, Is.EqualTo(message));
        }

        [Then(@"the (.*) should be taken")]
        public void ThenThePawnShouldBeTaken(string piece)
        {
            var validPieces = new[] {"knight", "pawn"};
            if (!validPieces.Contains(piece.ToLower()))
                throw new ArgumentException("piece");
            Assert.That(_game.PieceTaken, Is.Not.Null);
            Assert.That(_game.PieceTaken.ToString().ToLower(), Is.EqualTo(piece.ToLower()));
        }


    }


    public class Pawn : IPiece
    {
        readonly IMovementRules _movementRules;
        public string Location { get; set; }

        
        public Pawn(string location, IMovementRules movementRules)
        {
            Location = location;
            _movementRules = movementRules;
        }

        public void Move(string location)
        {
            Location = location;
        }

        public override string ToString()
        {
            return "Pawn";
        }

    }

    public interface IMovementRules
    {
        bool IsValidMove(string currentLocation, string newLocation);
    }

    public class Knight : IPiece
    {
        readonly IMovementRules _movementRules;
        public string Location { get; set; }

        public Knight(string location, IMovementRules movementRules )
        {
            _movementRules = movementRules;
            Location = location;
        }

        public override string ToString()
        {
            return "Knight";
        }

        public void Move(string location)
        {

            Location = location;
        }
    }

}
