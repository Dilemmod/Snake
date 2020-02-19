using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Menu: Space
    {
        public Menu(byte x, byte y) : base(x, y)
        {
            Console.Clear();
            SpaceFilling(3,false);
            Action();
        }
        public void SpaceFilling(int choice, bool gameON)
        {
            //Сreating menu borders
            SpaceBorders(ConsoleColor.DarkYellow);
            int s = 3;
            space[s, 5] = 'P';
            space[s, 6] = 'L';
            space[s, 7] = 'A';
            space[s, 8] = 'Y';


            int ed = 5;
            space[ed, 5] = 'E';
            space[ed, 6] = 'D';
            space[ed, 7] = 'I';
            space[ed, 8] = 'T';
            //if (gameON)
            //{
            //    space[l, 5] = 'S';
            //    space[l, 6] = 'A';
            //    space[l, 7] = 'V';
            //    space[l, 8] = 'E';
            //}
            //else
            //{
            //    space[l, 5] = 'L';
            //    space[l, 6] = 'O';
            //    space[l, 7] = 'A';
            //    space[l, 8] = 'D';
            //}

            int e = 7;
            space[e, 5] = 'E'; 
            space[e, 6] = 'X';
            space[e, 7] = 'I';
            space[e, 8] = 'T';

            space[choice - 1, 5] = '_'; space[choice, 4] = '<';
            space[choice - 1, 6] = '_';
            space[choice - 1, 7] = '_';
            space[choice - 1, 8] = '_'; space[choice, 9] = '>';
            SpaceOutput("");
        }
        public void Action()
        {
            ConsoleKeyInfo navigation;
            int choice = 3;
            while (true)
            {
                navigation = Console.ReadKey(true);
                Console.SetCursorPosition(0, 0);
                switch (navigation.Key)
                {
                    case ConsoleKey.Enter:
                        if (choice == 3)
                        {
                            GameSnake play = new GameSnake(50,25);
                            goto End;
                        }
                        else if(choice == 5)
                        {
                            SpaceOutput("Enter the size of the field, this way: \n\twidth, height");
                            string userS = Console.ReadLine();
                            string[] param  = userS.Split(new char[] { ',' });
                            try
                            {
                                GameSnake play = new GameSnake(Convert.ToByte(param[0]), Convert.ToByte(param[1]));
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("Parameters entered incorrectly");
                                Console.ReadLine();
                                Menu snake = new Menu(13, 10);
                            }
                        }
                        else if(choice == 7)
                        {
                            Process.GetCurrentProcess().Kill();
                        }
                        break;
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        choice = (choice == 3 ? 7 : (choice == 5 ? 3 : (choice == 7 ? 5:3))) ;
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        choice = (choice == 3 ? 5 : (choice == 5 ? 7 : (choice == 7 ? 3 : 3)));
                        break;
                    case ConsoleKey.E:
                        Process.GetCurrentProcess().Kill();
                        break;
                    case ConsoleKey.P:
                        GameSnake play2 = new GameSnake(50, 25);
                        break;
                }
                SpaceFilling(choice,false);
            }
            End:;
        }
    }
}
