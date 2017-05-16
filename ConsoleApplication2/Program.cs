using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Program
    {
        public const int SCREENWIDTH = 18;
        public const int SCREENHEIGTH = 30;
        private const int MAXSPEED = 400;

        public static int livesCount = 3;
        public static int score = 0;
        public static int timerSpeed = 300;
        public static int speed = 0;
        public static bool suirel = false;
        public static List<Problem> problems = new List<Problem>();
        
        public static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = 31;
            Console.BufferWidth = Console.WindowWidth = 50;
            Console.CursorVisible = false;
            int start = 0;
            start = Menu();
            if (start == 1)
            {
                
                Car car = new Car((SCREENWIDTH / 2) - Car.WIDTH / 2, SCREENHEIGTH - Car.LENGTH);
                DrawDisplay d = new DrawDisplay();

                d.ClearConsole(Console.BufferHeight - 1, Console.BufferWidth - 1);

                d.DrawRoad(SCREENHEIGTH, SCREENWIDTH);
                d.DrawCar(car);
            
                Program.MoveGame(car);
            }
        }
        private static int Menu()
        {
            MenuProgram menu = new MenuProgram();
            menu.CreateMenu();
            int start = 0;
            while (true)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                start = menu.SelectArrow(pressedKey);
                if (start == 1)
                {
                    return 1;
                }
            }
        }        
        public static void MoveGame(Car car)
        {
            DrawDisplay d = new DrawDisplay();
            Random rand = new Random();
            Level l = new Level();
            l.levelnumber = 1;
            int proSpace = 0;

            while (true)
            {
                l.levelUp();
                score += 10;
                speed += 20;

                if (speed > MAXSPEED)
                {
                    speed = MAXSPEED;
                }
                suirel = false;

                Problem.CreateProblem(proSpace,l);

                proSpace++;

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    car.Rotate(pressedKey);
                }

                List<Problem> newList = new List<Problem>();
                newList = Problem.MoveProblem(car);

                problems = newList;

                d.ClearConsole(SCREENHEIGTH, SCREENWIDTH);

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

                d.DrawInformation(SCREENWIDTH + 5, SCREENHEIGTH / 3, "Lives: " + livesCount, ConsoleColor.White);
                d.DrawInformation(SCREENWIDTH + 5, SCREENHEIGTH / 3 + 1, "Speed: " + speed, ConsoleColor.White);
                d.DrawInformation(SCREENWIDTH + 5, SCREENHEIGTH / 3 + 2, "Score: " + score, ConsoleColor.White);

                System.Threading.Thread.Sleep(timerSpeed);
            }
        }

        public static void isEnd(Car car)
        {
            DrawDisplay d = new DrawDisplay();

            if (livesCount <= 0)
            {
                d.DrawInformation(Program.SCREENWIDTH + 7, Program.SCREENHEIGTH / 2, "GAME OVER", ConsoleColor.Red);
                d.DrawInformation(Program.SCREENWIDTH + 5, (Program.SCREENHEIGTH / 2) + 1, "Press [enter] to exit", ConsoleColor.Red);
                d.DestroyDrawCar(car);
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }
}
