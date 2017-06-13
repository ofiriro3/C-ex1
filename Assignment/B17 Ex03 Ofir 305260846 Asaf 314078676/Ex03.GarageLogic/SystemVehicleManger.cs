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
        /**
        public abstract class SupportedVehicle
        {
            public e_TypeOfVehicle Type { get; set; }
            public int NumberOfWheels {get; set; }
            public int MaxWheelPressure { get; set; }
			public SupportedVehicle(e_TypeOfVehicle i_Type, int i_NumberOfWheels, int i_MaxWheelPressure)
            {
                Type = i_Type;
                NumberOfWheels = i_NumberOfWheels;
                MaxWheelPressure = i_MaxWheelPressure;
            }
        }

		public class GasSupportedVehicle : SupportedVehicle
		{
			public float GasTankCapacity { get; set; }
            public PowerSource.eFuel GasType { get; set; }
			public GasSupportedVehicle(e_TypeOfVehicle i_Type, int i_NumberOfWheels, int i_MaxWheelPressure, float i_GasTankCapacity,
                                      PowerSource.eFuel i_GasType) : base(i_Type, i_NumberOfWheels, i_MaxWheelPressure)
			{
                GasTankCapacity = i_GasTankCapacity;
                GasType = i_GasType;
			}

		}

		public class ElectricSupportedVehicle : SupportedVehicle
		{
			public float BatteryCapacity { get; set; }
			public ElectricSupportedVehicle(e_TypeOfVehicle i_Type, int i_NumberOfWheels, int i_MaxWheelPressure, float i_BatteryCapacity)
                : base(i_Type, i_NumberOfWheels, i_MaxWheelPressure)
            {
                BatteryCapacity = i_BatteryCapacity;
			}
		}

        public static List<SupportedVehicle> GetSupportedVehicle()
        {
            List<SupportedVehicle> supportredVehicles = new List<SupportedVehicle>();

            supportredVehicles.Add(new GasSupportedVehicle(e_TypeOfVehicle.MotorcycleOnFuel, 2, 33, 5.5f, PowerSource.eFuel.Octan95));
            supportredVehicles.Add(new GasSupportedVehicle(e_TypeOfVehicle.CarOnFuel, 4, 30, 42f, PowerSource.eFuel.Octan98));
            supportredVehicles.Add(new GasSupportedVehicle(e_TypeOfVehicle.Truck, 12, 32, 135f, PowerSource.eFuel.Octan96));
            supportredVehicles.Add(new ElectricSupportedVehicle(e_TypeOfVehicle.MotorcycleOnBattey, 2, 33, 2.7f));
            supportredVehicles.Add(new ElectricSupportedVehicle(e_TypeOfVehicle.CarOnBattry, 4, 30, 2.5f));

            return supportredVehicles;
        }
        **/

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