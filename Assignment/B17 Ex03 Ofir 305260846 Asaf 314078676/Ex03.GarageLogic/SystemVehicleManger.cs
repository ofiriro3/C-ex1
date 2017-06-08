using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class SystemVehicleManger
    {



        public static bool FindCarByLicensePlate(Garage io_Garage,string i_id)
        {
            bool isExist = false;
            foreach (string id in io_Garage.GetListOfLicensePlateNumbersOfVehiclesInGarage())
            {
                if(id == i_id)
                {
                    io_Garage.ChangeStateOfVehicle(i_id, Garage.GarageVehicle.eVehicleStatus.InRepair);
                    isExist = true;
                    break;
                }
            }

            return isExist;
        }
    }
}
