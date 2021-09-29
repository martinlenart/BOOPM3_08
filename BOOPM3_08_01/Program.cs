using System;

namespace BOOPM3_08_01
{
    class Program
    {
        public static class QuickSort
        {
            public static void Sort<T>(T[] array) where T : IComparable
            {
                WriteArray("\nUnsorted array:", array);
                Sort(array, 0, array.Length - 1);
                WriteArray("\nSorted array:", array);
            }

            private static void Sort<T>(T[] array, int lowerIdx, int upperIdx) where T : IComparable
            {
                //base case
                if (lowerIdx >= upperIdx)
                    return;

                //action case - arrange a pivot where all elements in the lower part are less
                int pivotIdx = Partition(array, lowerIdx, upperIdx);

                //recursive case
                Sort(array, lowerIdx, pivotIdx - 1);
                Sort(array, pivotIdx + 1, upperIdx);
            }

            public static int Partition<T>(T[] array, int lowerIdx, int upperIdx) where T : IComparable
            {
                Console.Write($"\n\n----Partition run [{lowerIdx}] to [{upperIdx}]");

                //assume pivot point as set the lower part of the array just after the pivot
                int pivotIdx = upperIdx;
                upperIdx--;

                do
                {
                    while (array[lowerIdx].CompareTo(array[pivotIdx]) < 0) { lowerIdx++; }
                    while (array[upperIdx].CompareTo(array[pivotIdx]) > 0) { upperIdx--; }

                    if (lowerIdx >= upperIdx)
                        break;

                    WriteArray("Before HiLo swap:", array, pivotIdx, lowerIdx, upperIdx);

                    //swap them using tuple, array[lowerIdx] is now in the right place
                    (array[lowerIdx], array[upperIdx]) = (array[upperIdx], array[lowerIdx]);

                    WriteArray("After HiLo swap:", array, pivotIdx, lowerIdx, upperIdx);

                    //array[lowerIdx] is now in the right place so advance lowerIdx
                    lowerIdx++;
                }
                while (lowerIdx <= upperIdx);

                WriteArray("Before LoPiv swap:", array, pivotIdx, lowerIdx, upperIdx);

                //as a final step swap the value for the lower idx with the initial pivot and update pivotIdx 
                (array[lowerIdx], array[pivotIdx]) = (array[pivotIdx], array[lowerIdx]);
                pivotIdx = lowerIdx;

                WriteArray("After LoPiv swap:", array, pivotIdx, lowerIdx, upperIdx);

                return pivotIdx;
            }
            private static void WriteArray<T>(string title, T[] array, int pivotIdx = -1, int lowerIdx = -1, int upperIdx = -1) where T : IComparable
            {
                Console.WriteLine();
                Console.Write($"{title,-20}");
                for (int i = 0; i < array.Length; i++)
                {
                    string prefix = null;
                    if (i == pivotIdx)
                        prefix = "P";
                    if (i == lowerIdx)
                        prefix += "L";
                    if (i == upperIdx)
                        prefix += "U";

                    if (prefix != null)
                        prefix += ":";

                    Console.Write($"{prefix,4}{array[i],-10}");
                }
            }
        }

        static void Main(string[] args)
        {
            int[] array1 = { 5, 42, 36, 1, 40, 5 };
            QuickSort.Sort<int>(array1);

            Console.WriteLine();
            string[] array2 = "the quick brown fox catches a slower rabbit".Split(' ');
            QuickSort.Sort<string>(array2);
        }
    }
}
