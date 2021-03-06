﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Battery : PowerSource
    {
        public Battery(float i_MaxCampacity, float i_CurrentCampacity)
        : base(i_MaxCampacity, i_CurrentCampacity)
        {
        }
        
        public void Charge(float i_NumberOfChargingHours)
        {
            // throws execption if exceeded max campacity
            float totalHoursAfterCharging = i_NumberOfChargingHours + m_CurrentCampacity;
            if (m_CurrentCampacity < v_MinCampacity || r_MaxCampacity < totalHoursAfterCharging)
            {
                throw new ValueOutOfRangeException(0, r_MaxCampacity - m_CurrentCampacity, totalHoursAfterCharging);
            }
            else
            {
                m_CurrentCampacity = totalHoursAfterCharging; 
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Power Source : {0} 
Current Capacity : {1} 
Max Capacity : {2}", "Battery", m_CurrentCampacity, r_MaxCampacity);
        }
    }
}
