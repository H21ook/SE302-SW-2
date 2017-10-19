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
        public void Rotate(ConsoleKeyInfo pressedKey)
        {
            switch (pressedKey.Key)
            {
                case ConsoleKey.RightArrow:
                    if (X < (Program.screenWidth - 1) - Car.WIDTH)
                    {
                        Move(1, 0);
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (X > Program.screenWidth - (Program.screenWidth - 1))
                    {
                        Move(-1, 0);
                    }
                    break;
            }
        }

        public void Move(int x, int y)
        {
            X += x;
            DrawDisplay d = new DrawDisplay();
            d.DrawCar(this);
        }

        public void isDestroy(Problem newproObj)
        {
            Level l = new Level();
            if (l.levelnumber == 1 && (newproObj.coordinatY == Y || newproObj.coordinatY == Y + 1 || newproObj.coordinatY == Y + 2) && (newproObj.coordinatX == X || newproObj.coordinatX == X + 1 || newproObj.coordinatX == X + 2 || newproObj.coordinatX == X + 3 || newproObj.coordinatX + 1 == X || newproObj.coordinatX + 1 == X + 1 || newproObj.coordinatX + 1 == X + 2 || newproObj.coordinatX + 1 == X + 3 || newproObj.coordinatX + 2 == X || newproObj.coordinatX + 2 == X + 1 || newproObj.coordinatX + 2 == X + 2 || newproObj.coordinatX + 2 == X + 3)
                || l.levelnumber == 2 && (newproObj.coordinatY == Y || newproObj.coordinatY == Y + 1 || newproObj.coordinatY == Y + 2) && (newproObj.coordinatX == X || newproObj.coordinatX == X + 1 || newproObj.coordinatX == X + 2 || newproObj.coordinatX == X + 3 || newproObj.coordinatX + 1 == X || newproObj.coordinatX + 1 == X + 1 || newproObj.coordinatX + 1 == X + 2 || newproObj.coordinatX + 1 == X + 3 || newproObj.coordinatX + 2 == X || newproObj.coordinatX + 2 == X + 1 || newproObj.coordinatX + 2 == X + 2 || newproObj.coordinatX + 2 == X + 3 || newproObj.coordinatX + 3 == X || newproObj.coordinatX + 3 == X + 1 || newproObj.coordinatX + 3 == X + 2 || newproObj.coordinatX + 3 == X + 3)
                || l.levelnumber == 3 && (newproObj.coordinatY == Y || newproObj.coordinatY == Y + 1 || newproObj.coordinatY == Y + 2) && (newproObj.coordinatX == X || newproObj.coordinatX == X + 1 || newproObj.coordinatX == X + 2 || newproObj.coordinatX == X + 3 || newproObj.coordinatX + 1 == X || newproObj.coordinatX + 1 == X + 1 || newproObj.coordinatX + 1 == X + 2 || newproObj.coordinatX + 1 == X + 3 || newproObj.coordinatX + 2 == X || newproObj.coordinatX + 2 == X + 1 || newproObj.coordinatX + 2 == X + 2 || newproObj.coordinatX + 2 == X + 3 || newproObj.coordinatX + 3 == X || newproObj.coordinatX + 3 == X + 1 || newproObj.coordinatX + 3 == X + 2 || newproObj.coordinatX + 3 == X + 3 || newproObj.coordinatX + 4 == X || newproObj.coordinatX + 4 == X + 1 || newproObj.coordinatX + 4 == X + 2 || newproObj.coordinatX + 4 == X + 3))
            {
                Program.suirel = true;
                Program.speed = 0;
                Program.isEnd(this);
            }
        }
    }
}
