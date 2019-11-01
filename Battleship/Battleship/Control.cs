using System;
using System.Linq;

namespace Battleship
{
    class GameControl
    {
        CustomLabel CreateLabel = new CustomLabel();

        string[] POW = new string[] {
                                           @"                  /\                  ",
                                           @"                 /  \                 ",
                                           @"    ------------      -------------   ",
                                           @"    |    |                   |    |   ",
                                           @"    |    |   | POWWWWWW  |   |    |   ",
                                           @"    |    |                   |    |   ",
                                           @"    ------------       -------------  ",
                                           @"                 \   /                ",
                                           @"                  \ /                 "
                                        };

        public void POWW()
        {
            foreach (string pow in POW)
                Console.WriteLine(pow);
        }

        // checks if there is a ship within the desired position or not 
        // by signaling whether it was destroyed
        public bool Fire(Ship ship, int row, int column)
        {
            return ship.ShipContains(row, column);
        }

        // displays the board 
        public void DisplayBoard(Board board, int dimensions)
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine(CreateLabel.LabelGridY('A', 'J', "  "));
            Console.Write(Environment.NewLine);
            for (int row = 0; row < dimensions; row++)
            {
                Console.Write(Environment.NewLine);
                Console.Write(row + "  " );
                for (int column = 0; column < dimensions; column++)
                {
                    if (board.Equals(row, column, 0))
                    {
                        Console.Write(" ~ ");
                    }
                    else if (board.Equals(row, column, 1))
                    {
                        Console.Write(" o ");
                    }
                    else if (board.Equals(row, column, 2))
                    {
                        Console.Write(" x ");
                    }
                }
                Console.Write("  "+ row);
                Console.Write(Environment.NewLine);
            }
            Console.Write(Environment.NewLine);
            Console.WriteLine(CreateLabel.LabelGridY('A', 'J', "  "));
            Console.Write(Environment.NewLine);
        }

        // changes the grid when changes have been made to the objects within the grid
        public bool ChangeGrid(Board board, Ship ship, int row, int column)
        {
            if (Fire(ship, row, column))
            {
                board.SetGridVal(row, column, 2);
                return true;
            }
            else {
                board.SetGridVal(row, column, 1);
                return false;
            }
        }

        // detects if a move has been made and checks if the move is allowed
        public bool Detect(Board board, string move)
        {
            if (move.Length == 2 && ("0123456789".Contains(move[1].ToString())))
            {
                
                if (!board.Contains(move) && isValidRow(move))
                {
                    board.Add(move);
                    return true;
                }

                else
                {
                    Console.WriteLine("Shot already taken!!");
                    return false;
                }
            }

            else
            {
                Console.WriteLine("Unknown column number, please insert valid column number from 0-10!!");
                return false;
            }
        }

        // Grid control makes sure the move is correct and allowed within the bounds of the labels
        public void GridControl(int row, int column, int GridDimensions, Board board, Ship ships, int targetHit, int attempt)
        {
            if (ChangeGrid(board, ships, row, column))
            {
                // display POW image
                POWW();

                Console.WriteLine("Battleship shot!!");
                Console.Write(Environment.NewLine);
                //ChangeGrid(board, ships, row, column);
                targetHit = targetHit + 1;
                DisplayBoard(board, GridDimensions);
            }

            else {
                
                Console.WriteLine("Shot missed!!");
                //ChangeGrid(board, ships, row, column);
                DisplayBoard(board, GridDimensions);

                // display POW image
                POWW();
            }
        }

        // checks moves made against the grid (game board) for possible enemy ships
        // Converts the respective character of a move such as [A1] to a number as the
        // grid only takes numbers as input
        public bool isValidRow(string s)
        {
            string YaxisLabelUp = "ABCDEFGHIJ";
            string YaxisLabelLow = "abcdefghij";

            int temp = YaxisLabelUp.Contains(s[0]) ? Array.IndexOf(YaxisLabelUp.ToArray(), s[0]) : 
                       YaxisLabelLow.Contains(s[0]) ? Array.IndexOf(YaxisLabelLow.ToArray(), s[0]) : -1;
            
            if (temp < 0)
            {
                Console.WriteLine("Unknown row type, please insert valid row from A-J");
                return false;
            }

            else return true;
        }

        // get respective column and row
        public int GetRow(string move)
        {
            return Convert.ToInt32(move[1].ToString());
        }

        public int GetColumn(string move)
        {
            string YaxisLabelUp = "ABCDEFGHIJ";
            string YaxisLabelLow = "abcdefghij";

            int row = YaxisLabelUp.Contains(move[0]) ? Array.IndexOf(YaxisLabelUp.ToArray(), move[0]) :
                      YaxisLabelLow.Contains(move[0]) ? Array.IndexOf(YaxisLabelLow.ToArray(), move[0]) : 0;

            return row;
        }
    }
}
