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

        public string PawnPosition
        {
            get { return _pawn.Position; }
            
        }

        public string KnightPosition
        {
            get { return _knight.Position; }
        }

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
                    throw new InvalidOperationException("Illegal Move");
                }

                _pawn.Move(to, _knight.Position);
                if ((to == _knight.Position) && (to[0] == _knight.Position[0]))
                    Message = "pawn collides with knight. draw";
                else if ((to == _knight.Position) && (to[0] != _knight.Position[0]))
                {
                    _knight.SetTaken();
                    Message  =  "Pawn takes Knight. Pawn wins";
                } else
                    Message = String.Format("Pawn to {0}", to);
            } 
            catch (InvalidOperationException ex)
            {
                Message = ex.Message;
            }                                                 
        }

        public void MoveKnight(string to)
        {
            try
            {
                if (!to.IsOnBoard())
                {
                    throw new InvalidOperationException("Illegal Move");
                }
                
                _knight.Move(to, _pawn.Position);
                if (to == _pawn.Position)
                {
                    _pawn.SetTaken();
                    Message = "knight takes pawn. knight wins";
                } else
                    Message = String.Format("Knight to {0}", to);
            }
            catch (InvalidOperationException ex)
            {
                Message = ex.Message;
            }                                                 
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
                throw new InvalidOperationException("Illegal move");
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

        public void SetTaken()
        {
            Position = "Taken";
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
