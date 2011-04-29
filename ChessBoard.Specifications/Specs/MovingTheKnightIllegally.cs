using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace ChessBoard.Specifications.Specs
{
    [Subject(typeof(Game))]
    public class MovingTheKnightIllegally
    {
        Establish that = () =>
            {
                game = new Game();
                game.StartPawn("A2");
                game.StartKnight("G8");

            };

        Because of = () => game.MovePawn("I7");
        It should_display_an_illegal_message = () => game.Message.ShouldEqual("Illegal move");


        static Game game;
    }
}
