using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    class MyList
    {
        public int value;
        public MyList Next;

        public MyList()
        {   }

        public MyList(int Value)
        {
            value = Value;
        }
    }

    class Program
    {
        static void CreateList(MyList lastElem, int Count)
        {
            if (Count > 0)
            {
                MyList newElem = new MyList(Count);
                lastElem.Next = newElem;
                CreateList(newElem, Count - 1);
            }
        }

        static void PrintList(MyList elem)
        {
            Console.WriteLine();
            while (elem != null)
            {
                Console.WriteLine(elem.value);
                elem = elem.Next;
            }
            Console.WriteLine();
        }
        static MyList Search(MyList elem, int findingValue)
        {
            if (elem == null)
                return null;
            else
            {
                if (elem.value == findingValue)
                    return elem;
                else
                    return Search(elem.Next, findingValue);
            }
        }
        static bool Remove(MyList elem, int removingValue)
        {
            if (elem.Next == null)
                return false;
            else
            {
                if (elem.Next.value == removingValue)
                {
                    elem.Next = elem.Next.Next;
                    return true;
                }
                else
                    return Remove(elem.Next, removingValue);
            }
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
        static void Main()
        {
            Console.Write("Введите размер списка: \n");
            int count = InputNatNumber();

            MyList list = new MyList(count);
            CreateList(list, count - 1);
            Console.Write("\nЛинейный список: ");
            PrintList(list);

            bool isExit = false;
            while (!isExit)
            {
                Console.Write("\n1. Удалить элемент из списка" +
                    "\n2. Найти элемент" +
                    "\n3. Печать списка" +
                    "\n4. Добавить в начало элемент" +
                    "\n5. Выход. ");
                Console.WriteLine("\nВыберите действие...");
                int userChoise = InputNatNumber();
                switch (userChoise)
                {
                    case 5:
                        isExit = true;
                        break;
                    case 1:
                        Console.WriteLine("Введите значение элемента для удаления: ");
                        int removingValue = InputNatNumber();

                        if (list.value == removingValue) //проверка первого элемента
                        {
                            list = list.Next;
                            Console.WriteLine("Элемент удален из списка.");
                        }
                        else
                        {
                            if (!Remove(list, removingValue))
                                Console.WriteLine("Элемента не существует");
                            else
                            {
                                Console.WriteLine("Элемент удален.");
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Введите значение элемента для поиска: ");
                        int findingValue = InputNatNumber();
                        MyList foundElem = Search(list, findingValue);
                        if (foundElem != null)
                        {
                            Console.WriteLine("Найденный элемент: " + foundElem.value);
                            Console.Write("Следующие элементы: ");
                            PrintList(foundElem);
                        }
                        else
                            Console.WriteLine("Элемент не найден.");
                        break;
                    case 3:
                        PrintList(list);
                        break;
                    case 4:
                        MyList newElem = new MyList();
                        Console.WriteLine("Введите значение нового элемента: ");
                        newElem.value = InputNatNumber();
                        newElem.Next = list;
                        list = newElem;
                        break;
                }
            }
        }
    }
}
