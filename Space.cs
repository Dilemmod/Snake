using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    abstract class Space
    {
        static protected int x = 50, y = 25;
        protected char[,] space = new char[y, x];
        public virtual void SpaceOutput()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(space[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.Beep(100, 150);
            Console.Beep(300, 200);
        }

    }
}
