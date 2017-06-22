using System;
using Ex04.Menus.Interfaces;
namespace Ex04.Menus.Test
{
    public static class TestInterface
    {
		public static void Run()
		{
            MainMenuItem mainMenu = new MainMenuItem("Main Menu");
            SubMenuItem accessAndInfo = new SubMenuItem("Actions and Info");
            SubMenuItem showDateAndTime = new SubMenuItem("Show Date/Time");

            SubMenuItem Actions = new SubMenuItem("Actions");
            Actions.AddItem(new FunctionItem("Count Spaces", new CountSpace()));
            Actions.AddItem(new FunctionItem("Chars Count", new CharsCount()));
            accessAndInfo.AddItem(new FunctionItem("Display Version", new DisplayVersion()));
            accessAndInfo.AddItem(Actions);

            showDateAndTime.AddItem(new FunctionItem("Show Time", new ShowTime()));
            showDateAndTime.AddItem(new FunctionItem("Show Date", new ShowDate()));

            mainMenu.AddItem((accessAndInfo));
            mainMenu.AddItem(showDateAndTime);
            
            mainMenu.onClick();
		}

		public class CharsCount : IFunction
		{
			public void Run()
			{
				Console.WriteLine("Please enter a sentence");
				string sentenceFromUser = Console.ReadLine();
				int counter = 0;

				foreach (char letter in sentenceFromUser)
				{
					if (Char.IsLetter(letter))
					{
						counter++;
					}
				}

				Console.WriteLine("Your sentence has {0} letter in it", counter);
			}
		}

		public class CountSpace : IFunction
		{

			public void Run()
			{
				Console.WriteLine("Please enter a Sentence");
				string sentenceFromUser = Console.ReadLine();
				int lengthOfOriginalString = sentenceFromUser.Length;
				sentenceFromUser.Replace(" ", string.Empty);
				int lengthAfterRemoveSpaces = sentenceFromUser.Length;

				Console.WriteLine("You have {0} spaces in your string", lengthOfOriginalString - lengthAfterRemoveSpaces);

			}

		}

		public class DisplayVersion : IFunction
		{
			public void Run()
			{
				Console.WriteLine("App Version: 17.2.4.0");
			}
		}

		public class ShowDate : IFunction
		{
			public void Run()
			{
				DateTime dateAndTime = DateTime.Today;
				Console.WriteLine("The time now is {0}", dateAndTime.ToString("d"));
			}
		}

		public class ShowTime : IFunction
		{
			public void Run()
			{
				DateTime dateAndTime = DateTime.Now;
				Console.WriteLine("The time now is {0}", dateAndTime.ToString("T"));
			}
		}
    }
}
