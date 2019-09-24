using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Puzzle
{
    class Board
    {
        int n;
        public int[,] mat;
        int moves;
        static Random rnd = new Random(5);
        Point zero;
        MoveDirection from;

        int manhattan;

        public Board()
        {

        }

        public Board(int n, int randomMoves = 500)
        {
            this.n = n;
            mat = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    mat[i, j] = i * n + j + 1;
            mat[n - 1, n - 1] = 0;
            zero = new Point(n - 1, n - 1);
            from = MoveDirection.None;
            CreateBoard(randomMoves);
            manhattan = CalcManhattan();
            moves = 0;
        }

        public Board(Board B)
        {
            this.n = B.n;
            this.moves = B.moves;
            this.mat = (int[,])B.mat.Clone();
            this.zero = B.zero;
            this.from = B.from;
            this.manhattan = B.manhattan;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj.GetType() != typeof(Board))
                return false;
            Board b = (Board)obj;
            if (n != b.n)
                return false;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (mat[i, j] != b.mat[i, j])
                        return false;
            return true;
        }

        public override int GetHashCode()
        {
            int h = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    h = h * 17 + mat[i, j];
            return h;
        }

        private void CreateBoard(int k)
        {
            for (int i = 0; i < k; i++)
            {
                
                double t = rnd.NextDouble();
                MoveDirection where;
                if (zero.X == n - 1)
                {
                    if (zero.Y == n - 1)
                    {
                        if (t < 0.5)
                            where = MoveDirection.Left;
                        else
                            where = MoveDirection.Up;
                    }
                    else if (zero.Y == 0)
                    {
                        t = rnd.NextDouble();
                        if (t < 0.5)
                            where = MoveDirection.Left;
                        else
                            where = MoveDirection.Down;
                    }
                    else
                    {
                        t = rnd.NextDouble();
                        if (t < 0.33)
                            where = MoveDirection.Left;
                        else if (t < 0.67)
                            where = MoveDirection.Down;
                        else
                            where = MoveDirection.Up;
                    }
                }
                else if (zero.X == 0)
                {
                    if (zero.Y == n - 1)
                    {
                        t = rnd.NextDouble();
                        if (t < 0.5)
                            where = MoveDirection.Right;
                        else
                            where = MoveDirection.Up;
                    }
                    else if (zero.Y == 0)
                    {
                        t = rnd.NextDouble();
                        if (t < 0.5)
                            where = MoveDirection.Right;
                        else
                            where = MoveDirection.Down;
                    }
                    else
                    {
                        t = rnd.NextDouble();
                        if (t < 0.33)
                            where = MoveDirection.Right;
                        else if (t < 0.67)
                            where = MoveDirection.Down;
                        else
                            where = MoveDirection.Up;
                    }
                }
                else if (zero.Y == n - 1)
                {
                    t = rnd.NextDouble();
                    if (t < 0.33)
                        where = MoveDirection.Right;
                    else if (t < 0.67)
                        where = MoveDirection.Left;
                    else
                        where = MoveDirection.Up;
                }
                else if (zero.Y == 0)
                {
                    t = rnd.NextDouble();
                    if (t < 0.33)
                        where = MoveDirection.Right;
                    else if (t < 0.67)
                        where = MoveDirection.Left;
                    else
                        where = MoveDirection.Down;
                }
                else
                {
                    t = rnd.NextDouble();
                    if (t < 0.25)
                        where = MoveDirection.Right;
                    else if (t < 0.5)
                        where = MoveDirection.Left;
                    else if (t < 0.75)
                        where = MoveDirection.Down;
                    else
                        where = MoveDirection.Up;
                }
                step(where);
                //Console.WriteLine(i);
                //PrintMat();
            }
        }

        public int Hamming()
        {
            int k = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (mat[i, j] != 0 && mat[i, j] != i * n + j + 1)
                        k++;
            return k;
        }

        private int CalcManhattan()
        {
            int k = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (mat[j, i] != 0)
                    {
                        int y = (mat[i, j]-1) / n;
                        int x = (mat[i, j]-1) % n;
                        k += Math.Abs(x - j) + Math.Abs(y - i);
                    }
            return k;
        }

        public int Manhattan()
        {
            return manhattan;
        }

        public int Priority()
        {
            return manhattan;// + moves;
        }

        private void SwapElem(Point p1, Point p2)
        {
            if (p1.X < 0 || p1.X < 0 || p2.X < 0 || p2.Y < 0)
                return;
            int t = mat[p1.Y, p1.X];
            mat[p1.Y, p1.X] = mat[p2.Y, p2.X];
            mat[p2.Y, p2.X] = t;
            manhattan = CalcManhattan();
        }

        private void step(MoveDirection move)
        {
            if (move == MoveDirection.Up)
            {
                Point zero0 = zero;
                zero.Y--;
                SwapElem(zero0, zero);
            }
            else if (move == MoveDirection.Right)
            {
                Point zero0 = zero;
                zero.X++;
                SwapElem(zero0, zero);
            }
            else if (move == MoveDirection.Down)
            {
                Point zero0 = zero;
                zero.Y++;
                SwapElem(zero0, zero);
            }
            else if (move == MoveDirection.Left)
            {
                Point zero0 = zero;
                zero.X--;
                SwapElem(zero0, zero);
            }
            moves++;
        }

        public Board Left()
        {
            Board B = new Board(this);
            B.from = MoveDirection.Right;
            B.step(MoveDirection.Left);
            return B;
        }

        public Board Right()
        {
            Board B = new Board(this);
            B.from = MoveDirection.Left;
            B.step(MoveDirection.Right);
            return B;
        }

        public Board Up()
        {
            Board B = new Board(this);
            B.from = MoveDirection.Down;
            B.step(MoveDirection.Up);
            return B;
        }

        public Board Down()
        {
            Board B = new Board(this);
            B.from = MoveDirection.Up;
            B.step(MoveDirection.Down);
            return B;
        }

        public Point GetZero()
        {
            return zero;
        }

        public int GetSize()
        {
            return n;
        }

        public MoveDirection GetFrom()
        {
            return from;
        }

        public void PrintMat()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(mat[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
