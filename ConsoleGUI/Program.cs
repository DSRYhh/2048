using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI;
using Game2048;

namespace ConsoleGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //var initBoard = new[,] {{16, 4, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}};

            for (int i = 0; i < 100; i++)
            {
                Game game = new Game();
                var result = AiController(game, false);

                Console.Write(result.MaxPiece().ToString() + ",");
            }

            //while (true)
            //{
            //    Console.ReadLine();
            //}
        }

        public static Game AiController(Game game, bool output)
        {
            if (output)
            {
                Console.WriteLine(game.ConsoleString());
            }
            while (!game.GameOver())
            {
                var next = AI.SimpleStrategy.NextDirection(game);

                switch (next)
                {
                    case Direction.Up:
                        game.Up();
                        if (output)
                        {
                            Console.WriteLine("Up");
                        }
                        break;
                    case Direction.Down:
                        game.Down();
                        if (output)
                        {
                            Console.WriteLine("Down");
                        }
                        break;
                    case Direction.Left:
                        game.Left();
                        if (output)
                        {
                            Console.WriteLine("Left");
                        }
                        break;
                    case Direction.Right:
                        game.Right();
                        if (output)
                        {
                            Console.WriteLine("Right");
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                if (output)
                {
                    Console.WriteLine(game.ConsoleString());
                }
            }
            if (output)
            {
                Console.WriteLine("Game Over");
            }

            return game;
        }

        public static void ConsoleController(Game game)
        {
            Console.WriteLine(game.ConsoleString());
            while (!game.GameOver())
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        game.Left();
                        break;
                    case ConsoleKey.RightArrow:
                        game.Right();
                        break;
                    case ConsoleKey.DownArrow:
                        game.Down();
                        break;
                    case ConsoleKey.UpArrow:
                        game.Up();
                        break;
                    default:
                        break;
                }
                Console.WriteLine(game.ConsoleString());
            }

            Console.WriteLine("Game Over");
        }
    }
}
