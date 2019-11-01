using System;

// Author: Leonardo H. Mengesha

namespace Battleship
{
	class Battleship
	{
		static void Main(String[] Args) {

            // create board (grid) and ships 2D array to save ships locations. Shots saves previous shots taken 
            Board board = new Board();
            Ship ships = new Ship();

            // DLLs for game control
            GameControl AI = new GameControl();

            // game initializer
            Initializer GameInitializer = new Initializer();

            //Console.WriteLine("Set Number of Attempts: ");

            // targets hits, and number of attempts
            int targetHit = 0, attempt = 0, attempts = 5; //int.Parse(Console.ReadLine());
            int GridDimensions = 10;
            int row = 0, column = 0;
            board.Allocate(attempts);

            Random shipAmount = new Random();
            int AmountOfships = shipAmount.Next(3, 9);

            string move = "";

            // set amount of ships to amount of attempts
            ships.SetAmount(AmountOfships, 2);
            //ships.SAmount = AmountOfships;

            // initialize the board
            GameInitializer.CreateGrid(board, GridDimensions);

            // populate grid and randomise ships
            GameInitializer.Begin(ships, GridDimensions, () => AI.DisplayBoard(board, GridDimensions));

            //string YaxisLabelUp = "ABCDEFGHIJ";
            //Console.WriteLine(YaxisLabelUp[ships.TShip[0, 0]] + " " + ships.TShip[0, 1]);
            //Console.WriteLine(ships.TShip[1, 0] + " " + ships.TShip[1, 1]);

            // game begins until maximum number of shots is achieved

            do {

                Console.WriteLine("Attempts so far: " + attempt);
                Console.WriteLine("Fire: ");
                move = Console.ReadLine();
                
                if (!AI.Detect(board, move))
                    continue;

                else
                {
                   row = AI.GetRow(move);
                   column =  AI.GetColumn(move);

                    Console.WriteLine(row + "  " + column);
                    AI.GridControl(row, column, GridDimensions, board, ships, targetHit, attempt);
                    attempt++;
                }

                Console.WriteLine("Number of attempts: " + attempt + " Targets Hit: " + targetHit);

            } while (attempt < attempts);

			Console.WriteLine("Game has ended with: "+"Attempts [" + attempt + "] " + "Battleships Shot [" + targetHit+"]");
            Console.Read();
		}
	}
}
