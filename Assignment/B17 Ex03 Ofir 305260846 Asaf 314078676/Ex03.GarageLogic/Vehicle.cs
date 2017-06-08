using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;
using Wheel = Ex03.GarageLogic.Wheel;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModuleName;
        protected string m_LicensePlate;
        protected float m_RemainingPower;
        protected List<Wheel> m_Wheels;
        protected PowerSource m_PowerSource;
        protected readonly int r_NumberOfWheels;

		public Vehicle(string i_ModuleName, string i_LicensePlate, List<Wheel> i_Wheels, PowerSource i_PowerSource, int i_NumberOfWheels)
        {
			m_ModuleName = i_ModuleName;
			m_LicensePlate = i_LicensePlate;
			m_Wheels = i_Wheels;
			m_PowerSource = i_PowerSource;
            r_NumberOfWheels = i_NumberOfWheels;
        }


		public string ModuleName
		{
            get
            {
                return m_ModuleName;  
            }
		}

		public string LicensePlate
		{
			get
			{
				return m_LicensePlate;
			}
		}
    }
}
