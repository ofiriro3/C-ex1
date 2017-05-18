using System;
using System.Collections.Generic;
using System.Text;

namespace B17_Ex01_4
{
    public class Program
    {
        public static void Main()
        {
            StringBuilder response = new StringBuilder();
            string userInput = ReadUserInput();
            bool InputIsPalindrome = IsPalindrome(userInput);
            bool inputIsNumber = StringIsNumber(userInput);
            bool inputIsLegalString = IsLegalString(userInput);
            string palindromResponse = (InputIsPalindrome) ? "Input is a palindrome" : "Input isn't a palindrome";
           
            response.AppendLine(palindromResponse);
            if(inputIsNumber)
            {
                double averageDigits = AverageDigitsOfNumberInStringFormat(userInput);
                response.AppendLine("Average of digits: " + averageDigits);
            }

            else if(inputIsLegalString)
            {
                int numberOfCamelCaseChars = NumberOfCamelCaseCharsOfLegalString(userInput);
                response.AppendLine("Number of camel case chars: " + numberOfCamelCaseChars);
            }

            Console.WriteLine(response.ToString());
            Console.WriteLine("Please press 'Enter' to exit");
            Console.ReadLine();

        }

        public static string ReadUserInput()
        {
			bool validInput = false;
            string userInput = "";

			while (!validInput)
			{
				Console.WriteLine("Please enter a string with length of 8");
                userInput = Console.ReadLine();
                validInput = userInput.Length == 8;
			}

            return userInput;
        }

        public static bool IsPalindrome(string i_inputString)
        {
            bool isPalindrome = true;

            for (int i = 0; i < i_inputString.Length / 2; i++)
            {
                if(i_inputString[i] != i_inputString[i_inputString.Length - i - 1])
                {
                    isPalindrome = false;
                    break;
                }
            }

            return isPalindrome;
        }

        public static bool StringIsNumber(string i_inputString)
        {
            return int.TryParse(i_inputString, out int resultFromTryParseFunction);
        }

		public static bool IsLegalString(string i_inputString)
		{
			bool isLegalString = true;

            for (int i = 0; i < i_inputString.Length; i++)
			{
                bool isSmallEnglishLetter = (i_inputString[i] >= 'a' && i_inputString[i] <= 'z');
                bool isCapitalEnglishLetter = (i_inputString[i] >= 'A' && i_inputString[i] <= 'Z');
                if (!isSmallEnglishLetter && !isCapitalEnglishLetter)
				{
					isLegalString = false;
					break;
				}
			}

			return isLegalString;
		}

        public static double AverageDigitsOfNumberInStringFormat(string i_inputNumberInStringFormat)
        {
            double sumOfDigits = 0;
            double lengthOfNumber = i_inputNumberInStringFormat.Length;

            int.TryParse(i_inputNumberInStringFormat, out int number);
            while(number > 0)
            {
                sumOfDigits += number % 10;
                number /= 10;
            }

            return sumOfDigits / lengthOfNumber;

        }

        public static int NumberOfCamelCaseCharsOfLegalString(string i_inputString)
        {
            int numberOfCamelCaseCharsOfLegalString = 0;

            for (int i = 0; i < i_inputString.Length; i++)
            {
                if(i_inputString[i] >= 'A' && i_inputString[i] <= 'Z')
                {
                    numberOfCamelCaseCharsOfLegalString++;
                }
            }

            return numberOfCamelCaseCharsOfLegalString;
        }

    }
}