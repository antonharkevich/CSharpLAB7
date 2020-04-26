using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLAB7
{
    public class Checks
    {
        public static string CheckSingleInput()
        {
            string s = null;
            try
            {
                s = Console.ReadLine();
                if (s == String.Empty)
                {
                    return CheckSingleInput();
                }
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != '0' && s[i] != '1' && s[i] != '2' && s[i] != '3' && s[i] != '4' && s[i] != '5' && s[i] != '6' && s[i] != '7' && s[i] != '8' && s[i] != '9' && s[i] != '-')
                    {
                        WrongInputException ex = new WrongInputException();
                        throw ex;
                    }
                    else if (s[i] == '-' && i != 0)
                    {
                        WrongInputException ex = new WrongInputException();

                        throw ex;
                    }
                }
            }
            catch (WrongInputException e)
            {
                Console.WriteLine("{0}", e.Message);
                if (WrongInputException.NumberOfMistakes == 4)
                {
                    Environment.Exit(-1);
                }
                return CheckSingleInput();
            }
            return s;
        }

        public static string CheckSingleStringInput()
        {
            string s = null;

            s = Console.ReadLine();
            if (s == String.Empty)
            {
                return CheckSingleStringInput();
            }


            return s;
        }
        public static string CheckSingleDoubleInput()
        {
            string s = null;
            try
            {
                s = Console.ReadLine();
                if (s == String.Empty)
                {
                    return CheckSingleDoubleInput();
                }
                int numberOfOccurrences = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != '0' && s[i] != '1' && s[i] != '2' && s[i] != '3' && s[i] != '4' && s[i] != '5' && s[i] != '6' && s[i] != '7' && s[i] != '8' && s[i] != '9' && s[i] != '-' && s[i] != ',')
                    {
                        WrongInputException ex = new WrongInputException();
                        throw ex;
                    }
                    else if (s[i] == '-' && i != 0)
                    {
                        WrongInputException ex = new WrongInputException();

                        throw ex;
                    }
                    else if (s[i] == ',')
                    {
                        numberOfOccurrences++;
                        if (numberOfOccurrences >= 2)
                        {
                            WrongInputException ex = new WrongInputException();

                            throw ex;
                        }
                    }
                }
            }
            catch (WrongInputException e)
            {
                Console.WriteLine("{0}", e.Message);
                if (WrongInputException.NumberOfMistakes == 4)
                {
                    Environment.Exit(-1);
                }
                return CheckSingleDoubleInput();
            }
            return s;
        }

        public static void CheckMultipleInput(int[,] c, ref int i, ref int j)
        {
            string s = null;
            try
            {
                s = Console.ReadLine();
                if (s == String.Empty)
                {
                    CheckMultipleInput(c, ref i, ref j);
                    return;
                }
                for (int k = 0; k < s.Length; k++)
                {
                    if (s[k] != '0' && s[k] != '1' && s[k] != '2' && s[k] != '3' && s[k] != '4' && s[k] != '5' && s[k] != '6' && s[k] != '7' && s[k] != '8' && s[k] != '9' && s[k] != '-' && s[k] != ' ')
                    {
                        WrongInputException ex = new WrongInputException();
                        throw ex;
                    }
                    else if (s[k] == '-' && (k != 0 && s[k - 1] != ' '))
                    {
                        WrongInputException ex = new WrongInputException();

                        throw ex;
                    }
                }
                char[] ForTheNumber = new char[100];
                int helpArgument = 0;

                for (int k = 0; k < s.Length; k++)
                {

                    if (s[k] != ' ' && (k == 0 || s[k - 1] == ' '))
                    {
                        while (k < s.Length && s[k] != ' ')
                        {
                            ForTheNumber[helpArgument] = s[k];
                            helpArgument++;
                            k++;
                        }
                        c[i, j] = 0;
                        int discharge = 1;
                        for (int ind = helpArgument - 1; ind >= 0; ind--)
                        {
                            if (ind == 0 && ForTheNumber[ind] == '-')
                            {
                                c[i, j] *= -1;
                                continue;
                            }
                            c[i, j] += (ForTheNumber[ind] - '0') * discharge;
                            discharge *= 10;
                        }
                        helpArgument = 0;
                        discharge = 0;
                        j++;
                        if (j >= c.GetLength(1))
                        {
                            j = 0;
                            i++;
                        }
                        if (i >= c.GetLength(0))
                        {
                            return;
                        }
                    }
                }
            }
            catch (WrongInputException e)
            {
                Console.WriteLine("{0}", e.Message);
                if (WrongInputException.NumberOfMistakes == 4)
                {
                    Environment.Exit(-1);
                }
                CheckMultipleInput(c, ref i, ref j);
            }

        }

    }
}
