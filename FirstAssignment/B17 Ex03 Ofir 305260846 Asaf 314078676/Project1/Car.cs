using System;
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
            Four
        }
        
    }
}
