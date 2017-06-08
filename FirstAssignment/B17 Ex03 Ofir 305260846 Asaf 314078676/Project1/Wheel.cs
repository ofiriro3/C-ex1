using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private string m_Manufacturer;
        private float m_CurrentTirePressure;
        private readonly float r_MaxTirePressure;

        public void Inflate(float i_PressureToAdd)
        {
            // need to verify the pressure and throw exp in case the input doesnt fit the module.
        }
    }
}
