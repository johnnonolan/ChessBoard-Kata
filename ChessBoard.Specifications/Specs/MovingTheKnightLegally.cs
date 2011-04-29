using System;
using Machine.Specifications;

namespace ChessBoard.Specifications.Specs
{
    [Subject(typeof(Game), "Moving a piece")]
    public class MovingTheKnightLegally
    {
        Establish that = () =>
            {
                game = new Game();
                game.StartPawn("A2");
                game.StartKnight("A4");
                game.MovePawn("A3");
            };
        Because of = () => Exception = Catch.Exception(() => game.MoveKnight("B2"));
        It should_not_throw = () => Exception.ShouldBeNull();

        //undocumented spec
        It should_display_move_in_message = () => game.Message.ShouldEqual("Knight to B2");

        static Game game;
        static Exception Exception;
    }

    [Subject(typeof(Knight), "Moving the knight")]
    public class MovingTheKnight
    {

        Because of = () => knight = new Knight("D4");

        It should_be_able_move_up_2_left_one = () =>
        {
            knight.Move("C6","A1");
            knight.Position.ShouldEqual("C6");
        };


        It should_not_be_able_move_up_1_left_one = () =>
        {
            Exception = Catch.Exception(()=> knight.Move("C5", "A1"));            
            Exception.ShouldBeOfType<InvalidOperationException>();
        };

        It should_not_be_able_move_across_1_down_three = () =>
        {
            Exception = Catch.Exception(() => knight.Move("C1", "A1"));
            Exception.ShouldBeOfType<InvalidOperationException>();
        };

        
        static Knight knight;
        static Exception Exception;

    }
}