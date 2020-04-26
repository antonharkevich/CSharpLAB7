using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLAB7
{
    public class WrongInputException: ApplicationException
    {
        private static int  numberOfMistakes=0;
        public static int NumberOfMistakes => numberOfMistakes;
        private string messageDetails = String.Empty;
        public WrongInputException()
        {
            numberOfMistakes++;
            if (numberOfMistakes == 1)
            {
                messageDetails ="Хватит вводить ерунду";
            }
            else if (numberOfMistakes == 2)
            {
                messageDetails = "Пожалуйста, хватит";
            }
            else if (numberOfMistakes == 3)
            {
                messageDetails = "Последнее китайское предупреждение";
            }
            else if (numberOfMistakes == 4)
            {
                messageDetails = "А давайте-ка мы вас удалим!";
            }
        }
        public override string Message => $"Input Error Message: {messageDetails}";
    }
}
