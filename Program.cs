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
            
            Snake snake = new Snake();
            Console.ReadKey();
        }
        /*
        class Menu : Array
        {
            protected int exit, length;
            public Menu()
            {
                getFilledArray();
                game();
            }
            protected override void getFilledArray()
            {
               
                for (int i = 0; i < space.Length; i++)
                {
                    space[i] = new char[25];
                }
                for (int i = 0; i < space.Length; i++)
                {
                    for (int j = 0; j < space[i].Length; j++)
                    {
                        space[i][j] = ' ';
                        space[i][0] = 'I';
                        space[i][space.Length - 1] = 'I';
                        space[space.Length - 1][j] = 'X';
                        space[0][j] = 'X';
                        x = space.Length / 2;
                        y = space.Length / 2;
                        space[x][y] = '@';

                        length = space.Length;
                    }
                }
            }
            protected override void game()
            {
                ConsoleKeyInfo navigation;
                while (x != -1)
                {
                    if (x == exit && (y < length / 2 + 3 && y > length / 2 - 4))
                    {
                        break;
                    }
                    getArrey();
                    navigation = Console.ReadKey(true);
                    Console.SetCursorPosition(0, 0);
                    char temp = space[x][y];
                    space[x][y] = '-';
                    switch (navigation.Key)
                    {
                        case ConsoleKey.E:
                            x = exit;
                            y = length / 2 + 2;
                            break;
                        case ConsoleKey.D:
                            y = (y == space.Length - 1 ? 0 : y + 1);
                            break;
                        case ConsoleKey.A:
                            y = (y == 0 ? space.Length - 1 : y - 1);
                            break;
                        case ConsoleKey.S:
                            x = (x == space.Length - 1 ? 0 : x + 1);
                            break;
                        case ConsoleKey.W:
                            x = (x == 0 ? space.Length - 1 : x - 1);
                            break;
                    }
                    space[x][y] = temp;
                }
            }
        }
        */
        
    }
    
}
