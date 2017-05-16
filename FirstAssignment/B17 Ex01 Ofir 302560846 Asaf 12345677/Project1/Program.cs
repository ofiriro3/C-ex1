using System;
using System.Collections.Generic;
using System.Text;

namespace B17_Ex01_1
{
    public class Program
    {
        public static void Main()
        {
            string msg;
            Console.Write("Please enter 3 numbers with 3 digits each\n");
            
            // An array that will cotain the 3 numbers
            string [] arrayOfInputNums = new string[3];
            GetThreePositiveNumbersFromUser(arrayOfInputNums);
            string[] arrayOfBinaryNum = transalteEntireArrayToBinnary(arrayOfInputNums);
            double averageNumberOfBinaryDigitsVariable = calcualteAverageOfNumberOfBinnaryDigitsInArray(arrayOfBinaryNum);

            // CountNumbers returns the number of acending\descending numbers in the array if the second paramater is -1\1
            int numberOfAcseningNumbers = CountsNumbersAreInOrder(arrayOfInputNums, -1);
            int numberOfDecseningNumbers = CountsNumbersAreInOrder(arrayOfInputNums, 1);
            double average = averageOfAStringArrayNumbers(arrayOfInputNums);

            msg = string.Format(
@"The binary numbers are {0} {1} {2}
There are {4} numbers which are acending series and {5} which are descending
The average number of digits in binary is {3}
The general average of the inserted numbers is {6}", arrayOfBinaryNum[0], arrayOfBinaryNum[1], arrayOfBinaryNum[2],averageNumberOfBinaryDigitsVariable,
                                            numberOfAcseningNumbers, numberOfDecseningNumbers,average);

            Console.WriteLine(msg);
            Console.WriteLine("Please press 'Enter' to exit");
            Console.ReadLine();
        }

        private static void GetThreePositiveNumbersFromUser(string [] o_arrayOfNum)
        {
            int numberOfInputs = 0;
            int currentInputInIntFormat;
            while (numberOfInputs < 3)
            {
                String currentInputString = Console.ReadLine();
                bool IsNumber = int.TryParse(currentInputString, out currentInputInIntFormat);

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

        public static string transalteToBinary(string i_number)
        {
            int theNumberInTheString;
            bool isDigit = int.TryParse(i_number, out theNumberInTheString);
            StringBuilder binarTranslateOfNum = new StringBuilder();

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

        public static string [] transalteEntireArrayToBinnary(string [] o_array)
        {
            string[] binnaryArray = new string[o_array.Length];

            for (int i = 0; i < o_array.Length; i++)
            {
                binnaryArray[i] = transalteToBinary(o_array[i]);
            }

            return binnaryArray;
        }

        public static double calcualteAverageOfNumberOfBinnaryDigitsInArray(string [] o_array)
        {
            double sumOfDigits = 0;

            for(int i = 0; i < o_array.Length; i++)
            {
                sumOfDigits += o_array[i].Length;
            }

            return sumOfDigits / o_array.Length;
        }

        public static int CountsNumbersAreInOrder(string [] o_array,int AscendingOrDecseding)
        {
            int inOrderNumbers = 0;
           
            for(int i = 0; i < o_array.Length; i++)
            {

                inOrderNumbers += inOrderNumber(o_array[i], AscendingOrDecseding);
               
            }

            return inOrderNumbers;
        }

        private static int inOrderNumber(string number, int ascendingOrDecseding)
        {
            int isInOrder = 1;
            char [] currentDigit = number.ToCharArray();
            
            for(int i = 0; i < currentDigit.Length - 1;i++)
            {
                // in case it's in asked order , stop checking
                if(MyCompareTo(currentDigit[i],currentDigit [i+1]) != ascendingOrDecseding)
                {
                    isInOrder = 0;
                    break;
                }
            }

            return isInOrder;
        }

        public static int MyCompareTo(char letter1, char letter2)
        {
            int returnValue = 0;

            if( letter1 > letter2)
            {
                returnValue = 1;
            }
            else if( letter2 > letter1)
            {
                returnValue = -1;
            }

            return returnValue;
        }

        public static double averageOfAStringArrayNumbers (string [] i_array)
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
                
                // in case casting of one of the array element failed returns null
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
