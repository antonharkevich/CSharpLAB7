using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLAB7
{






    class Rational : IComparable<Rational>, IEquatable<Rational>
    {
        public static int NOD(int a, int b)
        {
            while (a > 0 && b > 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }

            }
            return a + b;
        }

        public Rational()
        {
            a = 0;
            b = 1;
        }

        public Rational(int numerator, int denominator)
        {
            try
            {
                if (denominator == 0)
                {
                    string s = "Вы ввели знаменатель равный нулю, нам придётся обнулить число во избежание ошибок";
                    WrongRationalInputException ex = new WrongRationalInputException(s);

                    throw ex;
                }
                if (numerator == 0)
                {
                    denominator = 1;
                }
                int j = 1;
                if (numerator < 0 && denominator < 0)
                {
                    numerator *= -1; ;
                    denominator *= -1;
                }
                if (numerator < 0 && denominator > 0)
                {
                    numerator *= -1;
                    j *= -1;
                }
                if (numerator > 0 && denominator < 0)
                {
                    denominator *= -1;
                    j *= -1;
                }
                int c = NOD(numerator, denominator);
                a = numerator / c * j;
                b = denominator / c;
            }
            catch (WrongRationalInputException e)
            {
                a = 0;
                b = 1;
                Console.WriteLine("{0}", e.Message);
            }


        }

        private int a;
        private int b;

        public int Denominator()
        {
            return b;
        }

        public int Numerator()
        {
            return a;
        }
        
        public static Rational operator -(Rational a, Rational b)
        {
            int c = a.Denominator() * b.Denominator();
            int d = a.Numerator() * c / a.Denominator();
            int e = b.Numerator() * c / b.Denominator();
            return new Rational(d - e, c);

        }

        public static Rational operator /(Rational a, Rational b)
        {
            try
            {
                if (b.Numerator() == 0)
                {
                    string s = "Деление на 0 запрщено, нам придётся обнулить число во избежание ошибок";
                    WrongRationalInputException ex = new WrongRationalInputException(s);

                    throw ex;
                }
                int c = a.Numerator() * b.Denominator();
                int d = a.Denominator() * b.Numerator();
                return new Rational(c, d);
            }

            catch (WrongRationalInputException e)
            {

                Console.WriteLine("{0}", e.Message);
                return new Rational(0, 1);
            }
        }



        public static Rational operator +(Rational a, Rational b)
        {
            int c = a.Denominator() * b.Denominator();
            int d = a.Numerator() * b.Denominator();
            int e = b.Numerator() * a.Denominator();
            return new Rational(d + e, c);

        }





        public static Rational operator *(Rational a, Rational b)
        {
            int c = a.Numerator() * b.Numerator();
            int d = a.Denominator() * b.Denominator();
            return new Rational(c, d);
        }


        public int CompareTo(Rational other)
        {
            int c = this.Denominator() * other.Denominator();
            if ((this.Numerator() * c / this.Denominator()) < (other.Numerator() * c / other.Denominator()))
            {
                return -1;
            }
            else if ((this.Numerator() * c / this.Denominator()) > (other.Numerator() * c / other.Denominator()))
            {
                return 1;
            }
            else return 0;
        }

        public override string ToString()
        {
            return $"{a}/{b}";
        }
        public string ToMathString()
        {
            return $"{a}:{b}";
        }
        public string ToOneNumberIfPossible()
        {
            if (b == 1)
            {
                return $"{a}";
            }
            else
            {
                return "Denominator!=1, impossible";
            }
        }
        public bool Equals(Rational other) => (this.Numerator() == other.Numerator() && this.Denominator() == other.Denominator());
        public static bool operator <(Rational pi, Rational p2) => pi.CompareTo(p2) < 0;
        public static bool operator >(Rational pi, Rational p2) => pi.CompareTo(p2) > 0;
        public static bool operator <=(Rational pi, Rational p2) => pi.CompareTo(p2) <= 0;
        public static bool operator >=(Rational pi, Rational p2) => pi.CompareTo(p2) >= 0;
        public static implicit operator int(Rational s)
        {
            return (int)(s.a / s.b);
        }
        public static implicit operator double(Rational s)
        {
            return ((double)s.a / (double)s.b);
        }

        public Rational(string s)
        {
            try
            {
                if (s == "")
                {
                    
                    string str = "Вы ввели что-то не то, нам придётся обнулить число во избежание ошибок";
                    WrongRationalInputException ex = new WrongRationalInputException(str);

                    throw ex;
                }
                int i = 0;
                while (i < s.Length && s[i] != '/' && s[i] != ':')
                {
                    if (s[i] != '-' && s[i] != '0' && s[i] != '1' && s[i] != '2' && s[i] != '3' && s[i] != '4' && s[i] != '5' && s[i] != '6' && s[i] != '7' && s[i] != '8' && s[i] != '9')
                    {
                        
                        
                        string str = "Вы ввели что-то не то, нам придётся обнулить число во избежание ошибок";
                        WrongRationalInputException ex = new WrongRationalInputException(str);

                        throw ex;

                    }
                    else if (s[i] == '-' && i != 0)
                    {
                        
                        
                        string str = "Вы ввели что-то не то, нам придётся обнулить число во избежание ошибок";
                        WrongRationalInputException ex = new WrongRationalInputException(str);

                        throw ex;
                    }
                    i++;

                }
                int z = i;
                if (i >= s.Length)
                {
                    a = Convert.ToInt32(s);
                    b = 1;
                    return;
                }
                else if (s[i] == ':' || s[i] == '/')
                {
                    i++;
                    while (i < s.Length)
                    {
                        if (s[i] != '-' && s[i] != '0' && s[i] != '1' && s[i] != '2' && s[i] != '3' && s[i] != '4' && s[i] != '5' && s[i] != '6' && s[i] != '7' && s[i] != '8' && s[i] != '9')
                        {
                          
                            
                            string str = "Вы ввели что-то не то, нам придётся обнулить число во избежание ошибок";
                            WrongRationalInputException ex = new WrongRationalInputException(str);

                            throw ex;

                        }
                        else if (s[i] == '-' && i != z)
                        {
                            
                           
                            string str = "Вы ввели что-то не то, нам придётся обнулить число во избежание ошибок";
                            WrongRationalInputException ex = new WrongRationalInputException(str);

                            throw ex;
                        }
                        i++;

                    }
                }
                if (s[z] == ':')
                {
                    string[] helper = s.Split(':');
                    a = Convert.ToInt32(helper[0]);
                    b = Convert.ToInt32(helper[1]);

                }
                else if (s[z] == '/')
                {
                    string[] helper = s.Split('/');
                    a = Convert.ToInt32(helper[0]);
                    b = Convert.ToInt32(helper[1]);

                }
            }
            catch (WrongRationalInputException e)
            {

                Console.WriteLine("{0}", e.Message);
                Console.WriteLine("Правильный формат ввода: a/b или a:b");
                a = 0;
                b = 1;
            }
        }
    };
}
















    












        