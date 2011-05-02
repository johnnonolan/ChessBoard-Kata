using System;
using System.Linq;

namespace ChessBoard
{
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
            return Math.Abs(fileFrom - fileTo);

        }

        int HorizontalDistanceTo(string to )
        {
            var rankTo = to[1];
            var rankFrom = Position[1];
            return Math.Abs(rankFrom - rankTo);            
        }

        public void SetTaken()
        {
            Position = "Taken";
        }
    }
}