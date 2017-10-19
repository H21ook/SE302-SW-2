using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            DrawDisplay d = new DrawDisplay();
            Road.road = new String[29, 18];
            Car car = new Car(7, 25);
            d.DrawRoad(car);
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (car.X < 13)
                        {
                            car.Move(1, 0);
                        }
                        else
                            break;
                        break;

                    case ConsoleKey.LeftArrow:
                        if (car.X > 1)
                        {
                            car.Move(-1, 0);
                        }
                        else
                            break;
                        break;
                }
            }
        }
    }

    public class Car
    {
        public int X { get; set; } //Left
        public int Y { get; set; } //Top
        public int carlength = 3;
        public int carwidth = 4;
        public string[,] carmodel = new string[,]
        {
            {"0"," "," ","0"},
            {" ","(",")"," "},
            {"0"," "," ","0"},
        };
        public Car(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public void Move(int x, int y)
        {
            int k;
            if (x == -1)
            {
                for (int i = Y; i <= Y + 2; i++)
                {
                    k = 0;
                    for (int j = X; j <= X + 3; j++)
                    {
                        Road.road[i, X + x + k] = Road.road[i, j];
                        if (j == X + 3)
                            Road.road[i, j] = " ";
                        k++;
                    }
                }
                X += x;
            }
            else
            {
                for (int i = Y; i <= Y + 2; i++)
                {
                    k = 3;
                    for (int j = X + 3; j >= X; j--)
                    {
                        Road.road[i, X + x + k] = Road.road[i, j];
                        if (j == X)
                            Road.road[i, j] = " ";
                        k--;
                    }
                }
                X += x;
            }

        }
    }

    public class Road
    {
        public static String[,] road;
    }

    public class Problem
    {
    }

    public class Level
    {
    }

    public class DrawDisplay
    {
        public void DrawRoad(Car car)
        {
            DrawCar(car);
            for (int i = 0; i < Road.road.GetLength(0); i++)
            {
                for (int j = 0; j < Road.road.GetLength(1); j++)
                {
                    if (i == 0 || i == Road.road.GetLength(0) - 1 || j == 0 || j == Road.road.GetLength(1) - 1)
                    {
                        Road.road[i, j] = "8";
                        Console.Write(Road.road[i, j]);
                    }
                    else if (Road.road[i, j] != null)
                    {
                        Console.Write(Road.road[i, j]);
                    }
                    else
                    {
                        Road.road[i, j] = " ";
                        Console.Write(Road.road[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
        public void DrawCar(Car car)
        {
            for (int i = 0; i < car.carmodel.GetLength(0); i++)
            {
                for (int j = 0; j < car.carmodel.GetLength(1); j++)
                {
                    Road.road[car.Y + i,car.X + j]=car.carmodel[i, j];
                }
            }
        }

        public void RefreshRoad(String[,] road)
        {
            Console.Clear();
            for (int i = 0; i < road.GetLength(0); i++)
            {
                for (int j = 0; j < road.GetLength(1); j++)
                {
                    System.Threading.Thread.Sleep(0);
                    Console.Write(road[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}