using System;
using System.Collections.Generic;
using System.Text;
using Ex01 = B17_Ex01_1.Program;

namespace B17_Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter 8 digits number");
            string inputNumber = GetNumbetWithEightDigits();
            char biggestDigit = BiggestOrSmallestDigitInNum(inputNumber, 1);
            char smallestDigit = BiggestOrSmallestDigitInNum(inputNumber, -1);
            int biggerThanFirstDigit = CountHowManyDigitsBiggerOrSmallerThanFirstDigit(inputNumber, 1);
            int smallerThanFirstDigit = CountHowManyDigitsBiggerOrSmallerThanFirstDigit(inputNumber, -1);
            string msg = string.Format(
@"The biggest digit in the number is {0}
The smallest digit in the number is {1}
There are {2} digits that are bigger than the first digit
There are {3} digits that are smaller than the first digit",biggestDigit, smallestDigit, biggerThanFirstDigit,
                                           smallerThanFirstDigit);
            Console.WriteLine(msg);
            Console.WriteLine("Please press 'Enter' to exit");
            Console.ReadLine();
            
            
        }

        private static string GetNumbetWithEightDigits()
        {
            bool isNotAvalidNumber = true;
            string inputFromUser = " ";
            int theNumberTheInputRespresent;
            while (isNotAvalidNumber)
            {
                inputFromUser = Console.ReadLine();
                bool isNumber = int.TryParse(inputFromUser, out theNumberTheInputRespresent);

                if(isNumber && inputFromUser.Length == 8)
                {
                    break;
                }

                Console.WriteLine("Invalid Input, please enter 8 digits number");
            }

            return inputFromUser;
        }

        public static char BiggestOrSmallestDigitInNum(string i_number , int biggerOrSmaller)
        {
            char BiggestOrSmallestDigit = i_number[0];
            int indexOfTheNumber = 0;

            for (int i = 1; i < i_number.Length ; i++) 
            {
                if (Ex01.MyCompareTo(i_number[i], BiggestOrSmallestDigit) == biggerOrSmaller)
                {
                    indexOfTheNumber = i;
                    BiggestOrSmallestDigit = i_number[i];
                }
                
            }

            return BiggestOrSmallestDigit;
        }

        public static int CountHowManyDigitsBiggerOrSmallerThanFirstDigit(string i_number ,int biggerOrSmaller)
        {
            char firstDigit = i_number[0];
            int counter = 0;

            for (int i = 1; i < i_number.Length; i++)
            {
                if (Ex01.MyCompareTo(i_number[i], firstDigit) == biggerOrSmaller)
                {
                    counter++;
                    
                }
        
            }

            return counter;
        }



    }

}
