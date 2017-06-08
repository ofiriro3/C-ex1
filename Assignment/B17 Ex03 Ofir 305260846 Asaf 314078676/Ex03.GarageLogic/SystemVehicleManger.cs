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

        public static void createRegularMotorCycle(Garage io_Garage, List<string> generalDetails, List<float> electricalDetails, List<Wheel> wheelList)
        {

            // CarID , car module , vehicleLicense , owner ,CellPhonenumber float powerLeft
            string owner = generalDetails[0];
            string carModule = generalDetails[1];
            string vehicleLicense = generalDetails[2];
            string cellphoneNumber = generalDetails[3];
            float powerLeftInBattery = electricalDetails[0];
            string motorcycleLicenceType = Console.ReadLine();
            string l
            Motorcycle motorcycleToAdd = new Motorcycle(carModule,vehicleLicense, motorcycleLicenceType, )

            Garage.GarageVehicle motorCycleToAddToGarage  = new Garage.GarageVehicle()
        }
    }
}
