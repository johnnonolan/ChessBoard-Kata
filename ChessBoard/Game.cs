using System;
using System.Linq;

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
                var originalPosition = PawnPosition;
                _pawn.Move(to, _knight.Position);
                if ((to == _knight.Position))
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
