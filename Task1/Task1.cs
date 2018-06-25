using System;
using System.Collections.Generic;

namespace Task1
{
    class Task1
    {
        static void Main(string[] args)
        {
            int N = Int32.Parse(Console.ReadLine());    //Вводим количество девушек - натуральное число до 1000

            Queue<int> girls = new Queue<int>(N);
            for (int i = 0; i < N; i++)         //Создаем и
                girls.Enqueue(i);               // заполняем очередь

            char color = 'B';
            char[] res = new char[N];
            while (true)
            {
                res[girls.Dequeue()] = color;           //Вставляем в конечную строку цвет платья на место с индексом вышедшей на сцену девушки
                color = (char)('B' + 'R' - color);      //учитывая смену цветов (синий-красный)

                if (girls.Count != 0)
                    girls.Enqueue(girls.Dequeue());             //Следующую девушку отправляем в конец цепочки  
                else break;
            }
            Console.WriteLine(res); 
        }
    }
}
