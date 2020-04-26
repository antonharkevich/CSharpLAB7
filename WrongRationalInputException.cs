using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLAB7
{
    public class WrongRationalInputException : ApplicationException
    {
       
        private string messageDetails = String.Empty;
        public WrongRationalInputException()
        {
            messageDetails = "Вы пытались сделать знаменатель равным нулю";
        }
        public WrongRationalInputException(string str)
        {
            messageDetails = str;
        }
        public override string Message => $"Rational input Error Message: {messageDetails}";
    }
}
