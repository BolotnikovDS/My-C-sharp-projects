using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BFS
{
    public partial class MazeControl : UserControl
    {
        int deltaX, deltaY;
        Point from, to;
        Queue<Point> path;

        Maze maze;

        public MazeControl()
        {
            InitializeComponent();

            DoubleBuffered = true;

            maze = new Maze();

            from = new Point(-1, -1);
            to = new Point(-1, -1);
            
            deltaX = 30;
            deltaY = 30;
        }

        public void CreateMap()
        {
            maze.CreateMap(Width / deltaX, Height / deltaY, 0.67f);
            Invalidate();
        }

        public void FindShortestPath()
        {
            if (from.X >= 0 && to.X >= 0)
                path = maze.FindShortestPath(from, to);
            Invalidate();
        }

        private Point FindIndex(Point p)
        {
            return new Point(p.X / deltaX, p.Y / deltaY);
        }

        private Point FindCenterOfRect(Point p)
        {
            return new Point(p.X * deltaX + deltaX / 2, p.Y * deltaY + deltaY / 2);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Point index = FindIndex(e.Location);
            if (e.Button == MouseButtons.Left)
            {
                from = index;
            }
            else if (e.Button == MouseButtons.Right)
            {
                to = index;
            }

            path = null;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            for (int i = 0; i < maze.nx; i++)
                for (int j = 0; j < maze.ny; j++)
                    if (!maze.IsOpen(i, j))
                        g.FillRectangle(Brushes.Red, i * deltaX, j * deltaY, deltaX, deltaY);
                    else
                        g.FillRectangle(Brushes.Green, i * deltaX, j * deltaY, deltaX, deltaY);
//            g.FillRectangle(Brushes.Yellow, i * deltaX, j * deltaY, deltaX, deltaY);
            if (from.X >= 0)
                g.FillRectangle(Brushes.Yellow, from.X * deltaX, from.Y * deltaY, deltaX, deltaY);
            if (to.X >= 0)
                g.FillRectangle(Brushes.Yellow, to.X * deltaX, to.Y * deltaY, deltaX, deltaY);

            using (Pen p = new Pen(Color.Black))
            {
                for (int i = 1; i < maze.nx; i++)
                    g.DrawLine(p, i * deltaX, 0, i * deltaX, Size.Height);
                for (int i = 1; i < maze.ny; i++)
                    g.DrawLine(p, 0, i * deltaY, Size.Width, i * deltaY);
            }

            if (path != null)
            {
                Point o2 = to;
                foreach (Point o in path)
                {
                    g.DrawLine(new Pen(Color.Blue), FindCenterOfRect(o), FindCenterOfRect(o2));
                    o2 = o;
                }
            }
        }
    }
}
