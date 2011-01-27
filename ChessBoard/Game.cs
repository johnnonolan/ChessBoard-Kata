using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ChessBoard
{
    public class Game
    {
        bool _whitesGo;
        readonly List<string> _validLocations = new List<string>();
        readonly string[] _columns = new[] {"A", "B", "C", "D", "E", "F", "G", "H"};
        public IPiece PieceTaken { get; private set; }
        public string Message { get; private set; }
        public Pawn WhitePawn { get; set; }
        public Knight BlackKnight { get; set; }
        public Game()
        {
            BuildValidLocations();

            _whitesGo = true;
            Message=
                "";
        }

        public void SetWhitesStartLocation(string location)
        {
            WhitePawn = new Pawn(location, null);
        }

        public void NextMove(string location)
        {
            if (!ValidLocation(location))
            {
                Message = "Illegal move! Try again";
                return;
            }


            if (_whitesGo)
            {
                if (movingOnSameColumn(location)&& BlackKnight.Location == location)
                {
                    Message = "Pawn collides with Knight. Draw";
                    return;
                }

                if(PawnTakingMove(location))
                {
                    if (BlackKnight.Location != location)
                    {
                        Message = "Pawn cannot diagonally unless it is capturing a piece.";
                        return;
                    }
                    Message = "Pawn takes Knight. Pawn wins";
                    PieceTaken = BlackKnight;
                    WhitePawn.Move(location);
                    return;
                }

                WhitePawn.Move(location);
                Message = String.Format("Pawn to {0}", location);

            }
            else
            {

                BlackKnight.Move(location);
                if(WhitePawn.Location == location)
                {
                    PieceTaken = WhitePawn;
                    Message = "Knight takes Pawn. Knight Wins";
                } else
                Message = String.Format("Knight to {0}", location);
                
            }
            _whitesGo = !_whitesGo;
        }

        bool PawnTakingMove(string location)
        {
            var colList = _columns.ToList();
            var colIndex = colList.IndexOf(location[0].ToString());
            var colIndexofPawn = colList.IndexOf(WhitePawn.Location[0].ToString());
            return (((colIndex - colIndexofPawn)*(colIndex - colIndexofPawn) == 1) &&
                    location[1] - WhitePawn.Location[1] == 1);

        }

        bool movingOnSameColumn(string location)
        {
            return WhitePawn.Location[0]==location[0];
        }

        bool ValidLocation(string location)
        {
            return _validLocations.Contains(location);
        }

        void BuildValidLocations()
        {
            var rows = Enumerable.Range(1, 8);

            foreach (var column in _columns)
            {
                var innerColumn = column;
                _validLocations.AddRange(rows.Select(row => innerColumn + row));
            }
        }

        public void SetBlacksStartLocation(string location)
        {
            BlackKnight = new Knight( location,new KnightMovementRules());
        }
    }

    public class KnightMovementRules : IMovementRules
    {
        public bool IsValidMove(string currentLocation, string newLocation)
        {
            char currentRow = currentLocation[0];
            int currentColumn = currentLocation[1];

            char newRow = newLocation[0];
            int newColumn = newLocation[1];

            if (currentLocation == newLocation)
                return false;
            if (GetPosition(newRow) < 0)
                return false;

            if (GetPosition(newRow) > 8)
                return false;

            
            if(GetPosition(newRow) - GetPosition(currentRow) > 2)
                return false;

            return true;
        }

        int GetPosition(char letter)
        {
            return letter - 'A' + 1;
        }
    }
}