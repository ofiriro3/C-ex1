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

        public override string ToString()
        {
            StringBuilder returnString = new StringBuilder();
            returnString.Append(base.ToString());
            returnString.Append(String.Format(
                @"Licence Type : {0}
                Engine Volume : {1}", m_LicenceType, m_EngineVolume
            ));

            return returnString.ToString();
        }


    }
}
