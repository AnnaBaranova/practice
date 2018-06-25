using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Task5
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер матрицы");
            int n = InputNatNumber();
            int[,] matrix = FormArr(n);
            PrintArr(matrix);

            Console.WriteLine("Введите строку для удаления: ");
            int line = NContains(n); 
            Console.WriteLine("Введите столбец для удаления: ");
            int column = NContains(n);

            int[,] temp = DeleteLine(line, matrix, n);

            int[,] temp2 = DeleteColumn(column, temp, n);

            PrintArr(temp2);
            Console.ReadKey();
        }

        #region Deleting
        static int[,] DeleteLine(int line, int[,] matrix, int n)
        {
            int[,] temp = new int[n - 1, n];

            for (int i = 0; i < line - 1; i++)
            {
                for (int j = 0; j < n; j++)
                    temp[i, j] = matrix[i, j];
            }

            for (int i = line - 1; i < n - 1; i++)
            {
                for (int j = 0; j < n; j++)
                    temp[i, j] = matrix[i + 1, j];
            }

            return temp;
        }

        static int[,] DeleteColumn(int column, int[,] matrix, int n)
        {
            int[,] temp = new int[n - 1, n - 1];

            for (int i = 0; i < n - 1; i++) 
            {
                for (int j = 0; j < column - 1; j++)
                    temp[i, j] = matrix[i, j];
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = column - 1; j < n - 1; j++)
                    temp[i, j] = matrix[i, j + 1];
            }
            return temp;
        }
        #endregion

        public static int InputNatNumber()
        {
            bool ok;
            int n;
            do
            {
                string buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out n);
                if ((!ok) || (n <= 0))
                    Console.WriteLine("Натуральное число введено неверно. Повторите ввод.");
            } while ((!ok) || (n <= 0));
            return n;
        }

        static int NContains(int n)
        {
            bool ok;
            int number;
            do
            {
                string buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out number);
                if ((!ok) || (number <= 0) || (number > n))
                    Console.WriteLine("Введенное число не удовлетворяет условию. Повторите ввод.");
            } while ((!ok) || (number <= 0) || (number > n));
            return number;
        }

        static int[,] FormArr(int n)
        {
            Random rnd = new Random();
            int[,] Matrix = new int[n, n];
            for (int x = 0; x < n; x++) 
            {
                for (int y = 0; y < n; y++)
                    Matrix[x, y] = rnd.Next(-100, 100);
            }
            return Matrix;
        }

        static void PrintArr(int[,] arr)
        //Вывод двумерного массива
        {
            if (arr.Length == 0) Console.WriteLine("Массив пуст");
            else
            {
                Console.WriteLine("\nДвумерный массив: ");
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                        Console.Write("{0,4}", arr[i, j]);
                    Console.WriteLine();
                }
            }
        }
    }
}
