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
            get
            {
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
       
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, float i_InputValue)  
            : base(string.Format(
 @"An error occured while trying to put {2} as one of the values , your input must be a float number between {0} - {1}"
        , i_MinValue, i_MaxValue, i_InputValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
    }
}