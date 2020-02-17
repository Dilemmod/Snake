using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake: Space, ISpace
    {
        public Snake()
        {
            SpaceFilling();
            
        }
        public void SpaceFilling()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    space[i, j] = ' ';
                    space[1, j] = '\u2550';
                    space[y-1, j] = '\u2550';
                    space[i, 1] = '\u2551';
                    space[i, x-1] = '\u2551';
                    space[0, j] = ' ';
                    space[i, 0] = ' ';
                    space[1, 0] = ' ';
                    space[1, 1] = '\u2554';
                    space[1, x-1] = '\u2557';
                    space[y-1, x-1] = '\u255D';
                    space[y-1, 1] = '\u255A';
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            SpaceOutput();
        }
        public void Action()
        {
            Console.WriteLine("\u2554 \u2550 \u2557 ");
            Console.WriteLine("\u2551   \u2551");
            Console.WriteLine("\u255A \u2550 \u255D");
        }
    }
}
