using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
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

        public static Dictionary<string, List<string>> GetUniqueParameters()
        {
            Dictionary<string, List<string>> uniqueParameters = new Dictionary<string, List<string>>(2);
            List<string> possibleParamertsForToxic = new List<string>(2);
            possibleParamertsForToxic.Add("true");
            possibleParamertsForToxic.Add("false");
            uniqueParameters.Add("carriesToxic", possibleParamertsForToxic);
            uniqueParameters.Add("maxCarryWeight", null);

            return uniqueParameters;
        }

		public override string ToString()
		{
			StringBuilder returnString = new StringBuilder();
			returnString.Append(base.ToString());
			returnString.Append(string.Format(
@"Carries Toxic : {0}
Max Carry Weight : {1}
", m_CarriesToxic, m_MaxCarryWeight));

			return returnString.ToString();
		}
    }
}
