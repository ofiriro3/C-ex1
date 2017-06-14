using System;
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
                throw new ValueOutOfRangeException(v_MinCampacity, r_MaxCampacity, totalHoursAfterCharging);
            }
            else
            {
                m_CurrentCampacity = totalHoursAfterCharging; 
            }
        }

        public override string ToString()
        {
            string batteryToString =  string.Format(
@"Power Source : {0}
Current Capacity : {1}", "Battery", m_CurrentCampacity);

            return batteryToString;
        }
    }
}
