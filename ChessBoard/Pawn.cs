using System;

namespace ChessBoard
{
    public class Pawn : IPiece
    {
        int _validDistance;

        public string Position { get; private set; }

        public Pawn(string position)
        {
            Position = position;
            const char homeRow = '2';
                _validDistance = position[1] == homeRow ? 2 : 1;

        }

        public void Move(string to, string opponentsPosition)
        {
            if (!ValidStandardMovePattern(to))
            {
                if (TakingMovePattern(to))
                {
                    if (to != opponentsPosition)
                        throw new InvalidOperationException("Illegal Move: Pawn cannot diagonally unless it is capturing a piece.");
                    Position = to;
                }
                else
                {
                    if (HomeRowMovePattern(to))
                        throw new InvalidOperationException("Illegal Move: pawn cannot move 2 spaces unless it in the first round and is on the home row. ");
                    throw new InvalidOperationException("Illegal Move");
                }
                    
            }
            if ((to == opponentsPosition) && ValidStandardMovePattern(to))
            {

                throw new InvalidOperationException("pawn collides with knight. draw");
            } 
            Position = to;
            _validDistance = 1;

        }

        bool HomeRowMovePattern(string to)
        {
            return (Position[0] == to[0]) && (to[1] - Position[1] > 1);
        }

        bool TakingMovePattern(string to)
        {
            var verticalDistance = to[1] - Position[1];
            var horizontalDistance = (int)to[0] - Position[0];
            return (Math.Abs(horizontalDistance) == 1) && (verticalDistance == 1);
        }

        bool ValidStandardMovePattern(string to)
        {
            int distance = to[1] - Position[1];
            return Position[0] == to[0] && ( distance > 0 && distance <= _validDistance );
        }

        public void SetTaken()
        {
            Position = "Taken";
        }
    }
}