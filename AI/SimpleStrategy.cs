using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2048;

namespace AI
{
    public enum Direction
    {
        Up,Down,Left,Right
    }

    public class SimpleStrategy
    {
        public static Direction NextDirection(Game2048.Game game)
        {
            if (game.IsUpAvailbe())
            {
                return Direction.Up;
            }
            else if (game.IsLeftAvailable())
            {
                return Direction.Left;
            }
            else if (game.IsDownAvailable())
            {
                return Direction.Down;
            }
            else
            {
                return Direction.Right;
            }
        }
    }
}
