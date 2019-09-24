using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    enum MoveDirection
    {
        None = 0, Left, Up, Right, Down
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
//            n = Convert.ToInt32(Console.ReadLine());
            Board b = new Board(n);
            Solver solver = new Solver(b);
//            b.PrintMat();
        }
    }
}
