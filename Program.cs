using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            GameSnake game = new GameSnake(50, 25);
            //Menu snake = new Menu(13, 10);
            Console.ReadKey();
        }
    }
}
