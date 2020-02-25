using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazGen_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize
            Console.SetWindowSize(102, 52);
            Maze m = new Maze();

            // generate
            m.Generate();
            m.Render();

            // finish
            Console.ReadKey();
        }
    }
}
