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
        private const int v_MinTirePressure = 0;

        public Wheel(string i_Manufacturer, float i_CurrentTirePressure, float i_MaxTirePressure)
        {
            if(i_CurrentTirePressure > i_MaxTirePressure)
            {
                throw new ValueOutOfRangeException(0, i_MaxTirePressure, i_CurrentTirePressure);
            }
            m_Manufacturer = i_Manufacturer;
            m_CurrentTirePressure = i_CurrentTirePressure;
            r_MaxTirePressure = i_MaxTirePressure;
        }

        public void Inflate(float i_PressureToAdd)
        {
            if(i_PressureToAdd > r_MaxTirePressure - m_CurrentTirePressure || i_PressureToAdd < v_MinTirePressure)
            {
                throw new ValueOutOfRangeException(0, r_MaxTirePressure - m_CurrentTirePressure, i_PressureToAdd);
            }
            else
            {
                m_CurrentTirePressure += i_PressureToAdd;
            }
        }

        public void InflateToMax()
        {
            m_CurrentTirePressure = r_MaxTirePressure;
        }

        public override string ToString()
        {
            return String.Format(
@"Current Tire Pressure : {0}
Manufacturer : {1}
", m_CurrentTirePressure, m_Manufacturer            
            );
        }
    }
}
