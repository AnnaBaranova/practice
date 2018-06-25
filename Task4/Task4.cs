using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Task4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите E.");
            double E = InputPositiveNumber();
            int max = 2000;
            double sum = 0, ACur = 0.5; 
            int i = 1;

            while ((Math.Abs(ACur) > E)&&(i < max))
            {
                ACur = (double)1 / (i * (i + 1));
                sum = sum + ACur;
                i++;
                Console.WriteLine(i);
            }
            sum = sum - ACur;

            Console.WriteLine("\nSumma = " + sum + " , при E = " + E);
            Console.ReadKey();
        }

        public static double InputPositiveNumber()
        {
            bool ok;
            double n;
            do
            {
                string buf = Console.ReadLine();
                ok = Double.TryParse(buf, out n);
                if ((!ok) || (n <= 0))
                    Console.WriteLine("Число введено неверно. Повторите ввод.");
            } while ((!ok) || (n <= 0));
            return n;
        }
    }
}
