using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class SystemVehicleManger
    {
		public enum e_TypeOfVehicle
		{
			CarOnFuel,
			CarOnBattry,
			MotorcycleOnBattey,
			MotorcycleOnFuel,
			Truck
		}

        public enum e_TypeOfPowerSource
        {
            Battery,
            FuelTank
        }

        public static Dictionary<e_TypeOfVehicle, e_TypeOfPowerSource> GetSupportedVehicle()
        {
            Dictionary<e_TypeOfVehicle, e_TypeOfPowerSource> supportredVehicles = new Dictionary<e_TypeOfVehicle, e_TypeOfPowerSource>();
            supportredVehicles.Add(e_TypeOfVehicle.CarOnBattry, e_TypeOfPowerSource.Battery);
            supportredVehicles.Add(e_TypeOfVehicle.MotorcycleOnBattey, e_TypeOfPowerSource.Battery);
            supportredVehicles.Add(e_TypeOfVehicle.CarOnFuel, e_TypeOfPowerSource.FuelTank);
            supportredVehicles.Add(e_TypeOfVehicle.MotorcycleOnFuel, e_TypeOfPowerSource.FuelTank);
            supportredVehicles.Add(e_TypeOfVehicle.Truck, e_TypeOfPowerSource.FuelTank);

            return supportredVehicles;
        }

        public static void createVehicleInGarage(Garage io_Garage, List<string> generalDetails, List<float> i_PowerSourceDetails,
            List<string> i_Wheels, List<string> i_VehicleDetails, e_TypeOfVehicle typeOfVehicle)
        {
            // license module owner cellphone
            string i_vehicleLicense = generalDetails[0];
            string carModule = generalDetails[1];
            string owner = generalDetails[2];
            string i_CellphoneNumber = generalDetails[3];
            float i_currentPowerInPowerSource = i_PowerSourceDetails[0];

            switch (typeOfVehicle)
            {
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
            string i_CellphoneNumber, float i_currentPowerInPowerSource, List<string> i_Wheels, List<string> i_VehicleDetails)
        {
            FuelTank fuelTank = new FuelTank(135f, i_currentPowerInPowerSource, PowerSource.eFuel.Octan96);
            bool isToxic = bool.Parse(i_VehicleDetails[0]);
            float maxCarryWeight = float.Parse(i_VehicleDetails[1]);
            List<Wheel> wheels = generateWheels(12, 32, i_Wheels[0], i_Wheels[1]);
            Truck truckToAdd = new Truck(i_Module, i_vehicleLicense, isToxic, maxCarryWeight, wheels, fuelTank);
            Garage.GarageVehicle truckToAddToGarage = new Garage.GarageVehicle(i_Owner, i_CellphoneNumber,
                Garage.GarageVehicle.eVehicleStatus.InRepair, truckToAdd);
            io_Garage.addNewVehicleToGarage(truckToAddToGarage);
        }

        private static void createAnElectricMotorCycle(Garage io_Garage, string i_Owner, string i_Module, string i_vehicleLicense,
            string i_CellphoneNumber, float i_currentPowerInPowerSource, List<string> i_Wheels, List<string> i_VehicleDetails)
        {
            Battery battery = new Battery(2.7f, i_currentPowerInPowerSource);
            Motorcycle.eLicenceType licenceType = (Motorcycle.eLicenceType)(Enum.Parse(typeof(Motorcycle.eLicenceType), i_VehicleDetails[0]));
            int engineVolume = int.Parse(i_VehicleDetails[1]);
			List<Wheel> wheels = generateWheels(2, 33, i_Wheels[0], i_Wheels[1]);
            Motorcycle motorcycleToAdd = new Motorcycle(i_Module, i_vehicleLicense, licenceType, engineVolume, wheels, battery);
            Garage.GarageVehicle motorCycleToAddToGarage = new Garage.GarageVehicle(i_Owner, i_CellphoneNumber,
                Garage.GarageVehicle.eVehicleStatus.InRepair, motorcycleToAdd);
            io_Garage.addNewVehicleToGarage(motorCycleToAddToGarage);
        }

        private static void createARegularMotorCycle(Garage io_Garage, string i_Owner, string i_Module, string i_vehicleLicense, string i_CellphoneNumber, float i_currentPowerInPowerSource, List<string> i_Wheels, List<string> i_VehicleDetails)
        {
            FuelTank fuelTank = new FuelTank(5.5f, i_currentPowerInPowerSource, PowerSource.eFuel.Octan95);
            Motorcycle.eLicenceType licenceType = (Motorcycle.eLicenceType)(Enum.Parse(typeof(Motorcycle.eLicenceType), i_VehicleDetails[0]));
            int engineVolume = int.Parse(i_VehicleDetails[1]);
			List<Wheel> wheels = generateWheels(2, 33, i_Wheels[0], i_Wheels[1]);
            Motorcycle motorcycleToAdd = new Motorcycle(i_Module, i_vehicleLicense, licenceType, engineVolume, wheels, fuelTank);
            Garage.GarageVehicle motorCycleToAddToGarage = new Garage.GarageVehicle(i_Owner, i_CellphoneNumber,
                Garage.GarageVehicle.eVehicleStatus.InRepair, motorcycleToAdd);
            io_Garage.addNewVehicleToGarage(motorCycleToAddToGarage);
        }

        private static void createAElectricCar(Garage io_Garage, string i_Owner, string i_Module,
            string i_vehicleLicense, string i_CellphoneNumber, float i_currentPowerInPowerSource, List<string> i_Wheels, List<string> i_VehicleDetails)
        {
            Battery battery = new Battery(2.5f, i_currentPowerInPowerSource);
            Car.eColor color = (Car.eColor)(Enum.Parse(typeof(Car.eColor), i_VehicleDetails[0]));
            Car.eNumberOfDoors numberOfDoors = (Car.eNumberOfDoors)(Enum.Parse(typeof(Car.eNumberOfDoors), i_VehicleDetails[1]));
			List<Wheel> wheels = generateWheels(4, 30, i_Wheels[0], i_Wheels[1]);
            Car carToAdd = new Car(i_Module, i_vehicleLicense,color, numberOfDoors, wheels, battery);
            Garage.GarageVehicle carToAddToGarage = new Garage.GarageVehicle(i_Owner, i_CellphoneNumber,
                Garage.GarageVehicle.eVehicleStatus.InRepair, carToAdd);
            io_Garage.addNewVehicleToGarage(carToAddToGarage);
        }

        private static void createARegularCar(Garage io_Garage, string i_Owner, string i_Module,
            string i_vehicleLicense, string i_CellphoneNumber, float i_currentPowerInPowerSource, 
            List<string> i_Wheels, List<string> i_VehicleDetails)
        {
            FuelTank fuelTank = new FuelTank(42f, i_currentPowerInPowerSource, PowerSource.eFuel.Octan98);
            Car.eColor color = (Car.eColor)(Enum.Parse(typeof(Car.eColor), i_VehicleDetails[0]));
            Car.eNumberOfDoors numberOfDoors = (Car.eNumberOfDoors)(Enum.Parse(typeof(Car.eNumberOfDoors), i_VehicleDetails[1]));
			List<Wheel> wheels = generateWheels(12, 32, i_Wheels[0], i_Wheels[1]);
            Car carToAdd = new Car(i_Module, i_vehicleLicense, color, numberOfDoors, wheels, fuelTank);
            Garage.GarageVehicle carToAddToGarage = new Garage.GarageVehicle(i_Owner, i_CellphoneNumber,
                Garage.GarageVehicle.eVehicleStatus.InRepair, carToAdd);
            io_Garage.addNewVehicleToGarage(carToAddToGarage);

        }

		private static List<Wheel> generateWheels(int i_NumberOfWheels, float i_MaxTirePressure, string i_Manufactor, string i_CurrentWheelPressure)
		{
			List<Wheel> listOfWheels = new List<Wheel>();
    
			for (int i = 0; i < i_NumberOfWheels; i++)
			{
                float currentPressure = float.Parse(i_CurrentWheelPressure);
                Wheel currentWheelToCreate = new Wheel(i_Manufactor, currentPressure, i_MaxTirePressure);
				listOfWheels.Add(currentWheelToCreate);
			}

            return listOfWheels;
		}
    }

} 