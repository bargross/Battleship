using System;

namespace Battleship
{
    class Initializer
    {
        // populates the grid with initial 0 (but is pointless as is an int 2D array, by default all values are set to 0)
        public void PopulateGrid(Board board)
        {
            for (int row = 0; row < board.Grid.Length; row++)
            {
                for (int column = 0; column < board.Grid.GetLength(row); column++)
                {
                    board.Grid[row, column] = 0;
                }
            }
        }

        // populates battleships 
        public void Populate(Ship battleships, int GridDimensions)
        {
            Random ships = new Random();

            for (int i = 0; i < battleships.SAmount; i++)
            {
                battleships.TShip[i, 0] = ships.Next(0, GridDimensions - 1);
                battleships.TShip[i, 1] = ships.Next(0, GridDimensions - 1);
                for (int j = 0; j < i; j++)
                {
                    if (battleships.TShip[i, 0] == battleships.TShip[j, 0] && battleships.TShip[i, 1] == battleships.TShip[j, 1])
                    {
                        battleships.TShip[i, 0] = ships.Next(0, GridDimensions - 1);
                        battleships.TShip[i, 1] = ships.Next(0, GridDimensions - 1);
                        continue;
                    }
                    else break;
                }
            }
        }

        // sets the dimensions of the grid
        public void CreateGrid(Board board, int GridSize)
        {
            if (GridSize == 0)
                throw new ArgumentNullException("The Game Grid cannot be empty!");

            else board.New(GridSize, GridSize);
        }

        // initializes the board
        public void Begin(Ship ship, int GridDimensions, Action move)
        {
            Populate(ship, GridDimensions);
            move();
        }
    }
}
