using System;
using Machine.Specifications;

namespace ChessBoard.Specifications.Specs
{
    [Subject(typeof(Game), "Moving a pawn")]
    public class MovingAPawn
    {
        //Establish that = () =>
        //    {
                
            
        //    };
        Because of = () => pawn = new Pawn("A2");

        It should_not_throw_moving_one_forward = () =>
            {
                Exception = Catch.Exception(() => pawn.Move("A3", "A4"));
                Exception.ShouldBeNull();
            };

        It should_update_its_position = () =>
            {
                pawn.Move("A3", "A4");
                pawn.Position.ShouldEqual("A3");
            };

        static Pawn pawn;
        static Exception Exception;
    }
}