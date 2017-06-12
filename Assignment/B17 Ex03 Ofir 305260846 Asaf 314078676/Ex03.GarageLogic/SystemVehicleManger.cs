using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class SystemVehicleManger
    {

        public static void createVehicleInGarage(Garage io_Garage, List<string> generalDetails, List<float> i_PowerSourceDetails,
            List<Wheel> i_Wheels, List<string> i_VehicleDetails, e_TypeOfVehicle typeOfVehicle)
        {
            // license module owner cellphone
            string i_vehicleLicense = generalDetails[0];
            string carModule = generalDetails[1];
            string owner = generalDetails[2];
            string i_CellphoneNumber = generalDetails[3];
            float i_currentPowerInPowerSource = i_PowerSourceDetails[0];

            switch (typeOfVehicle)
            {
                // in both cases do the same
                case e_TypeOfVehicle.CarOnBattry:
                    createAElectricCar(io_Garage, owner, carModule, i_vehicleLicense,
                    i_CellphoneNumber, i_currentPowerInPowerSource, i_Wheels, i_VehicleDetails); break;

                case e_TypeOfVehicle.CarOnFuel:
                    createARegularCar(io_Garage, owner, carModule, i_vehicleLicense,
                    i_CellphoneNumber, i_currentPowerInPowerSource, i_Wheels, i_VehicleDetails); break;

                case e_TypeOfVehicle.MotorcycleOnFuel:
                    createARegularMotorCycle(io_Garage, owner, carModule,
                    i_vehicleLicense, i_CellphoneNumber, i_currentPowerInPowerSource, i_Wheels, i_VehicleDetails); break;

                case e_TypeOfVehicle.MotorcycleOnBattey:
                    createAnElectricMotorCycle(io_Garage, owner, carModule,
                    i_vehicleLicense, i_CellphoneNumber, i_currentPowerInPowerSource, i_Wheels, i_VehicleDetails); break;

                case e_TypeOfVehicle.Truck:
                    createATruck(io_Garage, owner, carModule,
                    i_vehicleLicense, i_CellphoneNumber, i_currentPowerInPowerSource, i_Wheels, i_VehicleDetails); break;

            }
        }

        private static void createATruck(Garage io_Garage, string i_Owner, string i_Module, string i_vehicleLicense,
            string i_CellphoneNumber, float i_currentPowerInPowerSource, List<Wheel> i_Wheels, List<string> i_VehicleDetails)
        {
            FuelTank fuelTank = new FuelTank(135f, i_currentPowerInPowerSource, PowerSource.eFuel.Octan96);
            bool isToxic = bool.Parse(i_VehicleDetails[0]);
            float maxCarryWeight = float.Parse(i_VehicleDetails[1]);
            Truck truckToAdd = new Truck(i_Module, i_vehicleLicense, isToxic, maxCarryWeight, i_Wheels, fuelTank);

            Garage.GarageVehicle truckToAddToGarage = new Garage.GarageVehicle(i_Owner, i_CellphoneNumber,
                Garage.GarageVehicle.eVehicleStatus.InRepair, truckToAdd);
            io_Garage.addNewVehicleToGarage(truckToAddToGarage);

        }

        private static void createAnElectricMotorCycle(Garage io_Garage, string i_Owner, string i_Module, string i_vehicleLicense,
            string i_CellphoneNumber, float i_currentPowerInPowerSource, List<Wheel> i_i_Wheels, List<string> i_VehicleDetails)
        {
            Battery battery = new Battery(2.7f, i_currentPowerInPowerSource);
            Motorcycle.eLicenceType licenceType = (Motorcycle.eLicenceType)(Enum.Parse(typeof(Motorcycle.eLicenceType), i_VehicleDetails[0]));

            // maybe add a try/catch fo this
            int engineVolume = int.Parse(i_VehicleDetails[1]);
            Motorcycle motorcycleToAdd = new Motorcycle(i_Module, i_vehicleLicense, licenceType, engineVolume, i_i_Wheels, battery);

            Garage.GarageVehicle motorCycleToAddToGarage = new Garage.GarageVehicle(i_Owner, i_CellphoneNumber,
                Garage.GarageVehicle.eVehicleStatus.InRepair, motorcycleToAdd);
            io_Garage.addNewVehicleToGarage(motorCycleToAddToGarage);
        }

        private static void createARegularMotorCycle(Garage io_Garage, string i_Owner, string i_Module, string i_vehicleLicense, string i_CellphoneNumber, float i_currentPowerInPowerSource, List<Wheel> i_Wheels, List<string> i_VehicleDetails)
        {
            FuelTank fuelTank = new FuelTank(5.5f, i_currentPowerInPowerSource, PowerSource.eFuel.Octan95);
            Motorcycle.eLicenceType licenceType = (Motorcycle.eLicenceType)(Enum.Parse(typeof(Motorcycle.eLicenceType), i_VehicleDetails[0]));

            // maybe add a try/catch fo this
            int engineVolume = int.Parse(i_VehicleDetails[1]);
            //add engine valume
            Motorcycle motorcycleToAdd = new Motorcycle(i_Module, i_vehicleLicense, licenceType, engineVolume, i_Wheels, fuelTank);

            Garage.GarageVehicle motorCycleToAddToGarage = new Garage.GarageVehicle(i_Owner, i_CellphoneNumber,
                Garage.GarageVehicle.eVehicleStatus.InRepair, motorcycleToAdd);
            io_Garage.addNewVehicleToGarage(motorCycleToAddToGarage);

        }

        private static void createAElectricCar(Garage io_Garage, string i_Owner, string i_Module,
            string i_vehicleLicense, string i_CellphoneNumber, float i_currentPowerInPowerSource, List<Wheel> i_Wheels, List<string> i_VehicleDetails)
        {
            Battery battery = new Battery(2.5f, i_currentPowerInPowerSource);
            string motorcycleLicenceType = i_VehicleDetails[0];
            Car.eColor color = (Car.eColor)(Enum.Parse(typeof(Car.eColor), i_VehicleDetails[0]));
            Car.eNumberOfDoors numberOfDoors = (Car.eNumberOfDoors)(Enum.Parse(typeof(Car.eNumberOfDoors), i_VehicleDetails[1]));
            Car carToAdd = new Car(i_Module, i_vehicleLicense,color, numberOfDoors, i_Wheels, battery);

            Garage.GarageVehicle carToAddToGarage = new Garage.GarageVehicle(i_Owner, i_CellphoneNumber,
                Garage.GarageVehicle.eVehicleStatus.InRepair, carToAdd);
            io_Garage.addNewVehicleToGarage(carToAddToGarage);

        }

        private static void createARegularCar(Garage io_Garage, string i_Owner, string i_Module,
            string i_vehicleLicense, string i_CellphoneNumber, float i_currentPowerInPowerSource, 
            List<Wheel> i_Wheels, List<string> i_VehicleDetails)
        {
            FuelTank fuelTank = new FuelTank(42f, i_currentPowerInPowerSource, PowerSource.eFuel.Octan98);
            Car.eColor color = (Car.eColor)(Enum.Parse(typeof(Car.eColor), i_VehicleDetails[0]));
            Car.eNumberOfDoors numberOfDoors = (Car.eNumberOfDoors)(Enum.Parse(typeof(Car.eNumberOfDoors), i_VehicleDetails[1]));
            Car carToAdd = new Car(i_Module, i_vehicleLicense, color, numberOfDoors, i_Wheels, fuelTank);

            Garage.GarageVehicle carToAddToGarage = new Garage.GarageVehicle(i_Owner, i_CellphoneNumber,
                Garage.GarageVehicle.eVehicleStatus.InRepair, carToAdd);
            io_Garage.addNewVehicleToGarage(carToAddToGarage);

        }
    }

} 