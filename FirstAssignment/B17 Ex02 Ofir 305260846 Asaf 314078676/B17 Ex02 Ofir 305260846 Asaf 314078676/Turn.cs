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
        private int m_lengthOfGuess;
        private int m_numOfBullseyes;
        private int m_numOfHits;
        private int m_numOfWrongGuesses;

    
        public Turn(eGuessLetter[] i_Solution, eGuessLetter[] i_GuessLetters)
        {
            m_Solution = i_Solution;
            m_GuessLetters = i_GuessLetters;
            m_lengthOfGuess = m_GuessLetters.Length;
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
                return m_lengthOfGuess;
            }
            set
            {
                m_lengthOfGuess = value;
            }
        }

        private void InitResultFromGuess()
        {
            m_GuessResults = new eGuessResult[m_lengthOfGuess];
            eGuessLetter[] copyOfGuessLetters = new eGuessLetter[m_lengthOfGuess];
            m_GuessLetters.CopyTo(copyOfGuessLetters, 0);

            for(int i = 0; i < m_lengthOfGuess; i++)
            {
                if(copyOfGuessLetters[i].Equals(m_Solution[i]))
                {
                   m_numOfBullseyes++;
                   copyOfGuessLetters[i] == null; 
                }
            }


            for (int i = 0; i < m_lengthOfGuess; i++)
            {
                for (int j = 0; j < m_lengthOfGuess; j++)
                {
                    if(copyOfGuessLetters[j] == null)
                    {
                        continue;
                    }
                    else if(m_Solution[i].Equals(copyOfGuessLetters[j]))
                    {
                        m_numOfHits++;
                        copyOfGuessLetters[j] == null; 
                        break;
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

        public bool IsCorrect()
        {
            return m_numOfBullseyes == m_lengthOfGuess;
        }
    }
}



