using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    //if (Console.KeyAvailable == true)
class GameSnake:Space
    {
        Random rand = new Random();
        public GameSnake(byte x,byte y) : base(x,y)
        {
           
            this.x = x;
            this.y = y;
            Console.Clear();
            SpaceBorders(ConsoleColor.Green);
            SpaceFilling();
            Action();
        }
        private void SpaceFilling()
        {
            SpaceOutput(0);
        }
        private void Action()
        {
            Navigate n = Navigate.Default;
            ConsoleKeyInfo userInput;
            int plX = (x / 2), plY = (PercentOfNum(90, y));
            int delayTime = 300;//, delY = plY, delX = plX;
            int snakeTailX = plX, snakeTailY = plY, snakeTailLangth = 1, counter = 0;
            bool snakeСrashed = false;
            int score = 0;
            while (plY > 1 && plY < y-1 && plX > 1 && plX < x-1 && snakeСrashed == false)
            {
                score++;
                if (Console.KeyAvailable == true)
                {
                    userInput = Console.ReadKey(true);
                    switch (userInput.Key)
                    {
                        case ConsoleKey.W:
                            if (n == Navigate.Up)
                            {
                                delayTime = 150;
                            }
                            else
                            {
                                n = Navigate.Up;
                                delayTime = 300;
                            }
                                
                            break;
                        case ConsoleKey.S:
                            if (n == Navigate.Down)
                                delayTime = 150;
                            else
                            {
                                n = Navigate.Down;
                                delayTime = 300;
                            }
                            break;
                        case ConsoleKey.A:
                            if (n == Navigate.Left) 
                                delayTime = 150;
                            else
                            {
                                n = Navigate.Left;
                                delayTime = 300;
                            }
                            break;
                        case ConsoleKey.D:
                            if (n == Navigate.Right) 
                                delayTime = 150;
                            else
                            {
                                n = Navigate.Right;
                                delayTime = 300;
                            }
                            break;
                        default:
                            break;
                    }
                }
                //No keys pressed yet
                plY = (n == Navigate.Default ? --plY : plY);
                //Pressed Up or Down 
                plY = (n == Navigate.Up ? --plY : (n == Navigate.Down ? ++plY:plY));
                //Pressed Right or Left 
                plX = (n == Navigate.Left ? --plX : (n == Navigate.Right ? ++plX : plX));
                //No keys pressed yet
                // if (n == Navigate.Default) delY+=2;
                //Stripping
                //space[delY+1, delX] = '+';
                space[plY, plX] = '@';
                snakeTailLangth = 2;
                //snakeTailY = (n == Navigate.Default ? snakeTailY+=snakeTailLangth : snakeTailY);
                //Pressed Up or Down 
                //snakeTailY = (n == Navigate.Up ? snakeTailY -= snakeTailLangth : (n == Navigate.Down ? snakeTailY += snakeTailLangth : snakeTailY));
                //Pressed Right or Left 
                //snakeTailX = (n == Navigate.Left ? snakeTailX -= snakeTailLangth : (n == Navigate.Right ? snakeTailX += snakeTailLangth : snakeTailX));
                //snakeTailY += snakeTailLangth;
                if (snakeTailY>y-1|| snakeTailY < 1)
                {
                    snakeTailY += 0;
                }
                else
                {
                    space[snakeTailY, snakeTailX] = '+';
                }

                //snakeTailX=plY
                SpaceOutput(score);
                snakeTailY = plY;
                snakeTailX = plX;
                Thread.Sleep(delayTime);
            }
            GameSnake game = new GameSnake(50, 25);
            //Console.Clear();
            //Console.WriteLine("END");
            //Game over
        }
        enum Navigate
        {
            Default,
            Up,
            Down,
            Right,
            Left
        }
    }
}
