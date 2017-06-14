﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        public enum eColor
        {
            Yellow,
            While,
            Black,
            Blue
        }

        public enum eNumberOfDoors
        {
            Two, 
            Three,
            Four,
            Five
        } 

        public Car(string i_ModuleName, string i_LicensePlate, eColor i_Color, eNumberOfDoors i_NumberOfDoors, 
                   List<Wheel> i_Wheels, PowerSource i_PowerSource) 
            : base(i_ModuleName, i_LicensePlate, i_Wheels, i_PowerSource,4)
        {
            m_Color = i_Color;
            m_NumberOfDoors = i_NumberOfDoors;
        }

		public override string ToString()
		{
			StringBuilder returnString = new StringBuilder();
			returnString.Append(base.ToString());
			returnString.Append(string.Format(
@"Color : {0}
Number of doors : {1}
", m_Color, m_NumberOfDoors
			));

			return returnString.ToString();
		}
    }
}