using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Artificial_intelligence_games.OnePerson
{
    public class State
    {
        public ChessPiece[,] Board { get; set; }

        public State()
        {
            Board = new ChessPiece[2, 3] {
                { ChessPiece.King, ChessPiece.Bishop, ChessPiece.Bishop },
                { ChessPiece.Rook, ChessPiece.Rook, ChessPiece.Empty }
            };
        }

        public State(State state)
        {
            Board = (ChessPiece[,])state.Board.Clone();
        }

        public bool IsEndState
        {
            get
            {
                return Board[0, 0] == ChessPiece.Bishop && Board[0, 1] == ChessPiece.Bishop && Board[0, 2] == ChessPiece.Empty &&
                    Board[1, 0] == ChessPiece.Rook && Board[1, 1] == ChessPiece.Rook && Board[1, 2] == ChessPiece.King;
            }
        }

        public void Move(Operator @operator)
        {
            if (preMove(@operator))
            {
                Board[@operator.From.X, @operator.From.Y] = ChessPiece.Empty;
                Board[@operator.To.X, @operator.To.Y] = @operator.Piece;
            }
        }

        private bool preMove(Operator @operator)
        {
            return @operator.To.Equals(Empty) &&
                @operator.From.X - 1 <= @operator.To.X && @operator.From.X + 1 >= @operator.To.X &&
                @operator.From.Y - 1 <= @operator.To.Y && @operator.From.Y + 1 >= @operator.To.Y - 1 &&
                ValidMoveOfPiece(@operator.From, @operator.To, @operator.Piece);
        }

        public List<Operator> GetValidOperators()
        {
            Point empty = Empty;
            List<Operator> operators = new List<Operator>();

            for (int i = empty.X - 1; i <= empty.X + 1; i++)
            {
                if (i >= 0 && i < 2)
                {
                    for (int j = empty.Y - 1; j <= empty.Y + 1; j++)
                    {
                        if (j >= 0 && j < 3)
                        {
                            Point point = new Point(i, j);
                            if (!(point.X == empty.X && point.Y == empty.Y) && ValidMoveOfPiece(point, empty, Board[i, j]))
                            {
                                operators.Add(new Operator(point, empty, Board[i, j]));
                            }
                        }
                    }
                }
            }

            return operators;
        }

        private bool ValidMoveOfPiece(Point from, Point to, ChessPiece piece)
        {
            switch (piece)
            {
                case ChessPiece.King:
                    return true;
                case ChessPiece.Rook:
                    if ((from.X == to.X && from.Y != to.Y) || (from.X != to.X && from.Y == to.Y))
                    {
                        return true;
                    }
                    break;
                case ChessPiece.Bishop:
                    if (from.X != to.X && from.Y != to.Y)
                    {
                        return true;
                    }
                    break;
                case ChessPiece.Empty:
                    break;
                default:
                    break;
            }
            return false;
        }

        public int Heuristic
        {
            get
            {
                int count = 0;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        count += calcDistance(Board[i, j], new Point(i, j));
                    }
                }
                return count;
            }
        }

        private Point Empty
        {
            get
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (Board[i, j] == ChessPiece.Empty)
                        {
                            return new Point(i, j);
                        }
                    }
                }
                return null;
            }
        }

        public static int calcDistance(ChessPiece piece, Point point)
        {
            switch (piece)
            {
                case ChessPiece.King:
                    return Math.Max(Math.Abs(point.X - 1), Math.Abs(point.Y - 2));
                case ChessPiece.Rook:
                    return Math.Abs(point.X - 1) + Math.Min(point.Y, Math.Abs(point.Y - 1));
                case ChessPiece.Bishop:
                    return Math.Max(point.Y, point.Y - 1);
                default:
                    return 0;
            }
        }

        public override bool Equals(object obj)
        {
            State OtherState = (State)obj;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[i, j] != OtherState.Board[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
