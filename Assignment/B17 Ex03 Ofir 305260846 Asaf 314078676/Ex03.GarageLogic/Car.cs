using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;
        private string carModule;
        private string vehicleLicense;
        private string color;
        private int numberOfDoors;
        private List<Wheel> wheels;
        private FuelTank fuelTank;

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
            Four
        } 

        public Car(string i_ModuleName, string i_LicensePlate, eColor i_Color, eNumberOfDoors i_NumberOfDoors, 
                   List<Wheel> i_Wheels, PowerSource i_PowerSource) 
            : base(i_ModuleName, i_LicensePlate, i_Wheels, i_PowerSource)
        {
            m_Color = i_Color;
            m_NumberOfDoors = i_NumberOfDoors;
        }

        public Car(string carModule, string vehicleLicense, string color, int numberOfDoors, List<Wheel> wheels, PowerSource i_PowerSource)
        {
            //TODO
            // covert numberOfDoors to enum and throws execption in case of an invalid input
            //same for color
        }
    }
}
