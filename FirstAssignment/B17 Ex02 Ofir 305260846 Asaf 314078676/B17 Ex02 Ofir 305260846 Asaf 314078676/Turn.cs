using System;
using System.Collections.Generic;
using System.Text;

namespace B17_Ex02_Ofir_305260846_Asaf_314078676
{
    class Turn
    {
        private eGuessLetter[] m_Solution;
        private eGuessLetter[] m_GuessLetters;
        private eGuessResult[] m_GuessResults;
        private int m_lengthOfGuess;
        private int m_numOfBullseyes;
        private int m_numOfHits;
        private int m_numOfWrongGuesses;

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

        public eGuessResult[] GuessResult
        {
            get
            {
                return m_GuessResult;
            }
            set
            {
                m_GuessResult = value;
            }
        }

        public Turn(eGuessLetter[] i_Solution, eGuessLetter[] i_guessLetters)
        {
            m_Solution = i_Solution;
            m_GuessLetters = i_guessLetters;
            m_lengthOfGuess = m_GuessLetters.Length;
            InitResultFromGuess();
        }

        private void InitResultFromGuess()
        {
            m_GuessResults = new eGuessResult[m_lengthOfGuess];

            for(int i = 0; i < m_lengthOfGuess; i++)
            {
                for(int j = 0; j < m_Solution.Length; j++)
                {
                  if(m_GuessLetters[i].equals(m_Solution[j]))
                  {
                      if(i == j)
                      {
                        m_numOfBullseyes++;
                      }

                      else
                      {
                        m_numOfHits++;   
                      }
                  }  
                }
            }
            m_numOfWrongGuesses = m_lengthOfGuess - m_numOfBullseyes - m_numOfHits;
            for (int i = 0; i < m_numOfBullseyes; i++)
            {
                m_GuessResults[i] = eGuessResult.V;
            }

            for (int i = 0; i < m_numOfHits; i++)
            {
                m_GuessResults[i + m_numOfBullseyes] = eGuessResult.X;
            }

            for (int i = 0; i < m_numOfWrongGuesses; i++)
            {
                m_GuessResults[i + m_numOfBullseyes + m_numOfHits] = eGuessResult.WrongGuess;
            }
        }

        public bool IsCorrect(){
            return m_numOfBullseyes = m_lengthOfGuess;
        }
    }
}
