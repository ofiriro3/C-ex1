using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class PowerSource
    {
        private readonly float r_MaxCampacity;
        private float m_CurrentCampacity;
        public enum eFuel
        {
            Soler,
            Octan95,
            Ocatan96,
            Octan98
        }

        public PowerSource(float i_MaxCampacity , float i_currentCampacity)
        {
            r_MaxCampacity = i_MaxCampacity;
            m_CurrentCampacity = i_currentCampacity;
        }
    }
}
