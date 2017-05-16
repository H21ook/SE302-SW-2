using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class MenuProgram
    {
        DrawDisplay d = new DrawDisplay();
        string[] menuList = new string[2];
        const string arrow = ">";
        const int startY = 15;
        int arrowX = 18, arrowY = 15;
        public MenuProgram()
        {
            menuList = new string[]{ "Start", "Exit" };
        }
        public void CreateMenu()
        {
            d.DrawInformation(arrowX, arrowY, arrow, ConsoleColor.Red);
            for (int i = 0; i < menuList.Length; i++)
            {
                d.DrawInformation(arrowX+2, startY+i, menuList[i], ConsoleColor.Green);
            }
        }
        public int SelectArrow(ConsoleKeyInfo pressedKey)
        {
            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                    if (arrowY > 15)
                    {
                        d.DrawInformation(arrowX, arrowY, " ", ConsoleColor.Red);
                        d.DrawInformation(arrowX, arrowY - 1, arrow, ConsoleColor.Red);
                        arrowY -= 1;
                        return 0;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (arrowY < 16)
                    {
                        d.DrawInformation(arrowX, arrowY, " ", ConsoleColor.Red);
                        d.DrawInformation(arrowX, arrowY + 1, arrow, ConsoleColor.Red);
                        arrowY += 1;
                        return 0;
                    }
                    break;
                case ConsoleKey.Enter:
                    if (startY == arrowY)
                    {
                        return 1;
                    }
                    else
                    {
                        Environment.Exit(0);
                        return 0;
                    }
            }
            return 2;
        }
    }
}
