using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        List<GarageVehicle> m_Vehicles;


        public Garage()
        {
            m_Vehicles = new List<GarageVehicle>();
        }

        public class GarageVehicle
        {
            private string m_OwnerName;
            private string m_OwnerNumber;
            private eVehicleStatus m_Status;
            Vehicle m_Vehicle;

            public enum eVehicleStatus
            {
                InRepair,
                Repaired,
                Paid
            }

            public GarageVehicle(string i_OwnerName, string i_OwnerNumber, eVehicleStatus i_Status, Vehicle i_Vehicle)
            {
                m_OwnerName = i_OwnerName;
                m_OwnerNumber = i_OwnerNumber;
                m_Status = i_Status;
                m_Vehicle = i_Vehicle;
            }

        }

        public void PrintListOfLicensePlateNumbersOfVehiclesInGarage(GarageVehicle.eVehicleStatus i_VehicleStatus)
        {
            foreach(GarageVehicle vehicle in m_Vehicles)
            {
                
            }
        }
    }
}
