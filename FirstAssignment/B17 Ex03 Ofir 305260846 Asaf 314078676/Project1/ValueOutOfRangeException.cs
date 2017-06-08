using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {

        private string m_FilePath;
        public string FilePath
        {
            get { return m_FilePath; }
        }

        private string m_Word;
        public string Word
        {
            get { return m_Word; }
        }

        public FindInFileException(Exception i_InnerException, string i_Word, string i_FilePath)
            // sending two params to the base CTOR:
            : base(string.Format("An error occured while trying to find the word {0} in file {1}", i_Word, i_FilePath),
            i_InnerException)
        { }
    }
}
}
