using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    class Polynom
    {
        public Variable Root { get; set; }

        public Polynom(Variable root)
        {
            Root = root;
        }
        public Polynom()
        {
            Root = null;
        }

        public void Add(Variable variable)
        {
            if (Root == null)
            {
                Root = new Variable(variable.Coefficient, variable.Power);
                //Root.Coefficient = variable.Coefficient;
                //Root.Power = variable.Power;
                return;
            }

            var cur = Root;
            Variable prev = null;

            while (cur != null)
            {
                if (variable.Power > cur.Power)
                {
                    Variable var = new Variable(variable.Coefficient, variable.Power);
                    var.next = cur;
                    if (prev != null)
                    { prev.next = var; }
                    else
                    { Root = var; }

                    return;
                }
                else if (variable.Power == cur.Power)
                {
                    cur.Coefficient += variable.Coefficient;
                    if (cur.Coefficient == 0)
                    {
                        if (prev != null)
                            prev.next = cur.next;
                        else
                            Root = Root.next;
                    }

                    return;
                }
                prev = cur;
                cur = cur.next;
            }

            Variable var1 = new Variable(variable.Coefficient, variable.Power);
            prev.next = var1;
        }

        public static Polynom operator +(Polynom first, Polynom second)
        {
            var answ = new Polynom();
            MoveItems(first, answ);
            MoveItems(second, answ);

            return answ;
        }

        public static void MoveItems(Polynom from, Polynom to)
        {
            var cur = from.Root;
            Variable next = null;
            if (cur != null) next = cur.next;
            to.Add(cur);

            while (next != null)
            {
                cur = next;
                next = next.next;
                to.Add(cur);
            }
        }

        public override string ToString()
        {
            return Root.ToString() + " + ...";
        }
    }

    class Variable
    {
        public int Coefficient { get; set; }
        public int Power { get; set; }
        public Variable next { get; set; }

        public Variable(int coefficient, int power)
        {
            Coefficient = coefficient;
            Power = power;
            next = null;
        }
        public Variable(string coefficient, string power)
        {
            Coefficient = Int32.Parse(coefficient);
            Power = Int32.Parse(power);
            next = null;
        }
        public override string ToString()
        {
            return "(" + Coefficient + "x^" + Power + ")";
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                var firstPol = ReadFile("PowerOne.txt", "CoefOne.txt");
                var secPol = ReadFile("PowerTwo.txt", "CoefTwo.txt");

                Console.WriteLine(firstPol.ToString());
                Console.WriteLine(secPol.ToString());

                var sum = firstPol + secPol;

                WriteFile("output.txt", sum);
            }
            catch (Exception e)
            {
                WriteEx("output.txt", e);
            }
        }

        static Polynom ReadFile(string pathPow, string pathCoef)
        {
            var readerPow = new StreamReader(pathPow);
            var readerCoef = new StreamReader(pathCoef);

            var curPow = readerPow.ReadLine();
            var curCoef = readerCoef.ReadLine();
            var polynom = new Polynom();

            while (!string.IsNullOrEmpty(curPow) || !string.IsNullOrEmpty(curCoef))
            {
                polynom.Add(new Variable(curCoef, curPow));
                curPow = readerPow.ReadLine();
                curCoef = readerCoef.ReadLine();
            }

            readerPow.Close();
            readerCoef.Close();

            return polynom;
        }
        static void WriteFile(string path, Polynom poly)
        {
            var writer = new StreamWriter(path);
            var root = poly.Root;

            while (root != null)
            {
                writer.WriteLine(root.Power + " " + root.Coefficient);
                root = root.next;
            }

            writer.Close();
        }
        static void WriteEx(string path, Exception e)
        {
            var writer = new StreamWriter(path);
            writer.WriteLine(e.Message);
            writer.Close();
        }
    }
}
