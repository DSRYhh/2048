using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    public class Game
    {

        private static readonly int EmptySymbol = 0;
        private static readonly int InitialPieceNumber = 2;
        public static readonly int _boardSize = 4;

        public int BoardSize
        {
            get { return _boardSize; }
        }

        private readonly int[,] board = new int[_boardSize, _boardSize];
        private readonly Random random = new Random();

        public int[,] Board => board;

        public Game()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = EmptySymbol;
                }
            }

            for (int i = 0; i < InitialPieceNumber; i++)
            {
                PutNewPiece();
            }
        }

        public Game(int[,] b)
        {
            this.board = b;
        }

        public bool Up()
        {
            if (GameOver())
            {
                return false;
            }
            bool moved = false;
            for (int column = 0; column < _boardSize; column++)
            {
                for (int row = 0; row < _boardSize - 1; row++)
                {
                    for (int nextRow = row + 1; nextRow < _boardSize; nextRow++)
                    {
                        if (!IsEmpty(nextRow, column))
                        {
                            if (!IsEmpty(row, column) && board[row, column] == board[nextRow, column])
                            {
                                board[row, column] += board[nextRow, column];
                                board[nextRow, column] = EmptySymbol;
                                moved = true;
                                break;
                            }
                            else if (!IsEmpty(row, column) && board[row, column] != board[nextRow, column])
                            {
                                break;
                            }
                            else if (IsEmpty(row, column))
                            {
                                board[row, column] = board[nextRow, column];
                                board[nextRow, column] = EmptySymbol;
                                moved = true;
                            }
                        }
                    }
                }
            }
            if (moved)
            {
                PutNewPiece();
            }
            return moved;
        }

        public bool IsUpAvailbe()
        {
            bool moved = false;
            for (int column = 0; column < _boardSize; column++)
            {
                for (int row = 0; row < _boardSize - 1; row++)
                {
                    for (int nextRow = row + 1; nextRow < _boardSize; nextRow++)
                    {
                        if (!IsEmpty(nextRow, column))
                        {
                            if (!IsEmpty(row, column) && board[row, column] == board[nextRow, column])
                            {
                                return true;
                            }
                            else if (!IsEmpty(row, column) && board[row, column] != board[nextRow, column])
                            {
                                break;
                            }
                            else if (IsEmpty(row, column))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool Down()
        {
            if (GameOver())
            {
                return false;
            }
            bool moved = false;
            for (int column = 0; column < _boardSize; column++)
            {
                for (int row = _boardSize - 1; row >= 1; row--)
                {
                    for (int nextRow = row - 1; nextRow >= 0; nextRow--)
                    {
                        if (!IsEmpty(nextRow, column))
                        {
                            if (!IsEmpty(nextRow, column))
                            {
                                if (!IsEmpty(row, column) && board[row, column] == board[nextRow, column])
                                {
                                    board[row, column] += board[nextRow, column];
                                    board[nextRow, column] = EmptySymbol;
                                    moved = true;
                                    break;
                                }
                                else if (!IsEmpty(row, column) && board[row, column] != board[nextRow, column])
                                {
                                    break;
                                }
                                else if (IsEmpty(row, column))
                                {
                                    board[row, column] = board[nextRow, column];
                                    board[nextRow, column] = EmptySymbol;
                                    moved = true;
                                }
                            }
                        }
                    }
                }
            }

            if (!moved)
            {
                return false;
            }
            PutNewPiece();
            return true;
        }

        public bool IsDownAvailable()
        {
            bool moved = false;
            for (int column = 0; column < _boardSize; column++)
            {
                for (int row = _boardSize - 1; row >= 1; row--)
                {
                    for (int nextRow = row - 1; nextRow >= 0; nextRow--)
                    {
                        if (!IsEmpty(nextRow, column))
                        {
                            if (!IsEmpty(nextRow, column))
                            {
                                if (!IsEmpty(row, column) && board[row, column] == board[nextRow, column])
                                {
                                    return true;
                                }
                                else if (!IsEmpty(row, column) && board[row, column] != board[nextRow, column])
                                {
                                    break;
                                }
                                else if (IsEmpty(row, column))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        public bool Left()
        {
            if (GameOver())
            {
                return false;
            }
            bool moved = false;
            for (int row = 0; row < _boardSize; row++)
            {
                for (int column = 0; column < _boardSize - 1; column++)
                {
                    for (int nextColumn = column + 1; nextColumn < _boardSize; nextColumn++)
                    {
                        if (!IsEmpty(row, nextColumn))
                        {
                            if (!IsEmpty(row, nextColumn))
                            {
                                if (!IsEmpty(row, column) && board[row, column] == board[row, nextColumn])
                                {
                                    board[row, column] += board[row, nextColumn];
                                    board[row, nextColumn] = EmptySymbol;
                                    moved = true;
                                    break;
                                }
                                else if (!IsEmpty(row, column) && board[row, column] != board[row, nextColumn])
                                {
                                    break;
                                }
                                else if (IsEmpty(row, column))
                                {
                                    board[row, column] = board[row, nextColumn];
                                    board[row, nextColumn] = EmptySymbol;
                                    moved = true;
                                }
                            }
                        }
                    }
                }
            }
            if (!moved)
            {
                return false;
            }
            PutNewPiece();
            return true;
        }

        public bool IsLeftAvailable()
        {
            bool moved = false;
            for (int row = 0; row < _boardSize; row++)
            {
                for (int column = 0; column < _boardSize - 1; column++)
                {
                    for (int nextColumn = column + 1; nextColumn < _boardSize; nextColumn++)
                    {
                        if (!IsEmpty(row, nextColumn))
                        {
                            if (!IsEmpty(row, nextColumn))
                            {
                                if (!IsEmpty(row, column) && board[row, column] == board[row, nextColumn])
                                {
                                    return true;
                                }
                                else if (!IsEmpty(row, column) && board[row, column] != board[row, nextColumn])
                                {
                                    break;
                                }
                                else if (IsEmpty(row, column))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
    
        public bool Right()
        {
            if (GameOver())
            {
                return false;
            }
            bool moved = false;
            for (int row = 0; row < _boardSize; row++)
            {
                moved = true;
                for (int column = _boardSize - 1; column >= 1; column--)
                {
                    for (int nextColumn = column - 1; nextColumn >= 0; nextColumn--)
                    {
                        if (!IsEmpty(row, nextColumn))
                        {
                            if (!IsEmpty(row, nextColumn))
                            {
                                if (!IsEmpty(row, column) && board[row, column] == board[row, nextColumn])
                                {
                                    board[row, column] += board[row, nextColumn];
                                    board[row, nextColumn] = EmptySymbol;
                                    moved = true;
                                    break;
                                }
                                else if (!IsEmpty(row, column) && board[row, column] != board[row, nextColumn])
                                {
                                    break;
                                }
                                else if (IsEmpty(row, column))
                                {
                                    board[row, column] = board[row, nextColumn];
                                    board[row, nextColumn] = EmptySymbol;
                                    moved = true;
                                }
                            }
                        }
                    }
                }
            }
            if (!moved)
            {
                return false;
            }
            PutNewPiece();
            return true;
        }

        public bool IsRightAvailable()
        {
            for (int row = 0; row < _boardSize; row++)
            {
                for (int column = _boardSize - 1; column >= 1; column--)
                {
                    for (int nextColumn = column - 1; nextColumn >= 0; nextColumn--)
                    {
                        if (!IsEmpty(row, nextColumn))
                        {
                            if (!IsEmpty(row, nextColumn))
                            {
                                if (!IsEmpty(row, column) && board[row, column] == board[row, nextColumn])
                                {
                                    return true;
                                }
                                else if (!IsEmpty(row, column) && board[row, column] != board[row, nextColumn])
                                {
                                    break;
                                }
                                else if (IsEmpty(row, column))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private bool IsColumnFull(int column)
        {
            for (int i = 0; i < _boardSize; i++)
            {
                if (board[i,column] == EmptySymbol)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsRowFull(int row)
        {
            for (int i = 0; i < _boardSize; i++)
            {
                if (board[row,i] == EmptySymbol)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Put a new piece on the board.
        /// </summary>
        /// <returns>If put successfully, return true. If game over, return false.</returns>
        private bool PutNewPiece(int[] position)
        {
            if (position.Length != 2)
            {
                throw new ArgumentException();
            }
            if (position[0] < 0 || position[0] >= _boardSize)
            {
                throw new ArgumentException();
            }
            if (position[1] < 0 || position[1] >= _boardSize)
            {
                throw new ArgumentException();
            }

            int pieceNum = NewPieceNumber();
            Debug.Assert(board[position[0], position[1]] == EmptySymbol);
            board[position[0], position[1]] = pieceNum;
            return true;
        }

        /// <summary>
        /// Put a new piece in a random empty position.
        /// </summary>
        /// <returns>If put successfully, return true. If game over, return false.</returns>
        private bool PutNewPiece()
        {
            var position = RandomEmptyPosition();
            return PutNewPiece(position);
        }

        private static int NewPieceNumber()
        {
            var rdn = new Random();
            var randomNumber = rdn.Next(1, 3);

            switch (randomNumber)
            {
                case 1:
                    return 2;
                case 2:
                    return 4;
                default:
                    throw new Exception();
            }

        }

        /// <summary>
        /// Return a random empty postion on the board.
        /// </summary>
        /// <returns>An array with two elements in. The first element is row, second is column.</returns>
        private int[] RandomEmptyPosition()
        {
            int emptyCount = EmptyCount();
            int position = random.Next(0,emptyCount);

            int count = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i,j] == EmptySymbol)
                    {
                        if (count == position)
                        {
                            Debug.Assert(board[i, j] == EmptySymbol);
                            return new[] { i, j };
                        }
                        count++;
                    }
                }
            }
            throw new ArgumentException();
        }
        /// <summary>
        /// The number of empty place on the board.
        /// </summary>
        /// <returns></returns>
        private int EmptyCount()
        {
            return board.Cast<int>().Count(entry => entry == EmptySymbol);
        }
        /// <summary>
        /// Check if the board is full.
        /// </summary>
        /// <returns></returns>
        public bool GameOver()
        {
            if (IsUpAvailbe())
            {
                return false;
            }
            if (IsDownAvailable())
            {
                return false;
            }
            if (IsLeftAvailable())
            {
                return false;
            }
            if (IsRightAvailable())
            {
                return false;
            }
            return true;
        }

        private bool IsEmpty(int[] position)
        {
            if (position.Length != 2)
            {
                throw new ArgumentException();
            }
            if (position[0] < 0 || position[0] >= _boardSize)
            {
                throw new ArgumentException();
            }
            if (position[1] < 0 || position[1] >= _boardSize)
            {
                throw new ArgumentException();
            }

            return board[position[0], position[1]] == EmptySymbol;
        }

        private bool IsEmpty(int row, int column)
        {
            if (row < 0 || row >= _boardSize)
            {
                throw new ArgumentException();
            }
            if (column < 0 || column >= _boardSize)
            {
                throw new ArgumentException();
            }

            return board[row, column] == EmptySymbol;
        }

        public int MaxPiece()
        {
            return board.Cast<int>().Concat(new[] {0}).Max();
        }
    }
}
