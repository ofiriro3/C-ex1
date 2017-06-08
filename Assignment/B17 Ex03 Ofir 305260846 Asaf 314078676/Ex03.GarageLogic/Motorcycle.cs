using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {

        private eLicenceType m_LicenceType;
        private int m_EngineVolume;
		private const int m_NumOfWheels = 2;
        public enum eLicenceType
        {
            A,
            AB,
            A2,
            B1
        }

        public Motorcycle(string i_ModuleName, string i_LicensePlate, eLicenceType i_LicenceType, int i_EngineVolume,
		   List<Wheel> i_Wheels, PowerSource i_PowerSource) 
            : base(i_ModuleName, i_LicensePlate, i_Wheels, i_PowerSource)
        {
            m_LicenceType = i_LicenceType;
            m_EngineVolume = i_EngineVolume;
		}
    }
}
