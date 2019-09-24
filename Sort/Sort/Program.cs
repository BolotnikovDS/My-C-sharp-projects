using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student {Name = "Vasya", Mark = 3};
            Student s2 = new Student {Name = "Kolya", Mark = 2};
            Student s3 = new Student {Name = "Vadim", Mark = 4};
            Student s4 = new Student {Name = "Dima", Mark = 5};
            Student s5 = new Student {Name = "Timur", Mark = 5};

            String[] names = new String[] {"Vasya", "Kolya", "Vadim", "Dima", "Timur"};
            //            int n = Convert.ToInt32(Console.ReadLine());

            int n = (int)1e5;
            Student[] people = new Student[] { s1, s2, s3, s4, s5};

            Student[] stud = new Student[n];
            Random rnd = new Random(42);
            for (int i = 0; i < n; i++)
                stud[i] = new Student { Name = names[rnd.Next(5)], Mark = rnd.Next() };

            Student[] studSystem = GetCopy(stud);
            StudentCompare compare2 = new StudentCompare();
            Array.Sort(studSystem, compare2);
            Console.WriteLine(compare2.GetCount());


            for (int h = 0; h < 64; h++)
            {
                var studTemp = GetCopy(stud);
                StudentCompare compare1 = new StudentCompare();
                MySort<Student> method = new MySort<Student>(compare1, h, 0);
                method.Sort(studTemp);

                bool flag = true;
                for (int i = 0; i < n; i++)
                    if (studTemp[i].Mark != studSystem[i].Mark)
                        flag = false;
                Console.WriteLine("{0}: {1} {2}", h, flag, compare1.GetCount());
            }
            //MySort<int> method2 = new MySort<int>();
            //method2.Sort(a1);

            //Array.Sort(a2);

            //bool flag2 = true;
            //for (int i = 0; i < n; i++)
            //    if (a1[i] != a2[i])
            //        flag2 = false;

            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine("{1} - {0}     {3} - {2}", stud[i].Name, stud[i].Mark, studSystem[i].Name, studSystem[i].Mark);
            //}
        }

        private static T[] GetCopy<T>(T[] src)
        {
            var result = new T[src.Length];
            Array.Copy(src, result, src.Length);
            return result;
        }
    }
}
