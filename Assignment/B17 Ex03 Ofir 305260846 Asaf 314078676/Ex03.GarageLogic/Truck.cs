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
                : base(i_ModuleName, i_LicensePlate, i_Wheels, i_PowerSource, 12)
        {
            m_CarriesToxic = i_CarriesToxic;
            m_MaxCarryWeight = i_MaxCarryWeight;
        }

		public override string ToString()
		{
			StringBuilder returnString = new StringBuilder();
			returnString.Append(base.ToString());
			returnString.Append(String.Format(
				@"Carries Toxic : {0}
                Max Carry Weight : {1}", m_CarriesToxic, m_MaxCarryWeight
			));

			return returnString.ToString();
		}
    }
}
