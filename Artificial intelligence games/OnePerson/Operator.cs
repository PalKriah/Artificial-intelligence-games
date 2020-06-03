using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artificial_intelligence_games.OnePerson
{
    public class Operator
    {
        public Point From { get; set; }
        public Point To { get; set; }
        public ChessPiece Piece { get; set; }

        public Operator(Point from, Point to, ChessPiece piece)
        {
            From = from;
            To = to;
            Piece = piece;
        }
    }
}
