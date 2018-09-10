using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Name:        Daniel Cutrara
// Class:       CST-227
// Date:        9/09/2018
// Instructor:  James Shinevar

namespace Milestone_1___Grid_Based_Game
{
    class Driver
    {      
        static void Main(string[] args)
        {
            // Value for game Grid Size
            int SIZE = 0;

            // Get input from user
            Console.WriteLine("Enter the square size: ");
            if (int.TryParse(Console.ReadLine(), out int input))
            { SIZE = input; }
            else
            { Console.WriteLine("Enter the square size: "); }

            // Create the Grid
            MinesweeperGame MyGame = new MinesweeperGame(SIZE, SIZE);

            // Run Game Methods
            MyGame.BuildBoard(SIZE, SIZE);
            MyGame.ActivateBombs(SIZE, SIZE);
            MyGame.LocateNeighbors(SIZE, SIZE);
            MyGame.PlayGame();
            
            Console.ReadLine();
        }
    }
}
