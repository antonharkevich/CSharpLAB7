using System;

namespace ConsoleAppLAB7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите начальное число");
            string str = Console.ReadLine();
            Rational initial = new Rational(str);
            while (true)
            {
                Console.WriteLine("Чтобы вывести число на консоль введите 1");
                Console.WriteLine("Чтобы прибавить другое введите 2");
                Console.WriteLine("Чтобы отнять другое число введите 3");
                Console.WriteLine("Чтобы умножить на другое число введите 4");
                Console.WriteLine("Чтобы разделить на другое число введите 5");
                Console.WriteLine("Чтобы сравнить два числа введите 6");
                Console.WriteLine("Для выхода введите 0");
                int a = Convert.ToInt32(Checks.CheckSingleInput());
                switch (a)
                {
                    case 1:
                        Console.WriteLine("Чтобы вывести число в обычным виде введите 1");
                        Console.WriteLine("Чтобы вывести число в математическом виде введите 2");
                        Console.WriteLine("Чтобы вывести число в виде целого числа если это возможно введите 3");
                        Console.WriteLine("Чтобы вывести число в виде double введите 4");
                        Console.WriteLine("Чтобы вывести число в виде int введите 5");
                        int b = Convert.ToInt32(Checks.CheckSingleInput());
                        switch (b)
                        {
                            case 1:
                                Console.WriteLine("{0}",initial.ToString());
                                break;
                            case 2:
                                Console.WriteLine("{0}", initial.ToMathString());
                                break;
                            case 3:
                                Console.WriteLine("{0}", initial.ToOneNumberIfPossible());
                                break;
                            case 4:
                                Console.WriteLine("{0}", (double)initial);
                                break;
                            case 5:
                                Console.WriteLine("{0}", (int)initial);
                                break;
                            default: break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Введите число для прибавления");
                        str = Console.ReadLine();
                        Rational following2 = new Rational(str);
                        initial += following2;
                        break;
                    case 3:
                        Console.WriteLine("Введите число для убавления");
                        str = Console.ReadLine();
                        Rational following3 = new Rational(str);
                        initial -= following3;
                        break;
                    case 4:
                        Console.WriteLine("Введите число для умножения");
                        str = Console.ReadLine();
                        Rational following4 = new Rational(str);
                        initial *= following4;
                        break;
                    case 5:
                        Console.WriteLine("Введите число для деления");
                        str = Console.ReadLine();
                        Rational following5 = new Rational(str);
                        initial /= following5;
                        break;
                    case 6:
                        Console.WriteLine("Введите число для сравнения");
                        str = Console.ReadLine();
                        Rational following6 = new Rational(str);
                        if (initial < following6)
                        {
                            Console.WriteLine("Введенное число больше данного");
                        }
                        else if(initial > following6)
                        {
                            Console.WriteLine("Введенное число меньше данного");
                        }
                        else
                        {
                            Console.WriteLine("Введенное число равно данному");
                        }
                        break;
                    case 0: return;
                    default: break;
                }
            }
        }
    }
}
