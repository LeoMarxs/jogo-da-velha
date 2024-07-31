public class Program
{
    private static void Main(string[] args)
    {
        string[] grid = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        bool player1Turn = true;
        int numTurns = 0;
        
        Console.WriteLine("\n+----------------------------+\n"
         + "| BEM VINDO AO JOGO DA VELHA |\n"
         + "+----------------------------+\n");

        while (!CheckVictory() && numTurns != 9)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintGrid();

            if (player1Turn)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nTurno do jogador 1!");
                Console.ForegroundColor = ConsoleColor.Red;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nTurno do jogador 2!");
            }

            string choice = Console.ReadLine();

            if (grid.Contains(choice) && choice != "X" && choice != "O")
            {
                int gridIndex = Convert.ToInt32(choice) - 1;

                if (player1Turn)
                    grid[gridIndex] = "X";
                else
                    grid[gridIndex] = "O";

                numTurns++;
                Console.WriteLine(numTurns);
            }

            player1Turn = !player1Turn;
            Console.Clear();
        }

        PrintGrid();

        if (CheckVictory())
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("+--------------+\n"
            + "| VOCE GANHOU! |\n"
            + "+--------------+\n");
        }
        else
            Console.WriteLine("+----------+\n"
            + "|  VELHA!  |\n"
            + "+----------+\n");

        void PrintGrid()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(" " + grid[i * 3 + j] + " |");
                }

                Console.WriteLine("");
                Console.WriteLine("------------");
            }
        }

        bool CheckVictory()
        {
            bool row1 = grid[0] == grid[1] && grid[1] == grid[2];
            bool row2 = grid[3] == grid[4] && grid[4] == grid[5];
            bool row3 = grid[6] == grid[7] && grid[7] == grid[8];
            bool col1 = grid[0] == grid[3] && grid[3] == grid[6];
            bool col2 = grid[1] == grid[4] && grid[4] == grid[7];
            bool col3 = grid[2] == grid[5] && grid[5] == grid[8];
            bool diagDown = grid[0] == grid[4] && grid[4] == grid[8];
            bool diagUp = grid[6] == grid[4] && grid[4] == grid[2];

            return row1 || row2 || row3 || col1 || col2 || col3 || diagDown || diagUp;
        }
    }
}