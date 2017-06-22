using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public class CountSpace : eIFunction
    {
        
        public void run()
        {
            Console.WriteLine("Please enter a Sentence");
            string sentenceFromUser = Console.ReadLine();
            int lengthOfOriginalString = sentenceFromUser.Length;
            sentenceFromUser.Replace(" ", string.Empty);
            int lengthAfterRemoveSpaces = sentenceFromUser.Length;

            Console.WriteLine("You have {0} spaces in your string", lengthOfOriginalString - lengthAfterRemoveSpaces);

        }

    }
}
