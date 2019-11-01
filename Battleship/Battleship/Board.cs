//using System.Linq;
using System.Collections.Generic;

namespace Battleship
{
    class Board
    {
        // private elements for Object Board Type creation
        private int[,] board;
        private HashSet<string> shots = new HashSet<string>();
        private int amount = 0, count = 0;

        // setters and getters
        public int[,] Grid { get { return board; } set { board = value; } }
        
        // Allocate length and grid size
        public void Allocate(int length = 0)
        {
            if (length == 0)
                System.Console.WriteLine("The amount of tries cannot be 0!!");

            else amount = length;
        }
        
        public void New(int dimensionX, int dimensionY)
        {
            if (board == null)
                board = new int[dimensionX, dimensionY];
        }

        // helpful methods
        public void Add(string move = "")
        {
            count++;
            if (move != "" && count < amount)
                shots.Add(move);
        }

        public bool Contains(string move)
        {
            return shots.Contains(move);
        }

        public int SLength()
        {
            return shots.Count;
        }

        public void SetGridVal(int row, int column, int value)
        {
            board[row, column] = value;
        }

        public bool Equals(int row, int column, int value)
        {
            return board[row, column] == value;
        }
    }
}
