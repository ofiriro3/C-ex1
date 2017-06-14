using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class PowerSource
    {
        protected const float v_MinCampacity = 0;
        protected readonly float r_MaxCampacity;
        protected float m_CurrentCampacity;

        public enum eFuel
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        public PowerSource(float i_MaxCampacity, float i_CurrentCampacity)
        {
			if (i_CurrentCampacity > i_MaxCampacity)
			{
                throw new ValueOutOfRangeException(0, i_MaxCampacity, i_CurrentCampacity);
            }

            r_MaxCampacity = i_MaxCampacity;
            m_CurrentCampacity = i_CurrentCampacity;
        }
    }
}
