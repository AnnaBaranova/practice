using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Task6
    {
        private static double a1;
        private static double a2;
        private static double a3;

        static void Main(string[] args)
        {
            Console.WriteLine("Введите а1");
            a1 = InputNumber();
            Console.WriteLine("Введите а2");
            a2 = InputNumber();
            Console.WriteLine("Введите а3");
            a3 = InputNumber();

            Console.WriteLine("Введите M");
            double M = InputNumber();

            Console.WriteLine("Введите количество элементов - N");
            int N = InputNatNumber();

            string conseq = a1.ToString() + "  " + a2.ToString() + "  " + a3.ToString();
            int i;
            for (i = 4; i <= N; i++) 
            {
                if (Conseq(i) == 0) break;
                conseq = conseq + "  " + Math.Round(Conseq(i), 3).ToString();
                if (Conseq(i) > M)
                {
                    Console.WriteLine("Причина останова - очередной член пос-ти больше M");
                    break;
                }
            }

            if (i == N + 1)
                Console.WriteLine("Причина останова - посчитана пос-ть всех N элементов");
            Console.WriteLine("Последовательность = " + conseq);

            Console.ReadKey();
        }

        public static double InputNumber()
        {
            bool ok;
            double n;
            do
            {
                string buf = Console.ReadLine();
                ok = Double.TryParse(buf, out n);
                if ((!ok) || (n == 0))
                    Console.WriteLine("Число введено неверно. Повторите ввод.");
            } while ((!ok) || (n == 0));
            return n;
        }

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

        static double Conseq(int k)
        {
            if (k == 1)
                return a1;

            if (k == 2)
                return a2;

            if (k == 3)
                return a3;
            double ak = (Conseq(k - 2) / Conseq(k - 1)) + Math.Abs(Conseq(k - 3));
            return ak;
        }
    }
}
