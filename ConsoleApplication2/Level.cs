using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
     public class Level
    {
        public int levelnumber = 1;
        public int lvladdscore = 2000;
        public int maxlevel = 3;

        public void levelUp()
        {
            if (Program.score == lvladdscore && levelnumber <= maxlevel)
            {
                levelnumber += 1;
                Program.timerSpeed -= 100;
                lvladdscore += lvladdscore;
            }
        }

        public Problem levelOne(int newXCoordinat)
        {
            Problem problem = new Problem(newXCoordinat, 0, new string[] { "#", "#", "#" });
            return problem;
        }
        public Problem levelTwo(int newXCoordinat)
        {
            Problem problem = new Problem(newXCoordinat, 0, new string[] { "#", "#", "#", "#" });
            return problem;
        }
        public Problem levelThree(int newXCoordinat)
        {
            Problem problem = new Problem(newXCoordinat, 0, new string[] { "#", "#", "#", "#", "#" });
            return problem;
        }
    }
}
