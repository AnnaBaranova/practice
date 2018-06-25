using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task11
{
    class Task11
    {
        static string Encrypt(string inputB) //дешифрование
        {
            string result = inputB[0].ToString();
            for (int i = 1; i < inputB.Length; i++)
            {
                    if (inputB[i] == '1') result += result[i - 1];
                    else 
                        if (result[i - 1] == '0') result += "1";
                        else result += "0";
            }
            return result;
        }

        static string Decrypt(string inputA)
        {
            string outputB = inputA[0].ToString();
            for (int i = 1; i < inputA.Length; i++) //шифрование
            {
                if (inputA[i] == inputA[i - 1])
                    outputB += '1';
                else outputB += '0';
            }
            return outputB;
        }

        static string ReadString()
        {
            string regex = "^([0-1]{1,})$";
            string str;
            do
            {
                str = Console.ReadLine();
                if (!Regex.IsMatch(str, regex))
                    Console.WriteLine("Строка введена неверно. Повторите ввод.");
            } while (!Regex.IsMatch(str, regex));
            return str;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите последовательность из нулей и единиц");

            string inputA = ReadString();

            string outputB = Decrypt(inputA);
            Console.WriteLine("Зашифрованная последовательность: " + outputB);

            string encryptedB = Encrypt(outputB);
            Console.WriteLine("Расшифрованная последовательность: " + encryptedB);

            Console.ReadKey();
        }
    }
}
