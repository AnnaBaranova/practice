using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Task2
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');

            int N = int.Parse(str[0]);     //Ввод количества подарков
            int K = int.Parse(str[1]);     //Ввод минимального количества конфет

            int[] a = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();  //Количество конфет в подарке
            int sum = 0;

            for (int i = 0; i < N; i++)
                sum += a[i];
            if (sum >= 2 * K)
            {
                int[] curCount = new int[K];
                int[] prevCount = new int[K];
                int[] temp = new int[K];
                curCount[0] = 1;

                for (int i = 0; i < N; i++)
                {
                    temp = curCount;
                    curCount = prevCount;
                    prevCount = temp;

                    for (int s = 0; s < K; s++)
                    {
                        curCount[s] = prevCount[s];
                        if (s >= a[i])
                            curCount[s] += prevCount[s - a[i]];
                    }
                }
                sum = 0;
                for (int i = 0; i < K; i++)
                {
                    sum += curCount[i];
                }
                Console.WriteLine(sum * 2);
            }
            else Console.WriteLine(0);

            Console.ReadKey();
        }
    }
}
