using System;
using System.Collections.Generic;
using System.Text;
using Board = B17_Ex02_Ofir_305260846_Asaf_314078676.Board;

namespace B17_Ex02_Ofir_305260846_Asaf_314078676
{
    public class Game
    {
        private readonly int m_lengthOfGuess = 4;
        private int m_NumberOfTotalGuesses;
        private Turn[] m_TurnArray;
        private int m_NumOfLeftGuesses;
        private eGameResult m_GameResult;
        private eGuessLetter[] m_ComputerAnswer;

        public enum eGuessLetter
        {
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H
        }

        public static class eGuessLetterMethods
        {
            public static eGuessLetter convertCharToEGuessLetter(char i_letter)
            {
                eGuessLetter theConvertedLetter = eGuessLetter.A;
                switch (i_letter)
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
            Loss,
            Abort
        }

        public Game()
        {
            int numberOfGuesses;
            validGuessNumber(out numberOfGuesses);
            m_NumberOfTotalGuesses = numberOfGuesses;
            m_NumOfLeftGuesses = numberOfGuesses;
            m_TurnArray = new Turn[numberOfGuesses];
            m_ComputerAnswer = getVerifyInputFromUser(GenerateRandomSolution(m_lengthOfGuess));
        }

        private void validGuessNumber(out int o_NumberOfGuesses)
        {
            bool isValid = false;
            o_NumberOfGuesses = 0;
            Board.WriteLine("Please enter valid guess numbers");
            while (!isValid)
            {
                bool isANumber = int.TryParse(Board.ReadLine(), out o_NumberOfGuesses);
                if (isANumber)
                {
                    if (o_NumberOfGuesses >= 4 && o_NumberOfGuesses <= 10)
                    {
                        isValid = true;
                        break;
                    }
                }

                Board.WriteLine("This is not a valid input, please enter a number between 4-10");
            }

            Board.WriteLine(string.Format("{0} is a valid guess ", o_NumberOfGuesses));
        }

        public eGameResult GameResult
        {
            get
            {
                return m_GameResult;
            }

            set
            {
                m_GameResult = value;
            }
        }

        public int GetNumOfGuessMade()
        {
            return m_NumberOfTotalGuesses - m_NumOfLeftGuesses;
        }

        public void Run()
        {
            while (m_NumOfLeftGuesses > 0)
            {
                Board.PrintBoard(m_TurnArray, m_lengthOfGuess);
                string verifiedInputString = VerifyInputFromUser();

                if(verifiedInputString.Equals("Q"))
                {
                    m_GameResult = eGameResult.Abort;
                    break;
                }

                eGuessLetter[] currentGuess = getVerifyInputFromUser(verifiedInputString);
               
               Turn currentTurn = new Turn(m_ComputerAnswer, currentGuess);
               int cellToAddCurrentTurn = m_NumberOfTotalGuesses - m_NumOfLeftGuesses;
               m_TurnArray[cellToAddCurrentTurn] = currentTurn;
               Board.PrintBoard(m_TurnArray, m_lengthOfGuess);
               if (currentTurn.IsCorrect())
               {
                   m_GameResult = eGameResult.Win;
                    break;
               }

                m_NumOfLeftGuesses--;
           }

            m_GameResult = (m_GameResult == eGameResult.Abort) ? eGameResult.Abort : eGameResult.Loss;
        }

        private eGuessLetter[] getVerifyInputFromUser(string i_VerifiedInputString)
        {
            eGuessLetter[] guessArray = new eGuessLetter[m_lengthOfGuess];
            string inputWithoutSpaces = i_VerifiedInputString.Replace(" ", string.Empty);

            for(int i = 0; i < inputWithoutSpaces.Length; i++)
            {
                char currentLetter = inputWithoutSpaces[i];
                guessArray[i] = eGuessLetterMethods.convertCharToEGuessLetter(currentLetter);
            }

            return guessArray;
        }

        private string VerifyInputFromUser()
        {
            string inputFromUser = Board.ReadGuess();
            
                while (!inputFromUser.Equals("Q") && 
                    (!checkValidInputFormat(inputFromUser) || !checkValidInputContext(inputFromUser)))
                {
                    inputFromUser = Board.ReadGuess();
                }
            
            return inputFromUser;
        }

        private bool checkValidInputFormat(string i_inputFromUser)
        {
            bool validFormat = true;
            string inputWithoutSpaces = i_inputFromUser.Replace(" ", string.Empty);
            if (inputWithoutSpaces.Length == 4)
            {
                foreach (char currentLetter in inputWithoutSpaces)
                {
                    if ((currentLetter < 'A' || currentLetter > 'Z') && (currentLetter != '\b'))
                    {
                        validFormat = false;
                        Board.WriteLine("Wrong format please choose Capitals letter");
                        break;
                    }
                }
            }
            else
            {
                Board.WriteLine(string.Format("Please enter only {0} letters", m_lengthOfGuess));
                validFormat = false;
            }

            return validFormat;
        }
    
        private bool checkValidInputContext(string i_inputFromUser)
        {
            string inputWithoutSpaces = i_inputFromUser.Replace(" ", string.Empty);
            bool validContext = true;
            foreach (char currentLetter in inputWithoutSpaces)
            {
                    if (currentLetter < 'A' || currentLetter > 'H')
                    {
                        validContext = false;
                        Board.WriteLine("Wrong context , please enter only letters between A and H");
                        break;
                    }
            }
    
            return validContext;
        }

        public string GenerateRandomSolution(int i_lengthOfSolution)
        {
            StringBuilder solution = new StringBuilder();
            int amountOfEnumOptions = Enum.GetNames(typeof(eGuessLetter)).Length;

            for (int i = 0; i < i_lengthOfSolution; i++)
            {
				Random random = new Random();
                int randomNumber = random.Next(amountOfEnumOptions);
                char currentChar = (char)('A' + randomNumber);

                ////checks if the string already contains the current letter
                if (solution.ToString().Contains(char.ToString(currentChar)))    
                {
                    i--;
                }
                else
                { 
                    solution.Append(currentChar);
                }
            }

            ////Console.WriteLine(solution.ToString());
            return solution.ToString();
        }
    }
}
