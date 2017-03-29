using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawDisplay d = new DrawDisplay();
            String[,] temp = d.DrawRoad();
            Road road = new Road(temp);
            Car car = new Car(7,25);
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (car.X < 13)
                        {
                            temp = car.Move(1, 0, temp);
                            d.RefreshRoad(temp);
                            road = new Road(temp);
                        }
                        else
                            break;
                        break;

                    case ConsoleKey.LeftArrow:
                        if (car.X > 1)
                        {
                            temp = car.Move(-1, 0, temp);
                            d.RefreshRoad(temp);
                            road = new Road(temp);
                        }
                        else
                            break;
                        break;
                }
            }
        }
    }

    class Car
    {
        public int X { get; set; } //Left
        public int Y { get; set; } //Top
        public Car(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
        public String[,] Move(int x,int y, String[,] road)
        {
            int k;
            if (x == -1)
            {
                for (int i = Y; i <= Y + 2; i++)
                {
                    k = 0;
                    for (int j = X; j <= X + 3; j++)
                    {
                        road[i, X + x + k] = road[i, j];
                        if (j == X + 3)
                            road[i, j] = " ";
                        k++;
                    }
                }
                X += x;
                return road;
            }
            else {
                for (int i = Y; i <= Y + 2; i++)
                {
                    k = 3;
                    for (int j = X + 3; j >= X; j--)
                    {
                        road[i, X + x + k] = road[i, j];
                        if (j == X)
                            road[i, j] = " ";
                        k--;
                    }
                }
                X += x;
                return road;
            }
            
        }
    }

    class Road
    {
        String[,] road;
        public Road(String[,] road)
        {
            this.road = road;
        }
    }

    class Problem
    { 
    }

    class Level
    {
    }

    class DrawDisplay
    {
        public String[,] DrawRoad()
        {
            int k = 29;
            String[,] road = new String[k, 18];
            for (int i = 0; i < road.GetLength(0); i++)
            {
               // System.Threading.Thread.Sleep(300);
                for (int j = 0; j < road.GetLength(1); j++)
                    if (i == 0 || i == road.GetLength(0) - 1 || j == 0 || j == road.GetLength(1) - 1)
                    {
                        road[i, j] = "█";
                        Console.Write(road[i,j]);
                    }
                    else if ((i == 27 || i == 25) && j == 7)
                    {
                        road[i, j] = "0";
                        Console.Write(road[i, j]);
                    }
                    else if ((i == 27 || i == 25) && j == 8)
                    {
                        road[i, j] = "o";
                        Console.Write(road[i, j]);
                    }
                    else if ((i == 27 || i == 25) && j == 9)
                    {
                        road[i, j] = "o";
                        Console.Write(road[i, j]);
                    }
                    else if ((i == 27 || i == 25) && j == 10)
                    {
                        road[i, j] = "0";
                        Console.Write(road[i, j]);
                    }
                    else if (i == 26 && j == 8)
                    {
                        road[i, j] = "(";
                        Console.Write(road[i, j]);
                    }
                    else if (i == 26 && j == 9)
                    {
                        road[i, j] = ")";
                        Console.Write(road[i, j]);
                    }
                    else
                    {
                        road[i, j] = " ";
                        Console.Write(road[i,j]);
                    }
                Console.WriteLine();
            }
            return road;
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
