using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        public int x { get; set; }
        public int y { get; set; }
    }
    class GameSnake:Space
    {
        bool foodExist = false;
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
        enum Navigate
        {
            Default,
            Up,
            Down,
            Right,
            Left
        }
        private void GenerateFood()
        {
            int foodX, foodY;
            do
            {
                foodX = rand.Next(1, x - 1); 
                foodY = rand.Next(1, y - 1);
            }
            while (space[foodY, foodX] != ' ');
            space[foodY, foodX] = '#';
            foodExist = true;
        }
        private void Action()
        {
            Navigate n = Navigate.Default;
            ConsoleKeyInfo userInput;
            List<Snake> snake = new List<Snake>
            {
                new Snake(){x=(x / 2),y=(PercentOfNum(80, y))},
                new Snake(){x=(x / 2),y=(PercentOfNum(80, y))+1},
                new Snake(){x=(x / 2),y=(PercentOfNum(80, y))+2},
                new Snake(){x=(x / 2),y=(PercentOfNum(80, y))+3}
            };
            int delayTime = 200,score = 0,mainSegmentX, mainSegmentY, secondSegmentX, secondSegmentY;
            while (snake[0].y > 1 && snake[0].y < y-1 && snake[0].x > 1 && snake[0].x < x-1)
            {
                mainSegmentX = snake[0].x; 
                mainSegmentY = snake[0].y;
                if (Console.KeyAvailable == true)
                {
                    userInput = Console.ReadKey(true);
                    switch (userInput.Key)
                    {
                        case ConsoleKey.W:
                            n = (n == Navigate.Down ? Navigate.Down : Navigate.Up);
                            break;
                        case ConsoleKey.S:
                            n = (n == Navigate.Up|| n == Navigate.Default ? Navigate.Up : Navigate.Down);
                            break;
                        case ConsoleKey.A:
                            n = (n == Navigate.Right ? Navigate.Right : Navigate.Left);
                            break;
                        case ConsoleKey.D:
                            n = (n == Navigate.Left ? Navigate.Left : Navigate.Right);
                            break;
                        default:
                            break;
                    }
                }
                //No keys pressed yet
                snake[0].y = (n == Navigate.Default ? --snake[0].y : snake[0].y);
                //Pressed Up or Down 
                snake[0].y = (n == Navigate.Up ? --snake[0].y : (n == Navigate.Down ? ++snake[0].y : snake[0].y));
                //Pressed Right or Left 
                snake[0].x = (n == Navigate.Left ? --snake[0].x : (n == Navigate.Right ? ++snake[0].x : snake[0].x));

                //Assign value to other segments
                for (int i = 1; i < snake.Count; i++)
                {
                    secondSegmentX = snake[i].x; secondSegmentY = snake[i].y;
                    snake[i].x = mainSegmentX; snake[i].y = mainSegmentY;
                    mainSegmentX = secondSegmentX; mainSegmentY= secondSegmentY;
                }

                //Did the snake eat self?
                if (space[snake[0].y, snake[0].x] == '@')
                    break;
                //Food absorption
                else if (space[snake[0].y, snake[0].x] == '#')
                {
                    snake.Add(new Snake() { x = snake[snake.Count - 1].x, y = snake[snake.Count - 1].y });
                    foodExist = false;
                    score++;
                    delayTime -=(delayTime>20?20:0);
                }
                //Assign Snake Collection Value
                for (int i = 0; i < snake.Count; i++)
                    space[snake[i].y, snake[i].x] = (i == snake.Count - 1 ? ' ': '@');
                if(foodExist == false)
                    GenerateFood();
                SpaceOutput(score);
                Thread.Sleep(delayTime);
            }
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    space[i, j] = '_';
                    Console.Write(space[i, j]);
                    Thread.Sleep(2);
                }
                Console.WriteLine();
            }
            Console.Clear();
            Console.WriteLine("\t\t  GAME OVER");
            Console.WriteLine("\t\tYOUR SCORE = "+score);
            Console.WriteLine("\n\t\t  RESTART? \nPRESS ENTER");
            userInput = Console.ReadKey(true);
            switch (userInput.Key)
            {
                case ConsoleKey.Enter:
                    GameSnake game = new GameSnake(x, y);
                    break;
                default:
                    Menu snakee = new Menu(13, 10);
                    break;
            }
            Console.ReadKey();
        }
    }
}
