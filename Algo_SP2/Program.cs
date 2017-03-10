using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_SP2
{
    class Program
    {
        private Stopwatch stopwatch;
        private Random randomNumber;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Runner();
        }

        public TimeSpan TimeInsertionSort(int[] dataSet)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            SortingAlgoritms.InsertionSort(dataSet);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        public TimeSpan TimeSelectionSort(int[] dataSet)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            SortingAlgoritms.Selectsort(dataSet);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        public TimeSpan TimeMergeSort(int[] dataSet)
        {
            stopwatch = new Stopwatch();
            var dataList = dataSet.ToList();
            stopwatch.Start();
            SortingAlgoritms.MergeSort(dataList);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        public int[] GenerateRandomArr(int n)
        {
            int[] randomNum = new int[n];
            randomNumber = new Random();


            for (int i = 0; i < n; i++)
            {
                randomNum[i] = randomNumber.Next(1, n);
            }

            return randomNum;
        }

        public void Runner()
        {
            var insertionSortVal = TimeInsertionSort(GenerateRandomArr(1000)).TotalSeconds;
            var selectionSortVal = TimeInsertionSort(GenerateRandomArr(1000)).TotalSeconds;
            var mergeSortVal = TimeInsertionSort(GenerateRandomArr(1000)).TotalSeconds;
            for (int i = 2000; i <= 32000; i = i*2)
            {
                insertionSortVal *= 4;
                Console.WriteLine("InsertionSort  i = " + i + " , " + "expected: " + insertionSortVal + " , actual: " +
                                  TimeInsertionSort(GenerateRandomArr(i)));
                selectionSortVal *= 4;
                Console.WriteLine("SelectionSort  i = " + i + " , " + "expected: " + selectionSortVal + " , actual: " +
                                  TimeSelectionSort(GenerateRandomArr(i)));
                mergeSortVal *= 2;
                Console.WriteLine("MergeSort      i = " + i + " , " + "expected: " + mergeSortVal + " , actual: " +
                                  TimeMergeSort(GenerateRandomArr(i)));
            }
            Console.ReadKey();
        }
    }
}