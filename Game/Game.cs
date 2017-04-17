using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Game
    {
        
        private static readonly int EmptySymbol = -1;
        private int[,] board = new int[4, 4];

        public Game()
        {
            
        }

        /// <summary>
        /// Put a new piece on the board.
        /// </summary>
        /// <returns>If put successfully, return true. If game over, return false.</returns>
        public bool PutNewPiece()
        {
            if (GameOver())
            {
                return false;
            }

            int pieceNum = NewPieceNumber();
            var position = RandomEmptyPosition();

            board[position[0], position[1]] = pieceNum;
            return true;
        }

        private int NewPieceNumber()
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
            int position = new Random().Next(0,emptyCount);

            int count = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++,count++)
                {
                    if (count == emptyCount)
                    {
                        return new[] {i, j};
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
        private bool GameOver()
        {
            return EmptyCount() == 0;
        }
    }
}
