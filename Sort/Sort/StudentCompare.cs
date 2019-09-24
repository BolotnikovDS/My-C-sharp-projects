using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class StudentCompare : IComparer<Student>
    {
        int count=0;

        public int Compare(Student s1, Student s2)
        {
            count++;
            if (s1.Mark > s2.Mark)
                return 1;
            else if (s1.Mark < s2.Mark)
                return -1;
            else
                return 0;
        }

        public int GetCount()
        {
            return count;
        }
    }
}
