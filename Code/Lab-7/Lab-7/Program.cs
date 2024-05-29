using System;
using System.Linq;

namespace Lab_7
{
    static class Program
    {
        static public double calc_fun(double x)
        {
            return (x + 1) * Math.Sin(x);
        }

        static public double calc_fun2(double x)
        {
            return 0.35*(2.05 + 0.35*x)*Math.Sin(1.05 + 0.35*x);
        }

        static public double method_simpson(double a, double b, int n)
        {
            double h = (b - a) / n; //Обрахунок кроку

            double firstVal = calc_fun(a);
            double lastVal = calc_fun(b);

            double sumEve = 0; //Масив збереження суми парних індек. значень функ.
            double sumOdd = 0; //Масив збереження суми непарних індек. значень функ.

            for (int i = 1; i < n; i++)
            {
                double x_i = a + h * i;
                if (i % 2 == 0)
                {
                    sumEve += calc_fun(x_i);
                }
                else
                {
                    sumOdd += calc_fun(x_i);
                }
            }
            return (h / 3) * ((firstVal + lastVal) + 4 * sumOdd + 2 * sumEve); //Формула Сімпсона в метод. (1.9)
        }

        static public double method_gaus(double a, double b, int n)
        {
            double[] t = { -0.577350, 0.57735 }; //Табличні дані з метод.
            double[] c = { 1, 1 };

            double result = 0;

            for (int i = 0; i < n; i++) 
            {
                result += (c[i] * calc_fun2(t[i])); //Використана фор. №4
            }
            return result;
        }



        static void PrintSep()
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", 50)));
        }

        static void Main(string[] args)
        {
            PrintSep();
            Console.WriteLine("\tЛабораторна робота #7");
            Console.WriteLine("Виконав студент групи IC-31 Коваль Богдан");
            PrintSep();

            double a = 0.7;
            double b = 1.4;

            int n_simpson = 4; //Повинен бути парним та крат. 4

            double res_Simpson = method_simpson(a, b, n_simpson);

            int n_gaus = 2;

            double res_Gaus = method_gaus(a, b, n_gaus);


            Console.WriteLine($"Метод Сiмпсона (n = {n_simpson}): {res_Simpson}");

            PrintSep();

            Console.WriteLine($"Метод Гауса (n = {n_gaus}): {res_Gaus}");
        }


    }
}
