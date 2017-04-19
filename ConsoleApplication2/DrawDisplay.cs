using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class DrawDisplay
    {
        public void DrawRoad(int roadlenght, int roadwidth)
        {
            Road.roadarr = new string[roadlenght, roadwidth];

            for (int i = 0; i < Road.roadarr.GetLength(0); i++)
            {
                for (int j = 0; j < Road.roadarr.GetLength(1); j++)
                {
                    if (j == 0 || j == Road.roadarr.GetLength(1) - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Road.roadarr[i, j] = "█";
                    }
                    else
                    {
                        Road.roadarr[i, j] = " ";
                    }
                    Console.SetCursorPosition(j, i);
                    Console.Write(Road.roadarr[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void DrawCar(Car car)
        {
            for (int i = 0; i < Car.LENGTH; i++)
            {
                for (int j = 0; j < Car.WIDTH; j++)
                {
                    Console.SetCursorPosition(car.X, car.Y);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(car.carbody[i, j]);
                    car.X++;
                }
                car.Y++;
                car.X -= Car.WIDTH;
            }
            car.Y -= Car.LENGTH;
        }
        public void DestroyDrawCar(Car car)
        {
            for (int i = 0; i < Car.LENGTH; i++)
            {
                for (int j = 0; j < Car.WIDTH; j++)
                {
                    Console.SetCursorPosition(car.X, car.Y);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(car.carDestroyBody[i, j]);
                    car.X++;
                }
                car.Y++;
                car.X -= Car.WIDTH;
            }
            car.Y -= Car.LENGTH;
        }
        public void DrawProblem(Problem p)
        {
                for (int j = 0; j < p.problem.Length; j++)
                {
                    Console.ForegroundColor = p.color;
                    Console.SetCursorPosition(p.coordinatX + j, p.coordinatY);
                    Console.Write(p.problem[j]);
                }
        }
        public void DrawInformation(int x,int y,string str,ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(str);
        }
        public void ClearConsole(int sH, int sW)
        {
            int x = 1;
            int y = 0;
            for (int i = 0; i < sH+1; i++)
            {
                for (int j = 0; j < sW-2; j++)
                {
                    Console.SetCursorPosition(x+j, y+i);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
            }
        }
    }
}
