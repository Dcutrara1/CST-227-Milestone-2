using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_1___Grid_Based_Game
{
    // Change Grid Class to Abstract
    abstract class Grid
    {       
        public int Bombs { get; private set; }
        public Game_Cell[,] Board { get; private set; }

        // Add IPlayable interface with void PlayGame() Method.
        public interface IPlayable
        {
            void PlayGame();                       
        }

        public Grid()
        {       
            
        }

        public void getCount()
        {
            int var = Game_Cell.Count;
        }

        // Creates the Game Board
        public void BuildBoard(int Rows, int Cols)
        {
            Board = new Game_Cell[Rows, Cols];
            for (int r = 0; r < Rows; ++r)
            {
                for (int c = 0; c < Cols; ++c)
                {
                    Board[r, c] = new Game_Cell();
                }
            }
        }       

        // Selects the Cells that have Active Bombs randomly between 15-20% of the cells. 
        public void ActivateBombs(int Rows, int Cols)
        {
            double activate;
            Random rand = new Random(DateTime.Now.Millisecond);
            int gridSize = Board.GetLength(0) * Board.GetLength(1);
            double percentage = rand.Next(15, 20) + 1;
            percentage = (percentage * .01);
            activate = percentage * gridSize;
            activate = Math.Round(activate);            
            int activated = 0;

            // Activates the bombs
            while (activated < activate)
            {
                int x = rand.Next(0, Board.GetLength(0));
                int y = rand.Next(0, Board.GetLength(1));               
               
                if (Board[x, y].Bomb == false)
                {
                    Board[x, y].Bomb = true;                   
                    activated++;                    
                }
            }
        }

        // Determines which neighbors surrounding have Bombs. 
        public void LocateNeighbors(int Rows, int Cols)
        {
            for (int c = 0; c < Board.GetLength(1); ++c)

                for (int r = 0; r < Board.GetLength(0); ++r)
                {
                    if ((c - 1) >= 0 && Board[r, (c - 1)].Bomb == true)
                    { Board[r, c].BombLeft = true; }

                    if ((c + 1) < Board.GetLength(1) && Board[r, (c + 1)].Bomb == true)
                    { Board[r, c].BombRight = true; }

                    if ((r - 1) >= 0 && Board[(r - 1), c].Bomb == true)
                    { Board[r, c].BombUp = true; }

                    if ((r + 1) < Board.GetLength(0) && Board[(r + 1), c].Bomb == true)
                    { Board[r, c].BombDown = true; }

                    if ((r - 1) >= 0 && (c - 1) > 0 && Board[(r - 1), (c - 1)].Bomb == true)
                    { Board[r, c].BombUpLeft = true; }

                    if ((r + 1) < Board.GetLength(0) && (c - 1) >= 0 && Board[(r + 1), (c - 1)].Bomb == true)
                    { Board[r, c].BombDownLeft = true; }

                    if ((r - 1) >= 0 && (c + 1) < Board.GetLength(1) && Board[(r - 1), (c + 1)].Bomb == true)
                    { Board[r, c].BombUpRight = true; }

                    if ((r + 1) < Board.GetLength(0) && (c + 1) < Board.GetLength(1) &&
                            Board[(r + 1), (c + 1)].Bomb == true)
                    { Board[r, c].BombDownRight = true; }
                }                                   
            }

        // Method created as overriding method.
        public virtual void Reveal(int Rows, int Cols)
        {
            Console.Write("\nThe board is : \n");
            Console.WriteLine(" ");
            for (int c = 0; c < Board.GetLength(1); ++c)
            {
                for (int r = 0; r < Board.GetLength(0); ++r)
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

                    if (Game_Cell.Count == 9)
                    { Console.Write("*" + " "); }

                    if (Game_Cell.Count == 0)
                    { Console.Write(" "+ " "); }

                    if (Game_Cell.Count != 0 && Game_Cell.Count != 9)
                    { Console.Write(Game_Cell.Count + " "); }
                    
                }
                Console.WriteLine();
            }           
        }        
    }
}
