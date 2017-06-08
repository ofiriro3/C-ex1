using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {

        private float m_MaxValue;
        private float m_MinValue;
        public float MaxValue
        {
            get {
                return m_MaxValue;
            }
        }
        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }
       
        public ValueOutOfRangeException(Exception i_InnerException, float i_MinValue, float i_MaxValue , float i_inputValue)  
            : base(string.Format(
 @"An error occured while trying to add {3} , your input must be a float number between {1} - {2}"
, i_MinValue, i_MaxValue,i_inputValue),
            i_InnerException)
        { }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, float i_inputValue)  
            : base(string.Format(
 @"An error occured while trying to add {3} , your input must be a float number between {1} - {2}"
, i_MinValue, i_MaxValue, i_inputValue))
        { }
    }
}

