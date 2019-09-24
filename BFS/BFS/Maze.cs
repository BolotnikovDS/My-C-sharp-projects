using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BFS
{
    public class Maze
    {
        public int nx { get; private set; }
        public int ny { get; private set; }
        
        bool[,] map;

        public void CreateMap(int nx, int ny, float p)
        {
            this.nx = nx;
            this.ny = ny;
            map = new bool[nx, ny];
            Random rnd = new Random();
            for (int i = 0; i < nx; i++)
                for (int j = 0; j < ny; j++)
                    map[i, j] = rnd.NextDouble() < p;
        }

        public bool IsOpen(int x, int y)
        {
            return map[x, y];
        }

        public Queue<Point> FindShortestPath(Point from, Point to)
        {
            var q = new Queue<Point>();
            var way = bfs(from, to);
            if (way[to.X, to.Y] == 0)
                return q;
            Point curr = to;
            //q.Enqueue(curr);
            while (true)
            {
                Console.WriteLine($"curr: {curr}, from: {from}, to: {to}, way: {way[curr.X, curr.Y]}");
                if (way[curr.X, curr.Y] == MoveDirection.Up)
                    curr.Y += 1;
                else if (way[curr.X, curr.Y] == MoveDirection.Right)
                    curr.X -= 1;
                else if (way[curr.X, curr.Y] == MoveDirection.Down)
                    curr.Y -= 1;
                else if (way[curr.X, curr.Y] == MoveDirection.Left)
                    curr.X += 1;
                q.Enqueue(curr);
                if (curr == from)
                    return q;
            }
        }

        private MoveDirection[,] bfs(Point start, Point finish)
        {
            Queue<Point> q = new Queue<Point>();
            MoveDirection[,] way = new MoveDirection[nx, ny];

            q.Enqueue(start);
            for (int i = 0; i < nx; i++)
                for (int j = 0; j < ny; j++)
                    if (!map[i, j])
                        way[i, j] = MoveDirection.Closed;

            way[start.X, start.Y] = MoveDirection.Start;
            while (q.Count > 0)
            {
                Point current = q.Dequeue();
                if (current == finish)
                {
                    q.Clear();
                    return way;
                }
                if (current.Y > 0 && way[current.X, current.Y - 1] == MoveDirection.None)
                {
                    q.Enqueue(new Point(current.X, current.Y - 1));
                    way[current.X, current.Y - 1] = MoveDirection.Up;
                }
                if (current.X < nx - 1 && way[current.X + 1, current.Y] == MoveDirection.None)
                {
                    q.Enqueue(new Point(current.X + 1, current.Y));
                    way[current.X + 1, current.Y] = MoveDirection.Right;
                }
                if (current.Y < ny - 1 && way[current.X, current.Y + 1] == MoveDirection.None)
                {
                    q.Enqueue(new Point(current.X, current.Y + 1));
                    way[current.X, current.Y + 1] = MoveDirection.Down;
                }
                if (current.X > 0 && way[current.X - 1, current.Y] == MoveDirection.None)
                {
                    q.Enqueue(new Point(current.X - 1, current.Y));
                    way[current.X - 1, current.Y] = MoveDirection.Left;
                }
            }
            return way;
        }
    }
}
