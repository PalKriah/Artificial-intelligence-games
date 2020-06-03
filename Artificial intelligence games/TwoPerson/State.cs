using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Artificial_intelligence_games.TwoPerson
{
    public class State
    {
        public TokenColor[,] Board { get; set; }

        public State(TokenColor[][] board)
        {
            Board = new TokenColor[board.Length, board.Length];
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    Board[i, j] = board[i][j];
                }
            }
        }

        public State(State state)
        {
            Board = (TokenColor[,])state.Board.Clone();
        }

        public bool IsEndState
        {
            get
            {
                for (int i = 0; i < Board.GetLength(0); i++)
                {
                    if (
                      Board[i, 0] != TokenColor.Empty && Board[i, 1] == Board[i, 0] && Board[i, 2] == Board[i, 0] ||
                      Board[0, i] != TokenColor.Empty && Board[1, i] == Board[0, i] && Board[2, i] == Board[0, i]
                    )
                    {
                        return true;
                    }
                }
                if (
                  Board[0, 0] != TokenColor.Empty && Board[1, 1] == Board[0, 0] && Board[2, 2] == Board[0, 0] ||
                  Board[0, 2] != TokenColor.Empty && Board[1, 1] == Board[0, 2] && Board[2, 0] == Board[0, 2]
                )
                {
                    return true;
                }
                return false;
            }
        }

        public void Move(Operator @operator)
        {
            if (preMove(@operator))
            {
                switch (Board[@operator.Place.X, @operator.Place.Y])
                {
                    case TokenColor.Yellow:
                        Board[@operator.Place.X, @operator.Place.Y] = TokenColor.Green;
                        return;
                    case TokenColor.Red:
                        Board[@operator.Place.X, @operator.Place.Y] = TokenColor.Yellow;
                        return;
                    case TokenColor.Empty:
                        Board[@operator.Place.X, @operator.Place.Y] = TokenColor.Red;
                        return;
                }
            }
        }

        private bool preMove(Operator @operator)
        {
            if (Board[@operator.Place.X, @operator.Place.Y] != TokenColor.Green)
            {
                return true;
            }
            return false;
        }

        public List<Operator> GetValidOperators()
        {
            List<Operator> operators = new List<Operator>();

            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(0); j++)
                {
                    if (Board[i, j] != TokenColor.Green)
                    {
                        operators.Add(new Operator(new Point(i, j)));
                    }
                }
            }

            return operators;
        }

        private int[] RowState(int row)
        {
            int[] colors = new int[4];
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                colors[(int)Board[row, i]] += 1;
            }
            return colors;
        }

        private int[] ColumnState(int column)
        {
            int[] colors = new int[4];
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                colors[(int)Board[i, column]] += 1;
            }
            return colors;
        }

        private int[] DiagonalState(bool inv = false)
        {
            int[] colors = new int[4];
            if (!inv)
            {
                for (int i = 0; i < Board.GetLength(0); i++)
                {
                    colors[(int)Board[i, i]] += 1;
                }
            }
            else
            {
                for (int i = 0; i < Board.GetLength(0); i++)
                {
                    colors[(int)Board[i, Board.GetLength(0) - 1 - i]] += 1;
                }
            }
            return colors;
        }

        public int Heuristic
        {
            get
            {
                if (IsEndState)
                {
                    return 50;
                }
                int count = 0;
                for (int i = 0; i < Board.GetLength(0); i++)
                {
                    count += EvalLine(RowState(i)) + EvalLine(ColumnState(i));
                }
                count += EvalLine(DiagonalState()) + EvalLine(DiagonalState(true));

                return count;
            }
        }

        private int EvalLine(int[] colors)
        {
            for (int i = 0; i < colors.Length - 1; i++)
            {
                if (colors[i] == 2 && colors[i + 1] == 1)
                {
                    return -5;
                }
            }
            return 0;
        }
    }
}
