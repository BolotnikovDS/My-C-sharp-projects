using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Puzzle
{
    class Solver
    {
        PriorityQueue<int, Board> queue;
        Board startBoard;

        public Solver(Board startBoard)
        {
            this.startBoard = startBoard;
            queue = new PriorityQueue<int, Board>();
            FindThePath();
        }

        private int Hamming(int[,] A)
        {
            int k = 0;
            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < A.Length; j++)
                    if (A[j, i] != 0 && A[j, i] != j * A.Length + i + 1)
                        k++;
            return k;
        }

        private int Manhattan(int[,] A)
        {
            int k = 0;
            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < A.Length; j++)
                    if (A[j, i] != 0)
                    {
                        int y = A[j, i] / A.Length;
                        int x = A[j, i] % A.Length;
                        k += Math.Abs(x - j) + Math.Abs(y - i);
                    }
            return k;
        }

//        private bool MatrixIsEqual(int[,] A1, int[,] A2)
//        {
//            for (int i = 0; i < A1.GetLength(0); i++)
//                for (int j = 0; j < A1.GetLength(1); j++)
//                    if (A1[i, j] != A2[i, j])
//                        return false;
//            return true;
//        }

//        private bool IsExist(List<Board> l, int[,] A)
//        {
////            PrintMat(A);
//            for (int i = 0; i < l.Count; i++)
//            {
////                Console.WriteLine(i);
////                PrintMat(l[i]);
//                if (MatrixIsEqual(l[i].mat, A))
//                    return true;
//            }
//            return false;
//        }

//        private int FindMat(List<Board> l, int[,] A)
//        {
//            //            PrintMat(A);
//            for (int i = 0; i < l.Count; i++)
//            {
//                //                Console.WriteLine(i);
//                //                PrintMat(l[i]);
//                if (MatrixIsEqual(l[i].mat, A))
//                    return i;
//            }
//            return -1;
//        }

        private void FindThePath()
        {
            var dic = new Dictionary<Board, Board>();
            queue.Enqueue(startBoard.Priority(), startBoard);
            dic.Add(startBoard, null);
            int n = startBoard.GetSize();
            while(queue.Count > 0)
            {
                Board B1 = queue.Dequeue();
                if (B1.Manhattan() == 0)
                    break;
                Board neighbourUp = new Board();
                Board neighbourRight = new Board();
                Board neighbourDown = new Board();
                Board neighbourLeft = new Board();
                Point zero = B1.GetZero();
                if (zero.Y > 0)
                {
                    neighbourUp = B1.Up();
                    if (!dic.ContainsKey(neighbourUp))
                    {
                        queue.Enqueue(neighbourUp.Priority(), neighbourUp);
                        dic.Add(neighbourUp, B1);
                    }
                }
                if (zero.Y < n - 1)
                {
                    neighbourDown = B1.Down();
                    if (!dic.ContainsKey(neighbourDown))
                    {
                        queue.Enqueue(neighbourDown.Priority(), neighbourDown);
                        dic.Add(neighbourDown, B1);
                    }
                }
                if (zero.X > 0)
                {
                    neighbourLeft = B1.Left();
                    if (!dic.ContainsKey(neighbourLeft))
                    {
                        queue.Enqueue(neighbourLeft.Priority(), neighbourLeft);
                        dic.Add(neighbourLeft, B1);
                    }
                }
                if (zero.X < n - 1)
                {
                    neighbourRight = B1.Right();
                    if (!dic.ContainsKey(neighbourRight))
                    {
                        queue.Enqueue(neighbourRight.Priority(), neighbourRight);
                        dic.Add(neighbourRight, B1);
                    }
                }
                
                //if (flagUp)
                //{
                //    queue.Enqueue(neighbourUp.Priority(), neighbourUp);
                //    l.Add(neighbourUp);
                //}
                //if (flagRight)
                //{
                //    queue.Enqueue(neighbourRight.Priority(), neighbourRight);
                //    l.Add(neighbourRight);
                //}
                //if (flagDown)
                //{
                //    queue.Enqueue(neighbourDown.Priority(), neighbourDown);
                //    l.Add(neighbourDown);
                //}
                //if (flagLeft)
                //{
                //    queue.Enqueue(neighbourLeft.Priority(), neighbourLeft);
                //    l.Add(neighbourLeft);
                //}
            }

            Board b = new Board(n, 0);
            List<Board> listOfAns = new List<Board>();
            while (b != null)
            {
                listOfAns.Add(b);
                b = dic[b];
            }
            for (int i = listOfAns.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(i);
                PrintMat(listOfAns[i].mat);
            }
            Console.WriteLine("Count of visited vertices: {0}", dic.Count);
            Console.WriteLine("Count of steps: {0}", listOfAns.Count);
            dic.Clear();
            listOfAns.Clear();
            queue.Clear();
        }

        private void SwapElem(Point p1, Point p2, int[,] mat)
        {
            if (p1.X < 0 || p1.X < 0 || p2.X < 0 || p2.Y < 0 || p1.X >= mat.Length || p1.Y >= mat.Length || p2.X >= mat.Length || p2.Y >= mat.Length)
                throw new IndexOutOfRangeException("Points out of range");
            int t = mat[p1.Y, p1.X];
            mat[p1.Y, p1.X] = mat[p2.Y, p2.X];
            mat[p2.Y, p2.X] = t;
        }

        public void PrintMat(int[,] mat)
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
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
