using System;
using System.Collections.Generic;
using System.Text;

namespace B17_Ex02_Ofir_305260846_Asaf_314078676
{
    public static class Board
    {
        public static string ReadLine()
        {
            Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit");
            string userInput = Console.ReadLine();

            return userInput;
        }

        public static void PrintBoard(Turn[] i_turns)
        {
            int pinsColumnLength = Turn.LengthOfGuess * 2 + 1;
            int resultColumnLength = Turn.LengthOfGuess * 2 - 1;
            StringBuilder lineSeparator = new StringBuilder();
            StringBuilder lineHeader = new StringBuilder();
            StringBuilder lineDefault = new StringBuilder();

            lineHeader.Append("|Pins:");
            lineHeader.Append(' ', pinsColumnLength - 5);
            lineHeader.Append("|Result:|");

            lineSeparator.Append('|');
            lineSeparator.Append('=', pinsColumnLength);
            lineSeparator.Append('|');
            lineSeparator.Append('=', resultColumnLength);
            lineSeparator.Append('|');

            Console.WriteLine(lineHeader.toString());
            Console.WriteLine(lineSeparator.toString());
            Console.WriteLine(BuildDefaultLine(Turn.LengthOfGuess));
            Console.WriteLine(lineSeparator.toString());

            for (int i = 0; i < i_turns.Length; i++)
            {
                Console.WriteLine(BuildTurnLine(Turn[i]));
                Console.WriteLine(lineSeparator.toString());
            }

        }

        private static string BuildTurnLine(Turn turn)
        {
            eGuessLetter[] guessLetters = turn.GuessLetters;
            eGuessResult[] guessResults = turn.GuessResult;
            StringBuilder turnLine = new StringBuilder();

            turnLine.Append('|');
            for (int i = 0; i < Turn.LengthOfGuess; i++)
            {
                turnLine.Append(' ');
                turnLine.Append(guessLetters[i]);
            }

            turnLine.Append(' ');
            turnLine.Append('|');
            for (int i = 0; i < Turn.LengthOfGuess; i++)
            {
                if (guessResults[i] = eGuessResult.WrongGuess)
                {
                    turnLine.Append(' ');
                }

                else
                {
                    turnLine.Append(guessResults[i]);
                }

                if (i < turnLine.LengthOfGuess - 1)
                {
                    turnLine.Append(' ');
                }
            }
            turnLine.Append('|');

            return turnLine.toString;
        }

        private static string BuildDefaultLine(int length)
        {
            StringBuilder defaultLine = new StringBuilder();
            defaultLine.Append('|');

            for (int i = 0; i < length; i++)
            {
                defaultLine.Append(' ');
                defaultLine.Append('#');
            }

            defaultLine.Append(' ');
            defaultLine.Append('|');

            for (int i = 0; i < length * 2 - 1; i++)
            {
                defaultLine.Append(' ');
            }

            defaultLine.Append('|');

            return defaultLine.toString();
        }
    }
}

