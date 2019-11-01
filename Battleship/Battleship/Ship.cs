using System;
using System.Linq;

namespace Battleship
{
    class Ship
    {
        // ship private object
        private int[,] ship;
        private int shipAmount;

        // ship object getter and setter
        public int[,] TShip { get { return ship; } set { ship = value; } }

        // amount setter and getter
        public int SAmount {  get { return shipAmount; }  set { shipAmount = value; } }

        // implicit conversion from 2D array to ship object for easier 
        public static implicit operator Ship(int[,] thisShip)
        { 
            return new Ship { ship = thisShip };
        }

        public static explicit operator int[,](Ship ship)
        {
            return ship.TShip;
        }

        // sets ship amount 
        public void SetAmount (int ShipAmount = 0, int dimensions = 0)
        {
            if (ship == null && ShipAmount > 0)
            {
                ship = new int[ShipAmount, dimensions];
                shipAmount = ShipAmount;
            }
            else Console.WriteLine("The object already contains a specific amount");
        }

        // Checks the Ship container holding the coordinates of the ship for specific coordinates x and y
        // both have to match otherwise returns false 
        public bool ShipContains(int coordinateX, int coordinateY)
        {
            bool exists = false;
            int index = 0;
            int amount = ship.Length / ship.Rank;
            
            //Console.WriteLine("X: " + coordinateX + " Y: " + coordinateY);
            for (index=0; index < amount; index++)
                exists = (ship[index, 0] == coordinateX && ship[index, 1] == coordinateY) || false;

            return exists;
        }
    }
}
