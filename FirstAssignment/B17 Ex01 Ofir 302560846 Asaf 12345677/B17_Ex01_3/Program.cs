using System;
using System.Collections.Generic;
using System.Text;


namespace B17_Ex01_3
{
    public class Program
    {
        public static void Main()
        {
            int hourglassHeight = ReadHourglassHeight();
            string hourglass = AdvancedHourglass(hourglassHeight);

			Console.WriteLine(hourglass);
			Console.WriteLine("Please press 'Enter' to exit");
            Console.ReadLine();
        }

        public static int ReadHourglassHeight()
        {
            int hourglassHeight = 0;
            bool validHourglassHeight = false;

            while(!validHourglassHeight)
            {
                Console.WriteLine("Please enter hourglass height (number)");
                string userInput = Console.ReadLine();
                validHourglassHeight = int.TryParse(userInput, out hourglassHeight);
            }

            return hourglassHeight;
        }

        public static string AdvancedHourglass(int i_hourglassHeight)
        {
            StringBuilder hourglass = new StringBuilder();
            int lineLength = 2 * (i_hourglassHeight / 2) + 1;

            for(int i = i_hourglassHeight / 2; i >= 0 ; i--)
            {
                string level = BuildLevel(i, lineLength);
                hourglass.AppendLine(level.ToString());
            }

			for (int i = 1 ; i <= i_hourglassHeight / 2; i++)
			{
				string level = BuildLevel(i, lineLength);
				hourglass.AppendLine(level.ToString());
			}

            return hourglass.ToString();
        }

		public static string BuildLevel(int i_levelIndex, int i_lineLength)
		{
            StringBuilder level = new StringBuilder();

			for (int j = i_lineLength; j > 0; j--)
			{
				int upperBound = i_lineLength - ((i_lineLength - (i_levelIndex * 2 + 1)) / 2);
				int lowerBound = (i_lineLength - (i_levelIndex * 2 + 1)) / 2;
				if (j > lowerBound && j <= upperBound)
				{
					level.Append("*");
				}

				else
				{
					level.Append(" ");
				}
			}

            return level.ToString();
		}

    }
}

