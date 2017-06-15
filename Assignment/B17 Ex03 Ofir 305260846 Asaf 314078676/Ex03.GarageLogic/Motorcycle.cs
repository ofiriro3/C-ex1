using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {

        private eLicenceType m_LicenceType;
        private int m_EngineVolume;
        public enum eLicenceType
        {
            A,
            AB,
            A2,
            B1
        }


        public Motorcycle(string i_ModuleName, string i_LicensePlate, eLicenceType i_LicenceType, int i_EngineVolume,
           List<Wheel> i_Wheels, PowerSource i_PowerSource)
            : base(i_ModuleName, i_LicensePlate, i_Wheels, i_PowerSource, 2)
        {
            m_LicenceType = i_LicenceType;
            m_EngineVolume = i_EngineVolume;
        }


        public static Dictionary<String, List<String>> GetUniqueParameters()
        {
            Dictionary<String, List<String>> uniqueParameters = new Dictionary<string, List<string>>(2);
            List<String> possibleParamertsForLicencetype = new List<string>(4);
            foreach (eLicenceType licenceType in Enum.GetValues(typeof(eLicenceType)))
            {
                possibleParamertsForLicencetype.Add(licenceType.ToString());
            }

            uniqueParameters.Add("licenceType", possibleParamertsForLicencetype);
            uniqueParameters.Add("engineVolume", null);

            return uniqueParameters;
        }

        public override string ToString()
        {
            StringBuilder returnString = new StringBuilder();
            returnString.Append(base.ToString());
            returnString.Append(string.Format(
@"Licence Type : {0}
Engine Volume : {1}", m_LicenceType, m_EngineVolume
            ));

            return returnString.ToString();
        }
    }
}
