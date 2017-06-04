using System;
using System.Collections.Generic;
using System.Text;
using eGuessLetter = B17_Ex02_Ofir_305260846_Asaf_314078676.Game.eGuessLetter;
using eGuessResult = B17_Ex02_Ofir_305260846_Asaf_314078676.Game.eGuessResult;

namespace B17_Ex02_Ofir_305260846_Asaf_314078676
{
    public class Turn
    {
        private eGuessLetter[] m_Solution;
        private eGuessLetter[] m_GuessLetters;
        private eGuessResult[] m_GuessResults;
<<<<<<< HEAD
        private int m_lengthOfGuess;
        private int m_numOfBullseyes;
        private int m_numOfHits;
        private int m_numOfWrongGuesses;
 
=======
        private int m_LengthOfGuess;
        private int m_NumOfBullseyes;
        private int m_NumOfHits;
        private int m_NumOfWrongGuesses;

    
>>>>>>> 75eb83beaaa3de5d3c80749bd76cc1061548da0b
        public Turn(eGuessLetter[] i_Solution, eGuessLetter[] i_GuessLetters)
        {
            m_Solution = i_Solution;
            m_GuessLetters = i_GuessLetters;
            m_LengthOfGuess = m_GuessLetters.Length;
            InitResultFromGuess();
        }

        public eGuessLetter[] GuessLetters
        {
            get
            {
                return m_GuessLetters;
            }

            set
            {
                m_GuessLetters = value;
            }
        }

        public eGuessResult[] GuessResults
        {
            get
            {
                return m_GuessResults;
            }

            set
            {
                m_GuessResults = value;
            }
        }

        public int LengthOfGuess
        {
            get
            {
                return m_LengthOfGuess;
            }

            set
            {
                m_LengthOfGuess = value;
            }
        }

        private void InitResultFromGuess()
        {
            m_GuessResults = new eGuessResult[m_LengthOfGuess];
            List<int> invalidIndexes = new List<int>();

            for(int i = 0; i < m_LengthOfGuess; i++)
            {
                if(m_GuessLetters[i].Equals(m_Solution[i]))
                {
                   m_NumOfBullseyes++;
                    invalidIndexes.Add(i);
                }
            }

<<<<<<< HEAD
            for (int i = 0; i < m_lengthOfGuess; i++)
=======

            for (int i = 0; i < m_LengthOfGuess; i++)
>>>>>>> 75eb83beaaa3de5d3c80749bd76cc1061548da0b
            {
                for (int j = 0; j < m_LengthOfGuess; j++)
                {
                    if(invalidIndexes.Contains(j))
                    {
                        continue;
                    }

                    else if(m_Solution[i].Equals(m_GuessLetters[j]))
                    {
                        m_NumOfHits++;
                        invalidIndexes.Add(j); 
                        break;
                    }
                }
            }

            m_NumOfWrongGuesses = m_LengthOfGuess - m_NumOfBullseyes - m_NumOfHits;
            for (int i = 0; i < m_NumOfBullseyes; i++)
            {
                m_GuessResults[i] = eGuessResult.V;
            }

            for (int i = 0; i < m_NumOfHits; i++)
            {
                m_GuessResults[i + m_NumOfBullseyes] = eGuessResult.X;
            }

            for (int i = 0; i < m_NumOfWrongGuesses; i++)
            {
                m_GuessResults[i + m_NumOfBullseyes + m_NumOfHits] = eGuessResult.WrongGuess;
            }
        }

        public bool IsCorrect()
        {
            return m_NumOfBullseyes == m_LengthOfGuess;
        }
    }
}
