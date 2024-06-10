using System;
using System.Diagnostics;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> selectionSort = SelectionSort;
            Func<int[], int[]> studentSelectionSort = StudentSelectionSort;

            Func<int[], int[]> shakerSort = ShakerSort;
            Func<int[], int[]> studentShakerSort = StudentShakerSort;

            TestSort("Selection Sort", selectionSort, studentSelectionSort);

            TestSort("Shaker Sort", shakerSort, studentShakerSort);
            Console.ReadKey();
        }

        static void TestSort(string sortName, Func<int[], int[]> referenceSort, Func<int[], int[]> studentSort)
        {
            Console.WriteLine($"Testing {sortName}");

            int[] array = GenerateRandomArray(1000);

            try
            {
                int[] referenceResult = referenceSort(array);
                Console.WriteLine($"Reference Sort Time: {MeasureSortingTime(referenceSort, array)} ms");

                int[] studentResult = studentSort(array);
                Console.WriteLine($"Reference Sort Time: {MeasureSortingTime(studentSort, array)} ms");

                bool isSortedCorrectly = ArraysAreEqual(referenceResult, studentResult);
                bool isTimeAcceptable = IsTimeAcceptable(MeasureSortingTime(referenceSort, array), MeasureSortingTime(studentSort, array));

                Console.WriteLine($"Sorting Correctly: {isSortedCorrectly}");
                Console.WriteLine($"Time Acceptable: {isTimeAcceptable}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error during testing {sortName}: {ex.Message}");
            }

            Console.WriteLine();
        }
        static int[] StudentShakerSort(int[] array)
        {
            int[] result = (int[])array.Clone();
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < result.Length - 1; i++)
                {
                    if (result[i] > result[i + 1])
                    {
                        int temp = result[i];
                        result[i] = result[i + 1];
                        result[i + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;

                swapped = false;

                for (int i = result.Length - 2; i >= 0; i--)
                {
                    if (result[i] > result[i + 1])
                    {
                        int temp = result[i];
                        result[i] = result[i + 1];
                        result[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
            return result;
        }

        static int[] SelectionSort(int[] array)
        {
            int[] result = (int[])array.Clone();

            for (int i = 0; i < result.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = 0; j < result.Length; j++)
                {
                    if (result[j] < result[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = result[i];
                result[i] = result[minIndex];
                result[minIndex] = temp;
            }
            return result;
        }

        static int[] StudentSelectionSort(int[] array)
        {
            int[] result = (int[])array.Clone();

            for (int i = 0; i < result.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = 0; j < result.Length; j++)
                {
                    if (result[j] < result[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = result[i];
                result[i] = result[minIndex];
                result[minIndex] = temp;
            }
            return result;
        }

        static int[] ShakerSort(int[] array)
        {
            int[] result = (int[])array.Clone();
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < result.Length - 1; i++)
                {
                    if (result[i] > result[i + 1])
                    {
                        int temp = result[i];
                        result[i] = result[i + 1];
                        result[i + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;

                swapped = false;

                for (int i = result.Length - 2; i >= 0; i--)
                {
                    if (result[i] > result[i + 1])
                    {
                        int temp = result[i];
                        result[i] = result[i + 1];
                        result[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
            return result;
        }

        static int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1000);
            }

            return array;
        }

        static bool ArraysAreEqual(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length)
                return false;

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                    return false;
            }

            return true;
        }

        static bool IsTimeAcceptable(long referenceTime, long studentTime)
        {
            const int acceptableTimeDifference = 200;

            return studentTime >= Math.Max(0, referenceTime / 5 - acceptableTimeDifference) && studentTime <= referenceTime * 5 + acceptableTimeDifference;
        }

        static long MeasureSortingTime(Func<int[], int[]> sortingMethod, int[] array)
        {
            Stopwatch timer = Stopwatch.StartNew();
            sortingMethod(array);
            timer.Stop();
            return timer.ElapsedMilliseconds;
        }
    }
}

