using System;

namespace Battleship
{
    class CustomLabel
    {
        /*****************************
         *   X axis label method     *
         *      Unnecessary          *
         *****************************/

        // creates the label for the X axis of the grid
        public string LabelGridX(int from, int to, string spacing)
        {
            string label = "";

            for (int i = from; i < to; i++)
            {
                label += (spacing + i);
            }

            if (label.Equals(null) || label == "")
                throw new ArgumentException("label is empty, check the referenced objects!");

            label = spacing + label;

            return label;
        }

        /*****************************
         *****************************
         ******* UsefullStuff :) *****
         *****************************
         *****************************/

        // creates the label for the Y axis of the grid
        public string LabelGridY(char from, char to, string spacing)
        {
            string label = "";

            for (char i = from; i <= to; i++)
            {
               label += (spacing + i);
            }

            if (label.Equals(null) || label == "")
                throw new ArgumentException("label is empty, check the referenced object!");

            label = spacing + label;

            return label;
        }

        // creates both labels and returns a tuple with two strings representing <X,Y> 
        public Tuple<string, string> CreateLabels(int fromX, int toY, char from, char to, string spacing)
        {
            return Tuple.Create(LabelGridX(fromX, toY, spacing), LabelGridY(from, to, spacing));
        }
    }
}
