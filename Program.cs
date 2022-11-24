using System;

namespace HomeWork5
{
    class Program
    {
        static void Main()
        {


            int[] array = new int[5];

            RandomArrayFill(array);
            PrintArray(array);


            Console.WriteLine("Bubble sorted array: ");
            BubbleSort(array); //Время O(n^2) Память O(1)
            PrintArray(array);

            Console.WriteLine("Shaker sorted array: ");
              ShakerSort(array); //Время O(n^2) Память O(1)
            PrintArray(array);

            Console.WriteLine("Comb sorted array: ");
            CombSort(array); //Время O(n^2) Память O(1)
            PrintArray(array);

            Console.WriteLine("Insert sorted array: ");
            InsertionSort(array); //Время O(n^2) Память O(n)+O(1)
            PrintArray(array);

            Console.WriteLine("Quick sorted array: ");
            QuickSort(array); //Время O(n^2) Память O(n)
            PrintArray(array);

            Console.WriteLine("Merge sorted array: ");
            MergeSort(array); //Время O(nlogn) Память O(n)
            PrintArray(array);



        }
        static void Swap(ref int x, ref int y)
        {
            var temp = x;
            x = y;
            y = temp;
        }
        public static void RandomArrayFill(int[] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-10, 10);
            }
        }
        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j + 1], ref array[j]);
                    }
                }

            }
        }
        public static void ShakerSort(int[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                bool swapFlag = false;
               
                for (int j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

               
                for (int j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                    }
                }

               
                if (!swapFlag)
                {
                    break;
                }
            }
        }

        public static void CombSort( int[] array)
        {
            double gap = array.Length;
            bool swaps = true;

            while (gap > 1 || swaps)
            {
                gap /= 1.247330950103979;

                if (gap < 1)
                    gap = 1;

                int i = 0;
                swaps = false;

                while (i + gap < array.Length)
                {
                    int igap = i + (int)gap;

                    if (array[i] > array[igap])
                    {
                        Swap(ref array[i], ref array[igap]);
                        swaps = true;
                    }

                    ++i;
                }
            }
        }

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; ++i)
            {
                int x = array[i];
                int j = i;
                while (j > 0 && array[j - 1] > x)
                {
                    array[j] = array[j - 1];
                    --j;
                }
                array[j] = x;
            }
        }

        public static int Partition(int[] array, int l, int r)
        {
            int x = array[r];
            int less = l;

            for (int i = l; i < r; ++i)
            {
                if (array[i] <= x)
                {
                    Swap(ref array[i], ref array[less]);
                    ++less;
                }
            }
            Swap(ref array[less], ref array[r]);
            return less;
        }

        public static void QuickSortImpl(int[] array, int l, int r)
        {
            if (l < r)
            {
                int q = Partition(array, l, r);
                QuickSortImpl(array, l, q - 1);
                QuickSortImpl(array, q + 1, r);
            }
        }

        public static void QuickSort(int[] array)
        {
            if (array.Length!=0)
            {
                QuickSortImpl(array, 0, array.Length-1);
            }
        }

        public static void MergeSortImpl(int[] array, int[] buffer, int l, int r)
        {
            if (l < r)
            {
                int m = (l + r) / 2;
                MergeSortImpl(array, buffer, l, m);
                MergeSortImpl(array, buffer, m + 1, r);

                int k = l;
                for (int i = l, j = m + 1; i <= m || j <= r;)
                {
                    if (j > r || (i <= m && array[i] < array[j]))
                    {
                        buffer[k] = array[i];
                        ++i;
                    }
                    else
                    {
                        buffer[k] = array[j];
                        ++j;
                    }
                    ++k;
                }
                for (int i = l; i <= r; ++i)
                {
                    array[i] = buffer[i];
                }
            }
        }

        public static void MergeSort(int[] array)
        {
            if (array.Length != 0)
            {
                int[] buffer = new int[array.Length];
                MergeSortImpl(array, buffer, 0, array.Length - 1);
            }
        }






    }

}
    

