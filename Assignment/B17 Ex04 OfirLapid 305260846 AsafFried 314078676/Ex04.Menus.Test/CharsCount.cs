using System;
using System.Collections.Generic;
using System.Text;


namespace Ex04.Menus.Test
{
    class CharsCount : IFunction
    {
        public void run()
        {
            Console.WriteLine("Please enter a sentence");
            string sentenceFromUser = Console.ReadLine();
            int counter = 0;

            foreach (char letter in sentenceFromUser)
            {
                if(Char.IsLetter(letter))
                {
                    counter++;
                }
            }

            Console.WriteLine("Your sentence has {0} letter in it", counter);
        }
    }
}
