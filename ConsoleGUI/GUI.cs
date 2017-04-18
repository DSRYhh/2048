namespace ConsoleGUI
{
    public static class GUI
    {
        public static string ConsoleString(this Game2048.Game game)
        {
            var board = game.Board;
            string str = string.Empty;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    str += $"{board[i, j]}\t";
                }
                str += "\r\n";
            }

            return str;
        }
    }
}