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
                string inputIsNumberResponse = string.Format("Average of digits: {0}", averageDigits);
                response.AppendLine(inputIsNumberResponse);
            }

            else if(inputIsLegalString)
            {
                int numberOfCamelCaseChars = NumberOfCamelCaseCharsOfLegalString(userInput);
                string inputIsLegalStringResponse = string.Format("Number of camel case chars: {0}", numberOfCamelCaseChars);
                response.AppendLine(inputIsLegalStringResponse);
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

        public static bool IsPalindrome(string io_inputString)
        {
            bool isPalindrome = true;

            for (int i = 0; i < io_inputString.Length / 2; i++)
            {
                if(io_inputString[i] != io_inputString[io_inputString.Length - i - 1])
                {
                    isPalindrome = false;
                    break;
                }
            }

            return isPalindrome;
        }

        public static bool StringIsNumber(string io_inputString)
        {
            return int.TryParse(io_inputString, out int resultFromTryParseFunction);
        }

		public static bool IsLegalString(string io_inputString)
		{
			bool isLegalString = true;

            for (int i = 0; i < io_inputString.Length; i++)
			{
                bool isSmallEnglishLetter = (io_inputString[i] >= 'a' && io_inputString[i] <= 'z');
                bool isCapitalEnglishLetter = (io_inputString[i] >= 'A' && io_inputString[i] <= 'Z');
                if (!isSmallEnglishLetter && !isCapitalEnglishLetter)
				{
					isLegalString = false;
					break;
				}
			}

			return isLegalString;
		}

        public static double AverageDigitsOfNumberInStringFormat(string io_inputNumberInStringFormat)
        {
            double sumOfDigits = 0;
            double lengthOfNumber = io_inputNumberInStringFormat.Length;

            int.TryParse(io_inputNumberInStringFormat, out int number);
            while(number > 0)
            {
                sumOfDigits += number % 10;
                number /= 10;
            }

            return sumOfDigits / lengthOfNumber;

        }

        public static int NumberOfCamelCaseCharsOfLegalString(string io_inputString)
        {
            int numberOfCamelCaseCharsOfLegalString = 0;

            for (int i = 0; i < io_inputString.Length; i++)
            {
                if(io_inputString[i] >= 'A' && io_inputString[i] <= 'Z')
                {
                    numberOfCamelCaseCharsOfLegalString++;
                }
            }

            return numberOfCamelCaseCharsOfLegalString;
        }

    }
}