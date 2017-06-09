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

        public List<Wheel> Wheels
		{
			get
			{
				return m_Wheels;
			}
		}

		public PowerSource PowerSource
		{
			get
			{
                return m_PowerSource;
			}
		}

        public override string ToString(){
            StringBuilder returnString = new StringBuilder();
            int indexOfWheel = 0;

            returnString.Append(String.Format(
@"Module Name : {0}
License Plate : {1}", m_ModuleName, m_LicensePlate));
            foreach(Wheel wheel in m_Wheels)
            {
                returnString.AppendLine(String.Format("Wheel {0} : ", indexOfWheel));
                returnString.Append(wheel.ToString());
                indexOfWheel++;
            }

            returnString.Append(m_PowerSource.GetType().GetMethod("ToString").Invoke(m_PowerSource, null));

            return returnString.ToString();
        }
    }
}
