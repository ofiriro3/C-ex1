using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;
        private float m_CurrentTirePressure;
        private readonly float r_MaxTirePressure;

        public void Inflate(float i_PressureToAdd)
        {
            if(i_PressureToAdd > r_MaxTirePressure - m_CurrentTirePressure || i_PressureToAdd < 0)
            {
                throw new ValueOutOfRangeException(0, r_MaxTirePressure - m_CurrentTirePressure, i_PressureToAdd);
            }
            else
            {
                m_CurrentTirePressure += i_PressureToAdd;
            }
        }
    }
}
