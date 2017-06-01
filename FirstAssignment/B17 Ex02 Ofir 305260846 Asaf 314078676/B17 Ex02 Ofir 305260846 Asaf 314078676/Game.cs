using System;
using System.Collections.Generic;
using System.Text;
using Board = B17_Ex02_Ofir_305260846_Asaf_314078676.Board;

namespace B17_Ex02_Ofir_305260846_Asaf_314078676
{
    class Game
    {
        private List<Turn> m_TurnArray;
        private int m_NumOfLeftGuesses;
        private eGameResult m_GameResult;
        private eGuessLetter m_ComputerAnswer;
        public enum eGuessLetter
        {
            A = 'A',
            B = 'B',
            C = 'C',
            D = 'D',
            E = 'E',
            F = 'F',
            G = 'G',
            H = 'H',
            NotValidLetter
        }

        static class eGuessLetterMethods
        {
            public static eGuessLetter convertCharToEGuessLetter(char i_letter)
            {
                eGuessLetter theConvertedLetter = eGuessLetter.NotValidLetter;
                switch(i_letter)
                {
                    case 'A': theConvertedLetter = eGuessLetter.A;
                              break;
                    case 'B':
                        theConvertedLetter = eGuessLetter.B;
                        break;
                    case 'C':
                        theConvertedLetter = eGuessLetter.C;
                        break;
                    case 'D':
                        theConvertedLetter = eGuessLetter.D;
                        break;
                    case 'E':
                        theConvertedLetter = eGuessLetter.E;
                        break;
                    case 'F':
                        theConvertedLetter = eGuessLetter.F;
                        break;
                    case 'G':
                        theConvertedLetter = eGuessLetter.G;
                        break;
                    case 'H':
                        theConvertedLetter = eGuessLetter.H;
                        break;
                }

                return theConvertedLetter;
            }
        }
        public enum eGuessResult
        {
            X,
            V,
            WrongGuess
        }
        public enum eGameResult
        {
            Win,
            Loss
        }


        public Game(int i_NumOfGuesses)
        {
            m_NumOfLeftGuesses = i_NumOfGuesses;
            m_TurnArray = new List<Turn>(i_NumOfGuesses);

        }

        public void Run()
        {
            bool stillPlaying = true;

            while (stillPlaying)
            {
                eGuessLetter[] currentGueesInStringFormat = getVerifyInputFromUser();

           
            }

        }

        private eGuessLetter[] getVerifyInputFromUser()
        {
            string verifiedInputString = VerifyInputFromUser();
            eGuessLetter[] guessArray = new eGuessLetter[4];
            for(int i = 0; i < verifiedInputString.Length; i++)
            {
                char currentLetter = verifiedInputString[i];
                guessArray[i] = eGuessLetterMethods.convertCharToEGuessLetter(currentLetter);
            }

            return guessArray;
        }

     

        private string VerifyInputFromUser()
        {
            string inputFromUser = Board.ReadInput();
            
            while (!checkValidInputFormat(inputFromUser) || !checkValidInputContext(inputFromUser))
            {
                inputFromUser = Board.ReadInput();
            }

            return inputFromUser;
        }

        private bool checkValidInputContext(string i_inputFromUser)
        {
            bool validContext = true;

            foreach (char currentLetter in i_inputFromUser)
            {
                if ((currentLetter < 'A' || currentLetter > 'Z') && (currentLetter != '\b'))
                {
                    validContext = false;
                    Console.WriteLine("Wrong format please choose only letter");
                    break;
                }  
            }

            return validContext;
        }

        private bool checkValidInputFormat(string i_inputFromUser)
        {

            bool validFormat = true;
            if (i_inputFromUser.Length != 7)
            {
                foreach (char currentLetter in i_inputFromUser)
                {
                    if (currentLetter < 'A' || currentLetter > 'H')
                    {
                        validFormat = false;
                        Console.WriteLine("Wrong context , please enter only letters between A and H");
                        break;
                    }
                }
            }
            else
            {
                validFormat = false;
            }


            return validFormat;
        }
    }
}
