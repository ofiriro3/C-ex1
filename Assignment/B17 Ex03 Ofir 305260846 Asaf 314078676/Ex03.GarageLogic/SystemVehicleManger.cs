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

        public static void createElectricMotorCycle(Garage io_Garage, List<string> generalDetails, List<float> electricalDetails, 
                                                List<Wheel> i_Wheels,List<Object>motorcycleDetails)
        {

            // CarID , car module , vehicleLicense , owner ,CellPhonenumber float powerLeft
            string owner = generalDetails[0];
            string carModule = generalDetails[1];
            string vehicleLicense = generalDetails[2];
            string cellphoneNumber = generalDetails[3];
            float powerLeftInBattery = electricalDetails[0];
            Battery battery = new Battery(2.7f, powerLeftInBattery);
            string motorcycleLicenceType = motorcycleDetails[0] as string;
            if (motorcycleLicenceType == null)
            {
                throw new FormatException("You gave unvalid motorcycle Licence Type ");
            }
            // maybe add a try/catch fo this
            int engineVolume = (int) motorcycleDetails[1] ;
            //add engine valume
            Motorcycle motorcycleToAdd = new Motorcycle(carModule, vehicleLicense, motorcycleLicenceType, engineVolume, i_Wheels, battery);

            Garage.GarageVehicle motorCycleToAddToGarage = new Garage.GarageVehicle(owner, cellphoneNumber, 
                Garage.GarageVehicle.eVehicleStatus.InRepair, motorcycleToAdd);
            io_Garage.addNewVehicleToGarage(motorCycleToAddToGarage);
        }
        
        public static void createVehicleInGarage(Garage io_Garage, List<string> generalDetails, List<float> powerSourceDeatails, 
            List<Wheel> wheels, List<string> vehicleDetails, e_TypeOfVehicle typeOfVehicle)
        {
            string owner = generalDetails[0];
            string carModule = generalDetails[1];
            string vehicleLicense = generalDetails[2];
            string cellphoneNumber = generalDetails[3];
            float currentPowerInPowerSource = powerSourceDeatails[0];

            switch (typeOfVehicle)
            {
                // in both cases do the same
                case e_TypeOfVehicle.CarOnBattry:createAElectricCar(io_Garage, owner, carModule, vehicleLicense,
                    cellphoneNumber, currentPowerInPowerSource, wheels, vehicleDetails);break;

                case e_TypeOfVehicle.CarOnFuel: createARegularCar(io_Garage, owner, carModule, vehicleLicense, 
                    cellphoneNumber, currentPowerInPowerSource, wheels, vehicleDetails); break;

                case e_TypeOfVehicle.MotorcycleOnFuel:createARegularMotorCycle(io_Garage, owner, carModule,
                    vehicleLicense, cellphoneNumber, currentPowerInPowerSource,wheels, vehicleDetails); break;

                case e_TypeOfVehicle.MotorcycleOnBattey:createAnElectricMotorCycle(io_Garage, owner, carModule, 
                    vehicleLicense, cellphoneNumber, currentPowerInPowerSource,wheels, vehicleDetails); break;

                case e_TypeOfVehicle.Truck:createATruck(io_Garage, owner, carModule,
                vehicleLicense, cellphoneNumber, currentPowerInPowerSource, wheels, vehicleDetails); break;

            }
    }

        private static void createATruck(Garage io_Garage, string owner, string carModule, string vehicleLicense, string cellphoneNumber, float currentPowerInPowerSource, List<Wheel> wheels, List<string> vehicleDetails)
        {
            
        }

        private static void createAnElectricMotorCycle(Garage io_Garage, string owner, string carModule, string vehicleLicense, string cellphoneNumber, float currentPowerInPowerSource, List<Wheel> wheels, List<string> vehicleDetails)
        {
            throw new NotImplementedException();
        }

        private static void createARegularMotorCycle(Garage io_Garage, string owner, string carModule, string vehicleLicense, string cellphoneNumber, float currentPowerInPowerSource, List<Wheel> wheels, List<string> vehicleDetails)
        {
            FuelTank fuelTank = new FuelTank(5.5f, currentPowerInPowerSource, PowerSource.eFuel.Octan95);
            string motorcycleLicenceType = vehicleDetails[0] ;
            if (motorcycleLicenceType == null)
            {
                throw new FormatException("You gave unvalid motorcycle Licence Type ");
            }
            // maybe add a try/catch fo this
            int engineVolume = int.Parse(vehicleDetails[1]);
            //add engine valume
            Motorcycle motorcycleToAdd = new Motorcycle(carModule, vehicleLicense, motorcycleLicenceType, engineVolume, i_Wheels, fuelTank);

            Garage.GarageVehicle motorCycleToAddToGarage = new Garage.GarageVehicle(owner, cellphoneNumber,
                Garage.GarageVehicle.eVehicleStatus.InRepair, motorcycleToAdd);
            io_Garage.addNewVehicleToGarage(motorCycleToAddToGarage);

        }

        private static void createARegularCar(Garage io_Garage, string owner, string carModule,
            string vehicleLicense, string cellphoneNumber, float currentPowerInPowerSource, List<Wheel> wheels, List<string> vehicleDetails)
        {
        }

            private static void createAElectricCar(Garage io_Garage, string owner, string carModule, 
            string vehicleLicense, string cellphoneNumber, float currentPowerInPowerSource, List<Wheel> wheels, List<string> vehicleDetails)
        {
        }
    }

    