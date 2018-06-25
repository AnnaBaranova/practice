using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Task7
    {
        static void Main(string[] args)
        {
            int Count = 0;
            for (int i = 0; i < 256; i++)
            {
                char[] function = new char[8];             //функция
                string iTo2 = Convert.ToString(i, 2);      //Перевод в двоичную запись
                int numberOfNull = 8 - iTo2.Length;        //Количество нулей, которое нужно добавить в начало

                for (int j = 0; j < numberOfNull; j++)     
                    function[j] = '0';

                int index = 0;
                for (int j = numberOfNull; j < 8; j++)      //Заполнение оставшейся части вектора
                    function[j] = iTo2[index++];

                for (int j = 0; j < 4; j++)             //Проверка на немонотонность: функция не является монотонной, 
                {                                       //если по первая половина значений функции больше второй
                    if (function[j] > function[j + 4])
                    {
                        Count++;
                        Console.Write(function);
                        Console.WriteLine("\t" + CheckMon(function.ToString(), 8));
                        break;
                    }
                }
            }
            Console.WriteLine(Count);

            Console.ReadKey();
        }


        private static bool CheckMon(string func, int length)
        {
            length /= 2;
            int i = 0;
            for (i = 0; i < length; i++)
            {
                if (func[i] > func[i + length]) return false;
            }
            if (length != 1)
            {
                string s1 = func.Remove(func.Length / 2, func.Length / 2);
                string s2 = func.Remove(0, func.Length / 2);
                return (CheckMon(s1, length) && CheckMon(s2, length));
            }
            else return true;
        }
    }
}
