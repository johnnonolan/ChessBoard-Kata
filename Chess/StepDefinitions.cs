using System;
using System.Reflection;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Chess
{
    public static class The
    {
        public static Game Game = new Game();
    }

    [Binding]
    public class StepDefinitions
    {
        [Given(@"[Tt]he game has just started")]
        public void StartGame()
        {
        }

        // GOD DAMN YOU NOLAN!!!!111one
        [Given(@"I have a (.*) on (.*)")]
        [Given(@"I have a (.*) at (.*)")]
        [Given(@"[Tt]he (.*) is on (.*)")]
        [Given(@"[Tt]he (.*) is at (.*)")]
        public void SetPieceAtPosition(string pieceName, string position)
        {
            The.Game.PutPieceInPlay(PieceFrom(pieceName), PositionFrom(position));
        }

        protected Piece PieceFrom(string pieceName)
        {
            if (pieceName.ToLower().Contains("pawn"))
                return new WhitePawn();

            return new BlackKnight();
        }

        Position PositionFrom(string position)
        {
            return new Position(position[0], Convert.ToInt32(position[1].ToString()));
        }

        [Given(@"I move the (.*) to (.*)")]
        [When(@"I move the (.*) to (.*)")]
        public void MovePieceToPosition(string pieceName, string position)
        {
            The.Game.MovePieceTo(PieceFrom(pieceName), PositionFrom(position));
        }

        [Given(@"[Tt]he valid moves are (.*)")]
        public void AssignValidMoves(string move)
        {
            The.Game.HasValidMoves(move);
        }

        [Then(@"I should be warned of an illegal move message")]
        public void IllegalMoveMessageIsShown()
        {
            MessageIsShown("illegal move");
        }

        [Then(@"I should be shown '(.*)'")]
        public void PieceToPositionMessageIsShown(string message)
        {
            MessageIsShown(message);
        }

        public void MessageIsShown(string message)
        {
            Assert.That(The.Game.Message, Is.EqualTo(message));
        }

        [Then(@"(.*) should be at (.*)")]
        public void PieceIsAtLocation(string pieceName, string position)
        {
            var piece = The.Game.GetPieceAtPosition(PositionFrom(position));
            Assert.That(piece.ToString(), Is.EqualTo(pieceName));
        }
    }
}