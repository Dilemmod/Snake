using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Shapes;

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
            SpaceOutput(0);
            Action();
        }
        private void Action()
        {
            Navigate n = Navigate.Default;
            ConsoleKeyInfo userInput;
            List<Snake> snake = new List<Snake>
            {
                new Snake(){x=20,y=20},
                new Snake(){x=20,y=21},
                new Snake(){x=20,y=22}
            };
            //Rectangle rec = new Rectangle();
            //int plX = (x / 2), plY = (PercentOfNum(90, y));
            int delayTime = 300;
            bool snakeСrashed = false;
            int score = 0;
            while (snake[0].y > 1 && snake[0].y < y-1 && snake[0].x > 1 && snake[0].x < x-1 && snakeСrashed == false)
            {
                Snake mainSegment;
                Snake secondSegment;
                score++;
                if (Console.KeyAvailable == true)
                {
                    userInput = Console.ReadKey(true);
                    switch (userInput.Key)
                    {
                        case ConsoleKey.W:
                            n = Navigate.Up;
                            break;
                        case ConsoleKey.S:
                            n = Navigate.Down;
                            break;
                        case ConsoleKey.A:
                            n = Navigate.Left;
                            break;
                        case ConsoleKey.D:
                            n = Navigate.Right;
                            break;
                        default:
                            break;
                    }
                }

                mainSegment = snake[0];

                snake[0].y = (n == Navigate.Default ? --snake[0].y : snake[0].y);
                //Pressed Up or Down 
                snake[0].y = (n == Navigate.Up ? --snake[0].y : (n == Navigate.Down ? ++snake[0].y : snake[0].y));
                //Pressed Right or Left 
                snake[0].x = (n == Navigate.Left ? --snake[0].x : (n == Navigate.Right ? ++snake[0].x : snake[0].x));
                for (int i = 1; i < snake.Count; i++)
                {
                        secondSegment = snake[i];
                        snake[i] = mainSegment;
                        mainSegment = secondSegment;
                }


                //Присваеваем значение остальным сегментам
                //Присвоить значение колекцыи Snake
                for (int i = 0; i < snake.Count; i++)
                {
                    space[snake[i].y, snake[i].x] = '@';
                }

                //No keys pressed yet
                //plY = (n == Navigate.Default ? --plY : plY);
                //Pressed Up or Down 
                //plY = (n == Navigate.Up ? --plY : (n == Navigate.Down ? ++plY:plY));
                //Pressed Right or Left 
                //plX = (n == Navigate.Left ? --plX : (n == Navigate.Right ? ++plX : plX));
                //space[plY, plX] = '@';
                //snakeTailX=plY
                SpaceOutput(score);
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
