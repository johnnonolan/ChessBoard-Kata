using System;
using System.Linq;
using Maths = System.Math;

namespace ChessBoard
{
    public class Game
    {
        Knight _knight;
        Pawn _pawn;
        public string Message = "";

        public void StartKnight(string startingPosition)
        {
            _knight = new Knight(startingPosition);

        }

        public void StartPawn(string startingPosition)
        {
            _pawn = new Pawn(startingPosition);
        }

        public void MovePawn(string to)
        {
            try
            {
                if (!to.IsOnBoard())
                {
                    throw new InvalidOperationException();
                }
                var oldPosition = _pawn.Position;

                _pawn.Move(to, _knight.Position);
                Message = String.Format("Pawn to {0}", oldPosition);
            } 
            catch (InvalidOperationException)
            {
                Message = "Illegal move";
            }                                                 
        }

        public void MoveKnight(string to)
        {
            try
            {
                if (!to.IsOnBoard())
                {
                    throw new InvalidOperationException();
                }
                var oldPosition = _knight.Position;
                _knight.Move(to, _pawn.Position);
                Message = String.Format("Knight to {0}", to);
            }
            catch (InvalidOperationException)
            {
                Message = "Illegal move";
            }                                                 
        }
    }

    public class Pawn : IPiece
    {
        public string Position { get; private set; }

        public Pawn(string position)
        {
            Position = position;
        }

        public void Move(string to, string opponentsPosition)
        {
            Position = to;
        }
    }

    public class Knight : IPiece
    {
        public string Position { get;  set; }
        

        public Knight(string position)
        {
            Position = position;
        }

        public void Move(string to, string opponentsPosition)
        {
            if (!ValidMovePattern(to))
                throw new InvalidOperationException();
            Position = to;
        }

        bool ValidMovePattern(string to)
        {
            int verticalDistance = VerticalDistanceTo(to);
            var validDistances = new[] {1, 2};
            int horizontalDistance = HorizontalDistanceTo(to);
            return (validDistances.Contains(verticalDistance)
                && validDistances.Contains(horizontalDistance) 
                && (verticalDistance != horizontalDistance)) ;
            
        }

        int VerticalDistanceTo(string to)
        {
            
            var fileTo = (int)(to[0]);
            var fileFrom = (int) (Position[0]);
            return Maths.Abs(fileFrom - fileTo);

        }

        int HorizontalDistanceTo(string to )
        {
            var rankTo = to[1];
            var rankFrom = Position[1];
            return Maths.Abs(rankFrom - rankTo);            
        }
    }

    public interface IPiece
    {
        
        void Move(string to, string opponentsPosition);
    }

    static class PositionExtensions
    {
        public static bool IsOnBoard(this string postion)
        {
            var validRanks = new[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'};
            var validFile = Enumerable.Range(1, 8);
            return (validRanks.Contains(postion[0]) && validFile.Contains(Convert.ToInt32(postion[1].ToString())));


        }
    }
}
