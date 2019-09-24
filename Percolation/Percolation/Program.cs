using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Percolation
{

    class Program
    {

        static void Main(string[] args)
        {
            int k = 100;
            double[] x = new double[k];
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < k; i++)
            {
                DSU method = new DSU(n);
                x[i] = method.StartRand() / (double)n / n;
            }
            double ex = 0, dev = 0;
            for (int i = 0; i < x.Length; i++)
                ex += x[i];
            ex /= x.Length;
            for (int i = 0; i < x.Length; i++)
                dev += (x[i] - ex) * (x[i] - ex);
            dev /= x.Length - 1;
            Console.Write($"{ex}   {dev}");
        }
    }
}
