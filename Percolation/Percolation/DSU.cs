using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Percolation
{
    class DSU
    {
        int n;
        bool[,] was;
        int top, bottom;
        DS ds;
        static Random rnd1 = new Random();

        int GetIndex(int x, int y)
        {
            return x * n + y;
        }
        public DSU(int n)
        {
            this.n = n;
            top = n * n;
            bottom = n * n + 1;
            ds = new DS(n*n + 2);
            for (int i = 0; i < n; i++)
            {
                ds.union_sets(top, GetIndex(i, 0));
                ds.union_sets(bottom, GetIndex(i, n-1));
            }

            was = new bool[n, n];
        }

        private void CheckNeighbours(Point p)
        {
            if (p.X > 0)
                if (was[p.X - 1, p.Y])
                    ds.union_sets(GetIndex(p.X - 1, p.Y), GetIndex(p.X, p.Y));
            if (p.X < n-1)
                if (was[p.X + 1, p.Y])
                    ds.union_sets(GetIndex(p.X + 1, p.Y), GetIndex(p.X, p.Y));
            if (p.Y > 0)
                if (was[p.X, p.Y-1])
                    ds.union_sets(GetIndex(p.X, p.Y - 1), GetIndex(p.X, p.Y));
            if (p.Y < n-1)
                if (was[p.X, p.Y+1])
                    ds.union_sets(GetIndex(p.X, p.Y + 1), GetIndex(p.X, p.Y));
        }

        private void Step()
        {
            int x = rnd1.Next(n);
            int y = rnd1.Next(n);
            while (was[x,y])
            {
                x = rnd1.Next(n);
                y = rnd1.Next(n);
            }
            was[x, y] = true;

            Point p = new Point(x, y);
            CheckNeighbours(p);
        }

        public int StartRand()
        {
            int k = 0;
            while (ds.find_set(top) != ds.find_set(bottom))
            {
                Step();
                k++;
            }
            return k;
        }
    }
}
