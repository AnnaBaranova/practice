using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Task12
{
    class Sort
    {
        private static int quickComparisonCount;
        private static int quickMovesCount;

        public static void Selection(List<int> list, out int comparisonCount, out int movesCount)
        {
            comparisonCount = 0;
            movesCount = 0;
            for (int i = 0; i < list.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    comparisonCount++;
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }

                comparisonCount++;
                if (list[i] != list[min])
                {
                    movesCount++;
                    int temp = list[i];
                    list[i] = list[min];
                    list[min] = temp;
                }

            }
        }

        public static void Quick(List<int> list, out int comparisonCount, out int movesCount)
        {
            quickComparisonCount = 0;
            quickMovesCount = 0;
            QuickRecursive(list, 0, list.Count - 1);
            comparisonCount = quickComparisonCount;
            movesCount = quickMovesCount;
        }
        private static void QuickRecursive(List<int> list, int low, int high)
        {
            if (low < high)
            {
                int p = Partition(list, low, high);
                QuickRecursive(list, low, p);
                QuickRecursive(list, p + 1, high);
            }
            quickComparisonCount++;
        }
        private static int Partition(List<int> list, int low, int high)
        {
            int pivot = list[low];
            int i = low - 1;
            int j = high + 1;
            while (true)
            {
                do
                {
                    i++;
                    quickComparisonCount++;
                } while (list[i] < pivot);
                do
                {
                    j--;
                    quickComparisonCount++;
                } while (list[j] > pivot);

                quickComparisonCount++;
                if (i >= j)
                    return j;

                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
                quickMovesCount++;
            }
        }
    }

    class Program
    {
        static int InputInt(int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                string rawInput = Console.ReadLine();
                int result;
                if (int.TryParse(rawInput, out result))
                {
                    if (result < min)
                    {
                        Console.WriteLine("Too small number, try again");
                    }
                    else
                    {
                        if (result > max)
                        {
                            Console.WriteLine("Too big number, try again");
                        }
                        else
                        {
                            return result;
                        }
                    }
                }
                else
                {
                    Console.Write("Not a number. Retry enter: ");
                    Console.WriteLine();
                }
            }
        }
        public static void Shuffle(List<int> list)
        {
            Random rnd = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                int value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public static void PrintList(List<int> list)
        {
            Console.WriteLine();
            foreach (var elem in list)
                Console.Write(elem + " ");
            Console.WriteLine("");
            //Console.WriteLine();
        }
        public static List<int> CloneList(List<int> mainList)
        {
            List<int> clonedList = new List<int>();
            foreach (var i in mainList)
                clonedList.Add(i);
            return clonedList;
        }

        static void Main(string[] args)
        {
            bool printArrays = false;
            while (true)
            {
                int comparisonCount = 0;
                int movesCount = 0;

                Console.Write("Enter number of elems in array or <0> to exit: ");
                int count = InputInt(0, 11000); // если больше, то при быстрой сортировке идёт переполнение стека
                if (count == 0)
                    break;
                Console.WriteLine();

                List<int> insertList = new List<int>();

                for (int i = 1; i <= count; i++)
                    insertList.Add(i);

                Shuffle(insertList); // перемешивание

                List<int> quickList = CloneList(insertList);
                if (printArrays)
                    PrintList(insertList);
                Sort.Selection(insertList, out comparisonCount, out movesCount);
                Console.Write("Shuffled list. \nSelection sorting. Comparisons count: {0,10}, Moves count: {1,10}", comparisonCount, movesCount);
                if (printArrays)
                    PrintList(insertList);

                Console.WriteLine();
                if (printArrays)
                    PrintList(insertList);
                Sort.Selection(insertList, out comparisonCount, out movesCount);
                Console.Write("Sorted list. \nSelection sorting. Comparisons count: {0,10}, Moves count: {1,10}", comparisonCount, movesCount);
                if (printArrays)
                    PrintList(insertList);

                Console.WriteLine();
                insertList.Reverse();
                if (printArrays)
                    PrintList(insertList);
                Sort.Selection(insertList, out comparisonCount, out movesCount);
                Console.Write("Reversed list. \nSelection sorting. Comparisons count: {0,10}, Moves count: {1,10}", comparisonCount, movesCount);
                if (printArrays)
                    PrintList(insertList);

                Console.WriteLine("");
                Console.WriteLine("");

                if (printArrays)
                    PrintList(quickList);
                Sort.Quick(quickList, out comparisonCount, out movesCount);
                Console.Write("Shuffled list. \nQuick sorting. Comparisons count: {0,10}, Moves count: {1,10}", comparisonCount, movesCount);
                if (printArrays)
                    PrintList(quickList);
                Console.WriteLine();

                if (printArrays)
                    PrintList(quickList);
                Sort.Quick(quickList, out comparisonCount, out movesCount);
                Console.Write("Sorted list. \nQuick sorting. Comparisons count: {0,10}, Moves count: {1,10}", comparisonCount, movesCount);
                if (printArrays)
                    PrintList(quickList);
                Console.WriteLine();

                quickList.Reverse();
                if (printArrays)
                    PrintList(quickList);
                Sort.Quick(quickList, out comparisonCount, out movesCount);
                Console.Write("Reversed list. \nQuick sorting. Comparisons count: {0,10}, Moves count: {1,10}", comparisonCount, movesCount);
                if (printArrays)
                    PrintList(quickList);

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
