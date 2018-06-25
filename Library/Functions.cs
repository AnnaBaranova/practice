using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Functions
    {
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
            } while ((!ok)||(n <= 0));
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
    }
}
