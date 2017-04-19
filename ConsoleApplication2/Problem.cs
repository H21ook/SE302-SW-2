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
        public ConsoleColor color { get; set; }
        public int coordinatX { get; set; }
        public int coordinatY { get; set; }
        public Problem(int x,int y,ConsoleColor c,string[] p)
        {
            problem = p;
            color = c;
            coordinatX = x;
            coordinatY = y;
        }
    }
}
