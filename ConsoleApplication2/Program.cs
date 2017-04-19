using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Program
    {
        private static int screenWidth = 18;
        private static int screenHeight = 30;
        private static int livesCount = 3;
        private static int score = 0;
        private static int timerSpeed = 300;
        private static int speed = 0;
        private static List<Problem> problems = new List<Problem>();
        public static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = 31;
            Console.BufferWidth = Console.WindowWidth = 50;
            Console.CursorVisible = false;

            DrawDisplay d = new DrawDisplay();
            d.DrawRoad(screenHeight, screenWidth);

            Car car = new Car((screenWidth/2) - Car.WIDTH/2 ,screenHeight- Car.LENGTH);
            d.DrawCar(car);

            MoveGame(car);
        }
        public static void MoveGame(Car car)
        {
            DrawDisplay d = new DrawDisplay();
            Random rand = new Random();
            int newXCoordinat = 0;
            int q = 0;
            while (true)
            {
                int lvladd = 2000;
                int lvl = 1;
                if (score == lvladd && lvl< 4)
                {
                    lvl += 1;
                    timerSpeed -= 100;
                    lvladd += 2000;
                }
                score += 10;
                speed += 20;
                if (speed > 400)
                {
                    speed = 400;
                }
                bool suirel = false;
                {
                    if (q % 4 == 0)
                    {
                        newXCoordinat = rand.Next(1, screenWidth - 4);
                        Level l = new Level();
                        Problem proObj;
                        switch(lvl)
                        {
                            case 1:
                                proObj = l.levelOne(newXCoordinat);
                                problems.Add(proObj);
                                break;
                            case 2:
                                proObj = l.levelTwo(newXCoordinat);
                                problems.Add(proObj);
                                break;
                            case 3:
                                proObj = l.levelThree(newXCoordinat);
                                problems.Add(proObj);
                                break;
                            default:
                                break;
                        }
                    }
                }
                q++;
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    switch (pressedKey.Key)
                    {
                        case ConsoleKey.RightArrow:
                            if (car.X < (screenWidth - 1) - Car.WIDTH)
                            {
                                car.Move(1, 0);
                            }
                            break;

                        case ConsoleKey.LeftArrow:
                            if (car.X > screenWidth - (screenWidth - 1))
                            {
                                car.Move(-1, 0);
                            }
                            break;
                    }
                }
                List<Problem> newList = new List<Problem>();
                for (int i = 0; i < problems.Count; i++)
                {
                    Problem oldProblem = problems[i];
                    Problem newproObj = new Problem(oldProblem.coordinatX, oldProblem.coordinatY + 1, oldProblem.color, oldProblem.problem);
                    for (int j = 0; j < newproObj.problem.Length; j++)
                    {
                        if ((newproObj.coordinatY == car.Y || newproObj.coordinatY == car.Y + 1 || newproObj.coordinatY == car.Y + 2) && (newproObj.coordinatX == car.X || newproObj.coordinatX == car.X + 1 || newproObj.coordinatX == car.X + 2 || newproObj.coordinatX == car.X + 3 || newproObj.coordinatX + 1 == car.X || newproObj.coordinatX + 1 == car.X + 1 || newproObj.coordinatX + 1 == car.X + 2 || newproObj.coordinatX + 1 == car.X + 3 || newproObj.coordinatX + 2 == car.X || newproObj.coordinatX + 2 == car.X + 1 || newproObj.coordinatX + 2 == car.X + 2 || newproObj.coordinatX + 2 == car.X + 3 || newproObj.coordinatX + 3 == car.X || newproObj.coordinatX + 3 == car.X + 1 || newproObj.coordinatX + 3 == car.X + 2 || newproObj.coordinatX + 3 == car.X + 3))
                        {
                            suirel = true;
                            speed = 0;
                            if (livesCount <= 0)
                            {
                                
                                d.DrawInformation(screenWidth+7, screenHeight/2, "GAME OVER", ConsoleColor.Red);
                                d.DrawInformation(screenWidth+5, (screenHeight/2)+1, "Press [enter] to exit", ConsoleColor.Red);
                                d.DestroyDrawCar(car);
                                Console.ReadLine();
                                Environment.Exit(0);
                            }
                        }
                    }
                    if (newproObj.coordinatY < Console.WindowHeight)
                    {
                        newList.Add(newproObj);
                    }
                }
                problems = newList;
                d.ClearConsole(screenHeight,screenWidth);
                if (suirel)
                {
                    livesCount--;
                    problems.Clear();
                    d.DestroyDrawCar(car);
                }
                else
                {
                    d.DrawCar(car);
                }
                foreach (Problem pro in problems)
                {
                    d.DrawProblem(pro);
                }
                d.DrawInformation(screenWidth + 5, screenHeight / 3, "Lives: " + livesCount, ConsoleColor.White);
                d.DrawInformation(screenWidth + 5, screenHeight / 3 + 1, "Speed: " + speed, ConsoleColor.White);
                d.DrawInformation(screenWidth + 5, screenHeight / 3 + 2, "Score: " + score, ConsoleColor.White);
                System.Threading.Thread.Sleep(timerSpeed);
            }
        }
    }
}
