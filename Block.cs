using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazGen_Array
{
    class Block
    {

        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor FGColor { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Block(int x, int y)
        {
            X = x;
            Y = y;
            FGColor = ConsoleColor.DarkYellow;
        }

        /// <summary>
        /// A method which renders the block
        /// </summary>
        public void Render()
        {
            Console.CursorLeft = X * 2;
            Console.CursorTop = Y;
            Console.ForegroundColor = FGColor;
            Console.Write("██");
        }
    }
}
