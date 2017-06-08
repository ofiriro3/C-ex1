using System;
using System.Collections.Generic;
using System.Text;


namespace B17_Ex01_2
{
    class Program
    {
        public static void Main()
        {
            string hourglass = beginnersHourglass();

            Console.WriteLine(hourglass);
            Console.WriteLine("Please press 'Enter' to exit");
            Console.ReadLine();
        }

        public static string beginnersHourglass()
        {
            string levelOne = "******";
            string levelTwo = " *** ";
            string levelThree = "  *  ";
            string levelFour = " *** ";
            string levelFive = "******";
            string hourglass = string.Format(
                @"
                {4}
                {3}
                {2}
                {1}
                {0}", levelOne, levelTwo, levelThree, levelFour, levelFive);

            return hourglass;
        }
    }
}

