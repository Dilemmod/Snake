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
            Menu snake = new Menu(13, 10);
            Console.ReadKey();
        }
    }
}
