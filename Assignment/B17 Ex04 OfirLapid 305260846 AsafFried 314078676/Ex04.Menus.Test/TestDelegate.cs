using System;
using Ex04.Menus.Delegates;
namespace Ex04.Menus.Test
{
    public static class TestDelegate
    {
        public static void Run()
        {
            MainMenuItem mainMenu = new MainMenuItem("Main Menu");
            SubMenuItem accessAndInfo = new SubMenuItem("Actions and Info");
            SubMenuItem showDateAndTime = new SubMenuItem("Show Date/Time");

            SubMenuItem Actions = new SubMenuItem("Actions");
            
            Actions.AddItem(new FunctionItem("Count Spaces", CharsCountFunction));
            Actions.AddItem(new FunctionItem("Chars Count", CharsCountFunction));
            accessAndInfo.AddItem(new FunctionItem("Display Version", DisplayVersionFunction));
            accessAndInfo.AddItem(Actions);

            showDateAndTime.AddItem(new FunctionItem("Show Time", ShowTimeFunction));
            showDateAndTime.AddItem(new FunctionItem("Show Date", ShowDateFunction));

            mainMenu.AddItem((accessAndInfo));
            mainMenu.AddItem(showDateAndTime);

            mainMenu.onClick();
        }
    
    
        public static void CountSpacesFunction()
        {
            Console.WriteLine("Please enter a Sentence");
            string sentenceFromUser = Console.ReadLine();
            int lengthOfOriginalString = sentenceFromUser.Length;
            sentenceFromUser.Replace(" ", string.Empty);
            int lengthAfterRemoveSpaces = sentenceFromUser.Length;

            Console.WriteLine("You have {0} spaces in your string", lengthOfOriginalString - lengthAfterRemoveSpaces);

        }

        public static void CharsCountFunction()
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
    
        public static void DisplayVersionFunction()
        {
            Console.WriteLine("App Version: 17.2.4.0");
        }

        public static void ShowTimeFunction()
        {
            DateTime dateAndTime = DateTime.Now;
             Console.WriteLine("The time now is {0}", dateAndTime.ToString("T"));
        }

        public static void ShowDateFunction()
        {
            DateTime dateAndTime = DateTime.Today;
            Console.WriteLine("The time now is {0}", dateAndTime.ToString("d"));

        }
        
    

    }
}