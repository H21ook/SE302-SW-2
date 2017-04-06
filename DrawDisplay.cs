using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class DrawDisplay
    {
        public void DrawRoad()
        {
            int roadlenght = 29;
            int roadwidth = 18;

            Road.roadarr = new string[roadlenght, roadwidth];

            for (int i = 0; i < Road.roadarr.GetLength(0); i++)
            {
                for (int j = 0; j < Road.roadarr.GetLength(1); j++)
                {
                    if (i == 0 || i == Road.roadarr.GetLength(0) - 1 || j == 0 || j == Road.roadarr.GetLength(1) - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Road.roadarr[i, j] = "█";
                    }
                    else
                    {
                        Road.roadarr[i, j] = " ";
                    }
                    Console.Write(Road.roadarr[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void DrawCar(Car car)
        {
            for (int i = 0; i < car.LENGTH; i++)
            {
                for (int j = 0; j < car.WIDTH; j++)
                {
                    Console.SetCursorPosition(car.X, car.Y);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(car.carbody[i, j]);
                    car.X++;
                }
                car.Y++;
                car.X -= car.WIDTH;
            }
            car.Y -= car.LENGTH;
        }
    }
}
