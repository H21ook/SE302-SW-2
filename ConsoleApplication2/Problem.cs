using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Problem
    {
        public string[] problem { get; set; }
        public static int problemLenght { get; set; }
        public int coordinatX { get; set; }
        public int coordinatY { get; set; }
        public Problem(int x, int y, string[] p)
        {
            problem = p;
            coordinatX = x;
            coordinatY = y;
            problemLenght = problem.Length;
        }
        public static void CreateProblem(int proSpace, Level l)
        {
            Random rand = new Random();

            if (proSpace % (Car.LENGTH + Car.LENGTH) == 0)
            {
                int newXCoordinat = 0;
                newXCoordinat = rand.Next(1, Program.SCREENWIDTH - Problem.problemLenght);

                switch (l.levelnumber)
                {
                    case 1:
                        Program.problems.Add(l.levelOne(newXCoordinat));
                        break;
                    case 2:
                        Program.problems.Add(l.levelTwo(newXCoordinat));
                        break;
                    case 3:
                        Program.problems.Add(l.levelThree(newXCoordinat));
                        break;
                    default:
                        break;
                }
            }
        }
        public static List<Problem> MoveProblem(Car car)
        {
            DrawDisplay d = new DrawDisplay();
            List<Problem> newList = new List<Problem>();

            for (int i = 0; i < Program.problems.Count; i++)
            {
                Problem oldProblem = Program.problems[i];
                Problem newproObj = new Problem(oldProblem.coordinatX, oldProblem.coordinatY + 1, oldProblem.problem);

                for (int j = 0; j < newproObj.problem.Length; j++)
                {
                    car.isDestroy(newproObj);
                }
                if (newproObj.coordinatY < Console.WindowHeight)
                {
                    newList.Add(newproObj);
                }
            }
            return newList;
        }
    }
}
