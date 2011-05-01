using System;
using Machine.Specifications;

namespace ChessBoard.Specifications.Specs
{
    [Subject(typeof(Game),"Starting a Game and putting pieces down")]
    public class StartingAKnight
    {
        Establish that  = ()=> game = new Game();

        Because of = () => Exception = Catch.Exception(()=> game.StartKnight("G8"));

        It should_not_throw = () => Exception.ShouldBeNull();
        static Exception Exception;
        static Game game;
    }


    [Subject(typeof(Game), "Starting a Game and putting pieces down")]
    public class StartingAPawn
    {
        Establish that = () => game = new Game();

        Because of = () => Exception = Catch.Exception(() => game.StartPawn("A1"));

        It should_not_throw = () => Exception.ShouldBeNull();
        It should_be_at_A1 = ()=> game.PawnPosition.ShouldEqual("A1");
        static Exception Exception;
        static Game game;
    }

}
