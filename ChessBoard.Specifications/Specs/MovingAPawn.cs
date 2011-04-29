using System;
using Machine.Specifications;

namespace ChessBoard.Specifications.Specs
{
    [Subject(typeof(Game), "Moving a pawn")]
    public class MovingAPawn
    {
        Establish that = () =>
            {
                pawn = new Pawn("A2");
            
            };
        Because of = () => Exception = Catch.Exception(() => pawn.Move("A3","A4"));
        It should_not_throw = () => Exception.ShouldBeNull();
        It should_update_its_position = ()=> pawn.Position.ShouldEqual( "A3");

        static Pawn pawn;
        static Exception Exception;
    }
}