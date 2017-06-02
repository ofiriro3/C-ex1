using System;
using System.Collections.Generic;
using System.Text;
using Board = B17_Ex02_Ofir_305260846_Asaf_314078676.Board;

namespace B17_Ex02_Ofir_305260846_Asaf_314078676
{
    public class Game
    {
        private int m_NumberOfTotalGuesses;
        private Turn [] m_TurnArray;
        private int m_NumOfLeftGuesses;
        private eGameResult  m_GameResult;
        private eGuessLetter [] m_ComputerAnswer;
        public enum eGuessLetter
        {
            A ,
            B ,
            C ,
            D ,
            E ,
            F ,
            G ,
            H
        }

        static class eGuessLetterMethods
        {
            public static eGuessLetter convertCharToEGuessLetter(char i_letter)
            {
                eGuessLetter theConvertedLetter = eGuessLetter.A;
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
            Loss,
            Abort
        }

        public Game()
        {
            Board.WriteLine("Please enter valid guess numbers");
            int numberOfGuesses;
            int.TryParse(Board.ReadLine(), out numberOfGuesses);
            m_NumberOfTotalGuesses = numberOfGuesses;
            m_NumOfLeftGuesses = numberOfGuesses;
            m_TurnArray = new Turn [numberOfGuesses];
            m_ComputerAnswer = getVerifyInputFromUser(GenerateRandomSolution(4));
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

        public void Run()
        {

           while(m_NumOfLeftGuesses > 0)
           {
                string verifiedInputString = VerifyInputFromUser();
                if(verifiedInputString.Equals("Q"))
                {
                    m_GameResult = eGameResult.Abort;
                    break;
                }
                eGuessLetter[] currentGuess = getVerifyInputFromUser(verifiedInputString);
               
               Turn currentTurn = new Turn(m_ComputerAnswer, currentGuess);
               int cellToAddCurrentTurn = m_NumberOfTotalGuesses - m_NumOfLeftGuesses;
               m_TurnArray[cellToAddCurrentTurn] =currentTurn;
               Board.PrintBoard(m_TurnArray);
               if (currentTurn.IsCorrect())
               {
                   m_GameResult = eGameResult.Win;
                    break;
               }

                m_NumOfLeftGuesses--;
           }

            m_GameResult = (m_GameResult == eGameResult.Abort) ? eGameResult.Abort : eGameResult.Loss;

        }

        private eGuessLetter[] getVerifyInputFromUser(string io_VerifiedInputString)
        {
            eGuessLetter[] guessArray = new eGuessLetter[4];
            io_VerifiedInputString.Replace(" ", string.Empty);

            for(int i = 0; i < io_VerifiedInputString.Length; i++)
            {
                char currentLetter = io_VerifiedInputString[i];
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

        private bool checkValidInputContext(string i_inputFromUser)
        {
            bool validContext = true;

            foreach (char currentLetter in i_inputFromUser)
            {
                if ((currentLetter < 'A' || currentLetter > 'Z') && (currentLetter != '\b'))
                {
                    validContext = false;
                    Board.WriteLine("Wrong format please choose only letter");
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
        public string GenerateRandomSolution(int i_lengthOfSolution)
        {
            StringBuilder solution = new StringBuilder();
            int amountOfEnumOptions = Enum.GetNames(typeof(eGuessLetter)).Length;

            for (int i = 0; i < i_lengthOfSolution; i++)
            {
				Random random = new Random();
                int randomNumber = random.Next(amountOfEnumOptions);
                char currentChar = (char)('A' + randomNumber);
                solution.Append(currentChar);
            }

            Console.WriteLine(solution.ToString());
            return solution.ToString();
        }
    }
 
}
