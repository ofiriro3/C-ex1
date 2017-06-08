// $G$ THE-001 (-3) The explanation for the file being a PE is lacking. The file is a PE because it is a .NET assembly that can be executed.
// $G$ THE-001 (-3) The explanation for the file being an assembly is lacking. The file is an assembly because it can be analysed by ILDASM.
using System;
using System.Collections.Generic;
using System.Text;

namespace B17_Ex01_1
{
    public class Program
    {
        // $G$ DSN-999 (-5) The Main method should only be an access point to the program. Should look something like:
        // public static void Main() { Run(); } 
        public static void Main()
        {
            string msgToScreen;
            // $G$ NTT-999 (-10) You should have used Environment.NewLine instead of "\n".
            Console.Write("Please enter 3 numbers with 3 digits each\n");
            string [] arrayOfInputNums = new string[3];       // An array that will cotain the 3 numbers
            GetThreePositiveNumbersFromUser(arrayOfInputNums);
            string[] arrayOfBinaryNum = TransalteEntireArrayToBinnary(arrayOfInputNums);
            double averageNumberOfBinaryDigitsVariable = CalcualteAverageOfNumberOfBinnaryDigitsInArray(arrayOfBinaryNum);
            int numberOfAcseningNumbers = CountsNumbersAreInOrder(arrayOfInputNums, -1); //count how many numbers are in ascending order
            int numberOfDecseningNumbers = CountsNumbersAreInOrder(arrayOfInputNums, 1); // count how many numbera are in decsending order
            double average = AverageOfAStringArrayNumbers(arrayOfInputNums);

            msgToScreen = string.Format(
@"The binary numbers are {0} {1} {2}
There are {4} numbers which are acending series and {5} which are descending
The average number of digits in binary is {3}
The general average of the inserted numbers is {6}", arrayOfBinaryNum[0], arrayOfBinaryNum[1], arrayOfBinaryNum[2],averageNumberOfBinaryDigitsVariable,
                                            numberOfAcseningNumbers, numberOfDecseningNumbers,average);

            Console.WriteLine(msgToScreen);
            Console.WriteLine("Please press 'Enter' to exit");
            Console.ReadLine();
        }

        // $G$ CSS-999 (-3) Private methods should start with a lowercase letter.
        // $G$ CSS-013 (-5) Bad variable name (should be in the form of i_PascalCase).
        private static void GetThreePositiveNumbersFromUser(string [] o_arrayOfNum)
        {
            int numberOfInputs = 0;
            int currentInputInIntFormat;
            while (numberOfInputs < 3)
            {
                String currentInputString = Console.ReadLine();
                bool IsNumber = int.TryParse(currentInputString, out currentInputInIntFormat);
                // $G$ SFN-012 (-5) The program does not cope properly with invalid input, what about negative numbers?
                if (!IsNumber || currentInputString.Length != 3)
                {
                    Console.WriteLine("The input you entered is Invalid. Please try again");
                    continue;
                }
                else
                {
                    o_arrayOfNum[numberOfInputs] = currentInputString;
                    numberOfInputs++;
                }
            }
        }

        public static string TransalteToBinary(string i_number)
        {
            int theNumberInTheString;
            bool isDigit = int.TryParse(i_number, out theNumberInTheString);
            StringBuilder binarTranslateOfNum = new StringBuilder();

            // $G$ CSS-027 (-3) Spaces are not kept as required.
            if ( ! isDigit)
            {
                binarTranslateOfNum.Append("Cannot translate to binary , it's not a number");
            }
            else
            {
                // calculate the i_number binary value   
                while (theNumberInTheString > 0)
                {
                    binarTranslateOfNum.Insert(0, theNumberInTheString % 2);
                    theNumberInTheString /= 2;
                }

            }

            return binarTranslateOfNum.ToString();
        }

        public static string [] TransalteEntireArrayToBinnary(string [] o_array)
        {
            string[] binnaryArray = new string[o_array.Length];

            for (int i = 0; i < o_array.Length; i++)
            {
                binnaryArray[i] = TransalteToBinary(o_array[i]);
            }

            return binnaryArray;
        }

        public static double CalcualteAverageOfNumberOfBinnaryDigitsInArray(string [] o_array)
        {
            double sumOfDigits = 0;

            for(int i = 0; i < o_array.Length; i++)
            {
                sumOfDigits += o_array[i].Length;
            }

            return sumOfDigits / o_array.Length;
        }

        public static int CountsNumbersAreInOrder(string [] o_array, int i_AscendingOrDecseding)
        {
            int inOrderNumbers = 0;
           
            for(int i = 0; i < o_array.Length; i++)
            {
                inOrderNumbers += InOrderNumber(o_array[i], i_AscendingOrDecseding);  
            }

            return inOrderNumbers;
        }

        private static int InOrderNumber(string i_number, int i_ascendingOrDecseding)
        {
            int isInOrder = 1;
            char [] currentDigit = i_number.ToCharArray();
            
            for(int i = 0; i < currentDigit.Length - 1;i++)
            {
                // in case it's in the asked order , stop checking
                if(MyCompareTo(currentDigit[i],currentDigit [i+1]) != i_ascendingOrDecseding)
                {
                    isInOrder = 0;
                    break;
                }
            }

            return isInOrder;
        }

        public static int MyCompareTo(char io_letter1, char io_letter2)
        {
            int returnValue = 0;

            if(io_letter1 > io_letter2)
            {
                returnValue = 1;        
            }
            else if(io_letter2 > io_letter1)
            {
                returnValue = -1;
            }

            return returnValue;
        }

        public static double AverageOfAStringArrayNumbers (string [] i_array)
        {
            int[] arrayNumbers = ConvertStringArrayToIntArray(i_array);
            double sum = 0;

            for (int i = 0; i < arrayNumbers.Length;i++)
            {
                sum += arrayNumbers[i];
            }

            return sum / arrayNumbers.Length;
        }

        public static int [] ConvertStringArrayToIntArray  (string [] i_array)
        {
            int[] arrayOfInt = new int[i_array.Length];

            for (int i = 0; i < i_array.Length; i++)
            {
                bool isDigit = int.TryParse(i_array[i], out arrayOfInt[i]);
                if ( !isDigit)
                {
                    arrayOfInt = null;
                    break;
                }
            }

            return arrayOfInt;
        }
    }
}
