﻿using System;
using System.Collections.Generic;
using System.Text;
using eGuessLetter = B17_Ex02_Ofir_305260846_Asaf_314078676.Game.eGuessLetter;
using eGuessResult = B17_Ex02_Ofir_305260846_Asaf_314078676.Game.eGuessResult;

namespace B17_Ex02_Ofir_305260846_Asaf_314078676
{
    public static class Board
    {
        public static string ReadGuess()
        {
            Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit");
            string userInput = Console.ReadLine();

            return userInput;
        }

        public static string ReadLine()
        {
            string userInput = Console.ReadLine();

            return userInput;
        }

        public static string ReadNewGameSelect()
        {
            Console.WriteLine("Would you like to start a new game? <Y/N>");
            string userInput = Console.ReadLine();

            return userInput;
        }

        internal static void PrintWinningMessage(int i_NumOfGuessMade)
        {
            Console.WriteLine(string.Format("You guessed after {0} steps!", i_NumOfGuessMade));
        }

        public static void PrintLosingMessage()
        {
            Console.WriteLine("No more guess allowed. You Lost.");
        }

        private static string buildTurnLine(Turn i_Turn)
        {
            eGuessLetter[] guessLetters = i_Turn.GuessLetters;
            eGuessResult[] guessResults = i_Turn.GuessResults;
            StringBuilder turnLine = new StringBuilder();

            turnLine.Append('|');
            for (int i = 0; i < i_Turn.LengthOfGuess; i++)
            {
                turnLine.Append(' ');
                turnLine.Append(guessLetters[i]);
            }

            turnLine.Append(' ');
            turnLine.Append('|');
            for (int i = 0; i < i_Turn.LengthOfGuess; i++)
            {
                if (guessResults[i] == eGuessResult.WrongGuess)
                {
                    turnLine.Append(' ');
                }
                else
                {
                    turnLine.Append(guessResults[i]);
                }

                if (i < i_Turn.LengthOfGuess - 1)
                {
                    turnLine.Append(' ');
                }
            }

            turnLine.Append('|');

            return turnLine.ToString();
        }

        private static string buildDefaultLine(int i_Length, char i_CharToAppear)
        {
            StringBuilder defaultLine = new StringBuilder();
            defaultLine.Append('|');

            for (int i = 0; i < i_Length; i++)
            {
                defaultLine.Append(' ');
                defaultLine.Append(i_CharToAppear);
            }

            defaultLine.Append(' ');
            defaultLine.Append('|');

            for (int i = 0; i < (i_Length * 2) - 1; i++)

            {
                defaultLine.Append(' ');
            }

            defaultLine.Append('|');

            return defaultLine.ToString();
        }

        public static void PrintBoard(Turn[] i_Turns, int i_LengthOfGuess, int i_NumberOfGuess)
        {
            int pinsColumnLength = (i_LengthOfGuess * 2) + 1;
            int resultColumnLength = (i_LengthOfGuess * 2) - 1;

            StringBuilder lineSeparator = new StringBuilder();
            StringBuilder lineHeader = new StringBuilder();
            StringBuilder lineDefault = new StringBuilder();

            Console.WriteLine("Current board status:");
            lineHeader.Append("|Pins:");
            lineHeader.Append(' ', pinsColumnLength - 5);
            lineHeader.Append("|Result:|");

            lineSeparator.Append('|');
            lineSeparator.Append('=', pinsColumnLength);
            lineSeparator.Append('|');
            lineSeparator.Append('=', resultColumnLength);
            lineSeparator.Append('|');

            Console.WriteLine(lineHeader.ToString());
            Console.WriteLine(lineSeparator.ToString());
            Console.WriteLine(buildDefaultLine(i_LengthOfGuess, '#'));
            Console.WriteLine(lineSeparator.ToString());

            for (int i = 0; i < i_NumberOfGuess; i++)
            {
                if (i_Turns == null || i_Turns[i] == null)
                {
                    Console.WriteLine(buildDefaultLine(i_LengthOfGuess, ' '));
                }
                else
                {
                    Console.WriteLine(buildTurnLine(i_Turns[i]));
                }

                Console.WriteLine(lineSeparator.ToString());
            }
        }

        public static void WriteLine(string i_Message)
        {
            Console.WriteLine(i_Message);
        }
    }
}
