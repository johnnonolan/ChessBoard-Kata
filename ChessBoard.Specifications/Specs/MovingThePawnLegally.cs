using System;
using Machine.Specifications;

namespace ChessBoard.Specifications.Specs
{
    [Subject(typeof(Game),"Moving a piece")]
    public class MovingThePawnLegally
    {
        Establish that = () =>
            {
                game = new Game();
                game.StartPawn("A2");
                game.StartKnight("A4");
            };
        Because of = () => Exception= Catch.Exception(()=> game.MovePawn("A3"));
        It should_not_throw = () => Exception.ShouldBeNull();
        
        static Game game;
        static Exception Exception;
    }
}
