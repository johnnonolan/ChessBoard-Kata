using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
   
    public struct Position
    {
        public static Position NotOnBoard;

        public Position(char y,int x) : this()
        {
            this.x = x;
            this.y = y;
        }

        public readonly int x;
        public readonly char y;

        public override string ToString()
        {
            return string.Format("{0}{1}", y, x);
        }

        public bool Equals(Position other)
        {
            return other.x == x && other.y == y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof (Position)) return false;
            return Equals((Position) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (x*397) ^ y.GetHashCode();
            }
        }
    }

    public abstract class Piece
    {
        public override bool Equals(object obj)
        {
            return GetType() == obj.GetType();
        }

        public abstract MovePattern MovePattern(bool isfirst);

    }

    public class WhitePawn : Piece
    {
        public override string ToString()
        {
            return "White Pawn";
        }

        public override MovePattern MovePattern(bool isfirst)
        {
            if (isfirst) return new PawnInitialPattern();
            return new PawnStandardPattern();
        }
    }

    public class BlackKnight : Piece
    {
        public override string ToString()
        {
            return "Black Knight";
        }

        public override MovePattern MovePattern(bool isfirst)
        {
           throw new NotImplementedException();
        }
    }


    
    public class MovePattern
    {
        public readonly int yoffset;
        protected string failuremessage = "invalid move";

        public MovePattern(int yoffset)
        {
            this.yoffset = yoffset;
        }

        public MovePattern(int yoffset, string failuremessage)
        {
            this.yoffset = yoffset;
            this.failuremessage = failuremessage;
        }

        public bool IsValid(Position from, Position to)
        {
            return (from.y - to.y) < yoffset;
        }
    }

    public class PawnInitialPattern : MovePattern
    {
        public PawnInitialPattern() : base(2, "Pawn cannot move 2 spaces unless it in the first round and is on the home row")
        {
        }
    }

    public class PawnStandardPattern : MovePattern
    {
        public PawnStandardPattern()
            : base(1)
        {
        }
    }


    public class Game
    {
        protected class InPlay
        {
            public InPlay(Piece piece, Position position)
            {
                Piece = piece;
                Position = position;
            }

            public Piece Piece { get; private set; }
            public Position Position { get; private set; }

            public void MoveTo(Position position)
            {
                Position = position;
            }
        }


        protected class Move
        {
            readonly Position from;
            Position to;
            Piece piece;
            readonly bool isfirst;

            public Move(Position from,Position to, Piece piece,bool isfirst)
            {
                this.from = from;
                this.to = to;
                this.piece = piece;
                this.isfirst = isfirst;
            }

            public bool Valid()
            {
                return !OutOfBounds() && MoveIsValidPattern();
            }

            MoveResult MoveIsValidPattern()
            {
                var pattern = piece.MovePattern(isfirst)

                return new MoveResult(pattern);


            }

            bool OutOfBounds()
            {
                return to.x < 0 || to.x > 8 || to.y < 'A' || to.y > 'H';
            }

            public void Apply(IEnumerable<InPlay> inplay)
            {
                inplay.Where(i => i.Piece.Equals(piece))
                    .First()
                    .MoveTo(to);
            }
        }

        protected IList<InPlay> piecesinplay = new List<InPlay>();
        bool isfirst = true;
        public string Message { get; protected set; }
     
        public void MovePieceTo(Piece piece,Position to)
        {
            var toMove = piecesinplay.Where(p => p.Piece.Equals(piece))
                .FirstOrDefault();

            if (toMove == null) throw new InvalidOperationException("No such piece in play " +  piece);

            var move = new Move(toMove.Position,to,piece,isfirst);

            if(move.Valid())
            {
                move.Apply(piecesinplay);
                Announce(piece, to);
            }
            else
                AnnounceIllegalMove();

            isfirst = false;
        }

        void AnnounceIllegalMove()
        {
            Message = "illegal move";
        }

        void Announce(Piece piece, Position position)
        {
            Message = string.Format("{0} to {1}", piece, position);
        }

        public Piece GetPieceAtPosition(Position position)
        {
            return piecesinplay.Where(i => i.Position.Equals(position))
                .Select(i => i.Piece)
                .FirstOrDefault();
        }

        public void HasValidMoves(string move)
        {

        }

        public void PutPieceInPlay(Piece piece, Position position)
        {
            piecesinplay.Add(new InPlay(piece,position));
        }
    }

    class MoveResult
    {
        public readonly bool Valid;
        public readonly string Message;
        public MoveResult(bool valid, string message)
        {
            Valid = valid;
            Message = message;
        }
    }
}