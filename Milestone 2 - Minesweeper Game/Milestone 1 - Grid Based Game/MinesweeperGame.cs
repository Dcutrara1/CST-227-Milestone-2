using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone_1___Grid_Based_Game
{
    class MinesweeperGame : Grid
    {
        // Variables
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public bool GameOver = false;

        public MinesweeperGame(int Rows, int Cols)
        {
        }

        public void PlayGame()
        {
            Reveal(Rows, Cols);
            GetInput();
        }

        public void GetInput()
        {
            // Get input from user
            Console.WriteLine(" ");
            Console.WriteLine("Enter the Row position you chose between 0 and "
                + (Board.GetLength(0) - 1) + ": ");

            // Verify User Input
            if (int.TryParse(Console.ReadLine(), out int inputRow))
            {
                if (inputRow >= 0 && inputRow < Board.GetLength(0))
                {
                    Console.WriteLine(" Enter the Column position you chose between 0 and "
                        + (Board.GetLength(1) - 1) + ": ");

                    if (int.TryParse(Console.ReadLine(), out int inputCol))
                    {
                        if (inputCol >= 0 && inputCol < Board.GetLength(1))
                        {
                            if (Board[inputRow, inputCol].Visited == true)
                            {
                                Console.WriteLine("Cell already visited.");
                                Console.ReadLine();
                                Console.Clear();
                                PlayGame();
                            }

                            if (Board[inputRow, inputCol].Bomb == false)
                            {
                                Board[inputRow, inputCol].Visited = true;
                                Console.Clear();
                                PlayGame();
                            }

                            if (Board[inputRow, inputCol].Bomb == true)

                            {
                                GameOver = true;
                                Console.Clear();
                                Console.WriteLine(" ");
                                Console.Write("You Selected: " + inputRow + ", " + inputCol + ". ");
                                Console.WriteLine("You hit a BOMB!");
                                base.Reveal(inputRow, inputCol);
                                Console.WriteLine(" ");
                                Console.WriteLine("Game Over"); Console.ReadLine();
                                GameOverSteps();
                            }
                        }
                    }
                    else { Console.WriteLine("Enter a valid Column."); }
                    GetInput();
                }
                else { Console.WriteLine("Enter a valid Row."); }
                GetInput();
            }
        }

        public void GameOverSteps()
        {
            if (GameOver == true)
            {
                //Close the current process
                Environment.Exit(0);
            }
        }

        public override void Reveal(int Rows, int Cols)
        {
            Console.Write("\nThe board is : \n");
            Console.WriteLine(" ");
            for (int c = 0; c < Board.GetLength(1); ++c)
            {
                for (int r = 0; r < Board.GetLength(0); ++r)
                {
                    // If Cell has not been visited, place a ?
                    if (Board[r, c].Visited == false)
                    { Console.Write("?" + " "); }

                    // If Cell has been visited, Display number of bombs surrounding or ~ if 0.
                    if (Board[r, c].Visited == true)
                    {
                        Game_Cell.Count = 0;

                        if (Board[r, c].BombLeft == true) { Game_Cell.Count++; }
                        if (Board[r, c].BombRight == true) { Game_Cell.Count++; }
                        if (Board[r, c].BombUp == true) { Game_Cell.Count++; }
                        if (Board[r, c].BombDown == true) { Game_Cell.Count++; }
                        if (Board[r, c].BombUpLeft == true) { Game_Cell.Count++; }
                        if (Board[r, c].BombUpRight == true) { Game_Cell.Count++; }
                        if (Board[r, c].BombDownLeft == true) { Game_Cell.Count++; }
                        if (Board[r, c].BombDownRight == true) { Game_Cell.Count++; }
                        if (Board[r, c].Bomb == true) { Game_Cell.Count = 9; }                                               

                        if (Game_Cell.Count == 0)
                        { Console.Write("~" + " "); }

                        if (Game_Cell.Count != 0 && Game_Cell.Count != 9)
                        { Console.Write(Game_Cell.Count + " "); }
                    }
                }
                Console.WriteLine();                
            }
        }
    }
}