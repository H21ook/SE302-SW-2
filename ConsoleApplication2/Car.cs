using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Car
    {
        public int X { get; set; } // x coordinat
        public int Y { get; set; } // y coordinat
        public static int LENGTH = 3; // mashinii urt
        public static int WIDTH = 4;// mashinii orgon

        public string[,] carbody = new string[,]
        {
            {"0"," "," ","0"},
            {" ","(",")"," "},
            {"0"," "," ","0"}
        };
        public string[,] carDestroyBody = new string[,]
        {
            {"X"," "," ","X"},
            {" ","X","X"," "},
            {"X"," "," ","X"}
        };
        public Car(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public void Move(int x, int y)
        {
            X += x;
            DrawDisplay d = new DrawDisplay();
            d.DrawCar(this);

            for (int i = 0; i < LENGTH; i++)
            {
                if (x == -1)
                    Console.SetCursorPosition(X + WIDTH, Y + i);
                else
                    Console.SetCursorPosition(X - 1, Y + i);
                Console.Write(" ");
            }
        }
    }
}
