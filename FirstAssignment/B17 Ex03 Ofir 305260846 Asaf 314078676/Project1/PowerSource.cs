using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class PowerSource
    {
        private readonly float r_MaxCampacity;
        private float currentCampacity;
        public enum eFuel
        {
            Soler,
            Octan95,
            Ocatan96,
            Octan98
        }
        
    }
}
