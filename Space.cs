using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    abstract class Space
    {
        byte X;
        protected byte x
        {
            get{ return X;}
            set
            {
                if (value > 4 && value < 111)
                    X = value;
                else
                    Console.WriteLine("Fail: X must be between 5 and 110"); ;
            }
        }
        byte Y;
        protected byte y
        {
            get{return Y;}
            set
            {
                if (value > 4 && value < 61)
                    Y = value;
                else
                    Console.WriteLine("Fail: Y must be between 5 and 60"); ;
            }
        }
        protected char[,] space;
        protected Space(byte x, byte y)
        {
            this.x = x;
            this.y = y;
            space = new char[y, x];
        }
        public virtual void SpaceBorders(ConsoleColor color)
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    //Сlear array
                    space[i, j] = ' ';
                    //Horizontal and vertical
                    space[1, j] = '\u2550';
                    space[y - 1, j] = '\u2550';
                    space[i, 1] = '\u2551';
                    space[i, x - 1] = '\u2551';
                    //Defect
                    space[0, j] = ' ';
                    space[i, 0] = ' ';
                    space[1, 0] = ' ';
                    //Angles
                    space[1, 1] = '\u2554';
                    space[1, x - 1] = '\u2557';
                    space[y - 1, x - 1] = '\u255D';
                    space[y - 1, 1] = '\u255A';
                }
            }
            Console.ForegroundColor = color;
        }
        public void SpaceOutput(int score)
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(space[i,j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("  SCORE: " + score);
            Console.SetCursorPosition(0, 0);
        }
        //For beauty
        public void SpaceOutput()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(space[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, 0);
        }
        protected int PercentOfNum(int percent, int number)
        {
            return (number * percent) / 100;
        }

    }
}
