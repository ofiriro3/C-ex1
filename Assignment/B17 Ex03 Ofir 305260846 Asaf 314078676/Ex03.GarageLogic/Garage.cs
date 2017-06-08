using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        List<GarageVehicle> m_Vehicles;



        private class GarageVehicle
        {
            private string m_OwnerName;
            private string m_OwnerNumber;
            private eVehicleStatus m_Status;

            public enum eVehicleStatus
            {
                InRepair,
                Repaired,
                Paid
            }
        }
    }
}
