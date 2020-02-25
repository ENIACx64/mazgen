using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazGen_Array
{
    class Maze
    {
        /// <summary>
        /// Array that keeps the maze grid
        /// </summary>
        public Block[,] Grid = new Block[51, 51];

        /// <summary>
        /// Enum that marks the direction
        /// </summary>
        public enum Direction { Up, Down, Left, Right }

        /// <summary>
        /// An instance of random generator
        /// </summary>
        Random random = new Random();

        /// <summary>
        /// Fills the maze grid with empty blocks
        /// </summary>
        public void GridFill()
        {
            for (int i = 0; i < 51; i++)
            {
                for (int j = 0; j < 51; j++)
                {
                    Grid[i, j] = new BlockEmpty(i, j);
                }
            }
        }

        /// <summary>
        /// Generates walls all around the maze
        /// </summary>
        public void GenerateWalls()
        {
            for (int i = 0; i < 51; i++)
            {
                Grid[i, 0] = new BlockWall(i, 0);           // top wall
                Grid[i, 50] = new BlockWall(i, 50);         // bottom wall
                Grid[0, i] = new BlockWall(0, i);           // left wall
                Grid[50, i] = new BlockWall(50, i);         // right wall
            }
        }

        /// <summary>
        /// Generates foundations from which the walls will grow
        /// </summary>
        public void GenerateFoundations()
        {
            for (int i = 0; i < 51; i++)
            {
                for (int j = 0; j < 51; j++)
                {
                    if (Grid[i, j] is BlockEmpty)
                    {
                        if ((Grid[i, j].X % 2 == 0) && (Grid[i, j].Y % 2 == 0))
                        {
                            Grid[i, j] = new BlockFoundation(i, j);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Counts foundations in the grid and returns their count as int
        /// </summary>
        /// <returns></returns>
        public int FFunc()
        {
            int counter = 0;
            foreach (Block b in Grid)
            {
                if (b is BlockFoundation)
                    counter++;
            }
            return counter;
        }

        public void BuildWalls()
        {
            while (FFunc() > 0)
            {
                bool canGoOn = false;
                int PosX = 0;
                int PosY = 0;
                while (!canGoOn)
                {
                    int rank = random.Next(0, FFunc() + 1);
                    int counter = 0;
                    foreach (Block b in Grid)
                    {
                        if (b is BlockFoundation)
                        {
                            counter++;
                            if (counter == rank)
                            {
                                PosX = b.X;
                                PosY = b.Y;
                                canGoOn = true;
                            }
                        }
                    }
                }

                Grid[PosX, PosY] = new BlockWall(PosX, PosY);
                Direction movDir;
                int dir = random.Next(0, 4);
                if (dir == 0)
                    movDir = Direction.Right;
                else if (dir == 1)
                    movDir = Direction.Up;
                else if (dir == 2)
                    movDir = Direction.Left;
                else
                    movDir = Direction.Down;

                bool nextWall = false;
                switch (movDir)
                {
                    case Direction.Right:
                        while (!nextWall)
                        {
                            if ((Grid[PosX + 1, PosY] is BlockEmpty) || (Grid[PosX + 1, PosY] is BlockFoundation))
                            {
                                Grid[PosX + 1, PosY] = new BlockWall(PosX + 1, PosY);
                                PosX++;
                            }
                            else
                                nextWall = true;
                        }
                        break;
                    case Direction.Up:
                        while (!nextWall)
                        {
                            if ((Grid[PosX, PosY + 1] is BlockEmpty) || (Grid[PosX, PosY + 1] is BlockFoundation))
                            {
                                Grid[PosX, PosY + 1] = new BlockWall(PosX, PosY + 1);
                                PosY++;
                            }
                            else
                                nextWall = true;
                        }
                        break;
                    case Direction.Left:
                        while (!nextWall)
                        {
                            if ((Grid[PosX - 1, PosY] is BlockEmpty) || (Grid[PosX - 1, PosY] is BlockFoundation))
                            {
                                Grid[PosX - 1, PosY] = new BlockWall(PosX - 1, PosY);
                                PosX--;
                            }
                            else
                                nextWall = true;
                        }
                        break;
                    case Direction.Down:
                        while (!nextWall)
                        {
                            if ((Grid[PosX, PosY - 1] is BlockEmpty) || (Grid[PosX, PosY - 1] is BlockFoundation))
                            {
                                Grid[PosX, PosY - 1] = new BlockWall(PosX, PosY - 1);
                                PosY--;
                            }
                            else
                                nextWall = true;
                        }
                        break;
                }
            }
        }

        public void Render()
        {
            foreach (Block b in Grid)
            {
                b.Render();
            }
        }

        public void Generate()
        {
            GridFill();
            GenerateWalls();
            GenerateFoundations();
            BuildWalls();
        }
    }
}
