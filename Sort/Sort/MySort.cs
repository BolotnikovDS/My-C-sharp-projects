using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class MySort<T>
    {
        IComparer<T> comparer;
        int switchToInsertionSort;
        int useMedianOf3;

        public MySort(IComparer<T> comparer, int switchToInsertionSort, int useMedianOf3)
        {
            this.comparer = comparer;
            this.switchToInsertionSort = switchToInsertionSort;
            this.useMedianOf3 = useMedianOf3;
        }

        public MySort() : this(Comparer<T>.Default, 16, 0) { }

        public void Sort(T[] array)
        {
//            InsertionSort(array, comparer);
            QuickSort(array);
        }

        private void QuickSort(T[] array)
        {
            Quick(array, 0, array.Length-1);
        }

        private void Quick(T[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            if (end - start <= switchToInsertionSort)
            {
                InsertionSort(array, start, end);
                return;
            }

            if (end - start >= useMedianOf3)
            {
                int med = getIndexOfMediana(array, start, end);
                T temp = array[med];
                array[med] = array[end];
                array[end] = temp;
            }

            int pivot = Partition(array, start, end);
            Quick(array, start, pivot - 1);
            Quick(array, pivot + 1, end);
        }

        private int Partition(T[] array, int start, int end)
        {
            T temp;//swap helper
            int marker = start;//divides left and right subarrays
            for (int i = start; i <= end; i++)
            {
                if (comparer.Compare(array[i], array[end]) < 0) //array[end] is pivot
                {
                    temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            //put pivot(array[end]) between left and right subarrays
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        private int getIndexOfMediana(T[] array, int start, int end)
        {
            int med = mediana(array[start], array[(end + start) / 2], array[end]);
            if (med == 1)
                return start;
            else if (med == 3)
                return end;
            else
                return (end + start) / 2;
        }

        private int mediana(T a, T b, T c)
        {
            if (comparer.Compare(a, b) > 0)
            { // ba ?c
                if (comparer.Compare(c, a) > 0) // bac
                    return 1;
                return (comparer.Compare(b, c) > 0) ? 2 : 3;
            }
            // ab ? c
            if (comparer.Compare(c, b) > 0) // abc
                return 2;
            return (comparer.Compare(a, c) > 0) ? 1 : 3;
        }

        public void InsertionSort(T[] array, int l, int r)
        {
            for (int j = 1+l; j <= r; j++)
            {
                T key = array[j];
                int i = j - 1;
                for (; i >= l && comparer.Compare(array[i], key) > 0; i--)
                {
                    array[i + 1] = array[i];
                }
                array[i + 1] = key;
            }

            /*            for (int j = 1; j < array.Length; j++)
                        {
                            Student key = array[j];
                            int i = j - 1;
                            count++;
                            for (; i >= 0 && comparer.Compare(array[i], key) == 1; i--)
                            {
                                array[i + 1] = array[i];
                                count++;
                            }
                            array[i + 1] = key;
                        }
            */
        }

        public int GetLastCount()
        {
            object t = typeof(Student);
//            if (t.Equals(typeof(T)))
//                return comparer.;
            return 0;
        }
    }
}
