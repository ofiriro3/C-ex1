using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Battery : PowerSource
    {
        private float m_LeftTime;


        // in the constructor to add the maxCampacity
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
    }
}
