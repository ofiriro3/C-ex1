using System;

namespace B17_Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter 8 digits number");
            string inputNumber = GetNumberWithEightDigits();
            char biggestDigit = BiggestOrSmallestDigitInNum(inputNumber, 1); //1 for bigger
            char smallestDigit = BiggestOrSmallestDigitInNum(inputNumber, -1); //-1 for smallest
            int biggerThanFirstDigit = CountHowManyDigitsBiggerOrSmallerThanFirstDigit(inputNumber, 1);
            int smallerThanFirstDigit = CountHowManyDigitsBiggerOrSmallerThanFirstDigit(inputNumber, -1);
            string msg = string.Format(
@"The biggest digit in the number is {0}
The smallest digit in the number is {1}
There are {2} digits that are bigger than the first digit
There are {3} digits that are smaller than the first digit", biggestDigit, smallestDigit, biggerThanFirstDigit,
                                           smallerThanFirstDigit);

            Console.WriteLine(msg);
            Console.WriteLine("Please press 'Enter' to exit");
            Console.ReadLine();
        }

        private static string GetNumberWithEightDigits()
        {
            bool isNotAvalidNumber = true;
            string inputFromUser = " ";
            int theNumberTheInputRespresent;

            while (isNotAvalidNumber)
            {
                inputFromUser = Console.ReadLine();
                bool isNumber = int.TryParse(inputFromUser, out theNumberTheInputRespresent);
                if (isNumber && inputFromUser.Length == 8)
                {
                    break;
                }

                Console.WriteLine("Invalid Input, please enter 8 digits number");
            }

            return inputFromUser;
        }

        public static char BiggestOrSmallestDigitInNum(string i_number, int biggerOrSmaller)
        {
            char BiggestOrSmallestDigit = i_number[i_number.Length - 1];
            int indexOfTheNumber = 0;

            for (int i = i_number.Length - 2; i >= 0; i--)
            {
                if (MyCompareTo(i_number[i], BiggestOrSmallestDigit) == biggerOrSmaller)
                {
                    indexOfTheNumber = i;
                    BiggestOrSmallestDigit = i_number[i];
                }

            }

            return BiggestOrSmallestDigit;
        }

        public static int CountHowManyDigitsBiggerOrSmallerThanFirstDigit(string i_number, int biggerOrSmaller)
        {
            char firstDigit = i_number[i_number.Length - 1];
            int counter = 0;

            for (int i = i_number.Length -2 ; i >= 0; i--)
            {
                if (MyCompareTo(i_number[i], firstDigit) == biggerOrSmaller)
                {
                    counter++;
                }
            }

            return counter;
        }


        public static int MyCompareTo(char io_letter1, char io_letter2)
        {
            int returnValue = 0;

            if (io_letter1 > io_letter2)
            {
                returnValue = 1;
            }
            else if (io_letter2 > io_letter1)
            {
                returnValue = -1;
            }

            return returnValue;
        }
    }


}
