using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Task3
    {
        static void Main(string[] args)
        {
            string buf = String.Empty;
            double x, y, u;

            Console.WriteLine("Введите значение x. \n x = ");
            x = InputNumber();
            Console.WriteLine("\nВведите значение y. \n y = ");
            y = InputNumber();

            bool contain = AreaContains(x, y);
            if (contain == true)
            {
                u = Math.Sqrt(Math.Abs(x * x - 1));
                Console.WriteLine(" true ");
            }
            else
            {
                u = x + y;
                Console.WriteLine(" false ");
            }
            Console.WriteLine("u = " + u);
            Console.ReadKey();
        }

        static bool AreaContains(double x, double y)
        {
            if ((y >= x) && (y >= (-1 * x)) && ((x * x + y * y) <= 1))
                return true;
            else return false;
        }

        public static double InputNumber()
        {
            bool ok;
            double n;
            do
            {
                string buf = Console.ReadLine();
                ok = Double.TryParse(buf, out n);
                if (!ok)
                    Console.WriteLine("Число введено неверно. Повторите ввод.");
            } while (!ok);
            return n;
        }

    }
}
