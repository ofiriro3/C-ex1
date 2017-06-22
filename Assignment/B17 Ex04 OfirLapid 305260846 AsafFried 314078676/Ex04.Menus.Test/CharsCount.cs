using Ex04.Menus.Interfaces;
﻿using System;
using System.Collections.Generic;
using System.Text;


namespace Ex04.Menus.Test
{
    public class CharsCount : IFunction
    {
        public void Run()
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
