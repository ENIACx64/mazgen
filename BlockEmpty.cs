using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazGen_Array
{
    class BlockEmpty : Block
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public BlockEmpty(int x, int y) : base(x, y)
        {
            X = x;
            Y = y;
            FGColor = ConsoleColor.Black;
        }
    }
}
