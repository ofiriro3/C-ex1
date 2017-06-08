using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool m_CarriesToxic;
        private float m_MaxCarryWeight;

        public Truck(string i_ModuleName, string i_LicensePlate, bool i_CarriesToxic, float i_MaxCarryWeight,
       List<Wheel> i_Wheels, PowerSource i_PowerSource)
                : base(i_ModuleName, i_LicensePlate, i_Wheels, i_PowerSource)
        {
            m_CarriesToxic = i_CarriesToxic;
            m_MaxCarryWeight = i_MaxCarryWeight;
        }
    }
}
