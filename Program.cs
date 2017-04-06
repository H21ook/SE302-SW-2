using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            DrawDisplay d = new DrawDisplay();
            d.DrawRoad();
            Car car = new Car(7,25);
            d.DrawCar(car);

            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (car.X < (Road.roadarr.GetLength(1) - 1) - car.WIDTH)
                        {
                            car.Move(1, 0);
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (car.X > Road.roadarr.GetLength(1) - (Road.roadarr.GetLength(1) - 1))
                        {
                            car.Move(-1, 0);
                        }
                        break;
                }
            }
        }
    }
}
