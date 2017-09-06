using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание10
{
    public class Point
    {
        public double info;//информационное поле

        public Point next;//адресное поле 1

        public Point last;//адресное поле 2

        public Point()
        {
            info = 0;
            next = null;
            last = null;
        }

        public Point(double i)
        {
            info = i;
            next = null;
            last = null;
        }

        public override string ToString()
        {
            return info + " ";
        }
    }

    class Program
    {
        public static double ImputDouble()//Ввод вещественных чисел
        {
            bool rightValue;
            double value;

            do
            {
                string userImput = Console.ReadLine();
                rightValue = double.TryParse(userImput, out value);
                if (!rightValue) Console.Write(@"Ожидалось число. Повторите ввод - ");
            }
            while (!rightValue);

            return value;
        }

        public static int ImputNat()//Ввод вещественных чисел
        {
            bool rightValue;
            int value;

            do
            {
                string userImput = Console.ReadLine();
                rightValue = Int32.TryParse(userImput, out value);
                if (value < 1) rightValue = false;
                if (!rightValue) Console.Write(@"Ожидалось число. Повторите ввод - ");
            }
            while (!rightValue);

            return value;
        }

        static void Main(string[] args)
        {
            Console.Write(@"Введите кол-во переменных: ");//Ввод кол-ва
            int n = ImputNat();

            Console.WriteLine("Введите переменные: ");//Ввод эл-ов
            Point head = new Point(ImputDouble());
            Point p;
            Point q = head; 
            double a;

            for (int i = 0; i < n - 1; i++)
            {
                a = ImputDouble();
                p = new Point(a);
                q.next = p;
                p.last = q;
                q = p;               
            }

            Console.WriteLine("Ваш список: ");//Печать списка
            p = head;

            while (p != null)
            {
                Console.Write("{0} ", p);
                p = p.next;
            }
            Console.WriteLine();

            double result = 1;//Вычисленние произведения
            p = head;

            for (int i = 1; i < n - 1; i++)
            {
                result = result * (p.info + p.next.info + 2 * q.info);
                p = p.next;
                q = q.last;
            }


            Console.WriteLine("Результат вычислений: " + result);//Печать рез-ов
            Console.ReadLine();
        }
    }
}
