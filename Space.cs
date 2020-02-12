using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    abstract class Space
    {
        protected int x, y;
       
        protected char[,] space = new char[25, 50];
        protected abstract void SpaceFilling();
        protected abstract void Action();
        public virtual void SpaceСreating()
        {
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    Console.Write(space[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
