using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    class MazePainter : IDisposable
    {
        //IntPtr h;
        Graphics g;

        MazePainter()
        {
            //g = 
            //h = CreatePen
        }

        //~MazePainter()
        //{
        //    Dispose(false);
        //}

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
                g.Dispose();

            //DestroyPen(h)
        }
    }
}
