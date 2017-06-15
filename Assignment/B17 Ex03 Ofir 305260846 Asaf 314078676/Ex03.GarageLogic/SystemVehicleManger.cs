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

        public static Dictionary<Type, List<e_TypeOfPowerSource>> GetSupportedVehicle()
        {
            Dictionary<Type, List<e_TypeOfPowerSource>> supportredVehicles = new Dictionary<Type, List<e_TypeOfPowerSource>>();
            List<e_TypeOfPowerSource> carPowerSourceOptions = new List<e_TypeOfPowerSource>(2);
            List<e_TypeOfPowerSource> motorcyclePowerSorceOptions = new List<e_TypeOfPowerSource>(2);
            List<e_TypeOfPowerSource> truckPowerSorceOptions = new List<e_TypeOfPowerSource>(1);
            carPowerSourceOptions.Add(e_TypeOfPowerSource.FuelTank);
            carPowerSourceOptions.Add(e_TypeOfPowerSource.Battery);
            motorcyclePowerSorceOptions.Add(e_TypeOfPowerSource.FuelTank);
            motorcyclePowerSorceOptions.Add(e_TypeOfPowerSource.Battery);
            truckPowerSorceOptions.Add(e_TypeOfPowerSource.FuelTank);

            supportredVehicles.Add(typeof (Car),carPowerSourceOptions);
            supportredVehicles.Add(typeof(Motorcycle),motorcyclePowerSorceOptions );
            supportredVehicles.Add(typeof(Truck), truckPowerSorceOptions);

            return supportredVehicles;
        }

        public static Dictionary<string, List<string>> getVehicleUniqeProperties(Type typeOfVehicle)
        {
            Dictionary<string, List<string>> uniqeProperties = (Dictionary < string, List<string> > ) typeOfVehicle.GetMethod("GetUniqueParameters").Invoke(null, null);

            return uniqeProperties;
        }

        public static void createVehicleInGarage(Garage io_Garage,  List<string> generalDetails, List<float> i_PowerSourceDetails,
            List<string> i_Wheels, Dictionary <string,string> i_VehicleDetails, Type typeOfVehicle, e_TypeOfPowerSource powerSource)
        {
            //dic of two stringsList
            // license module owner cellphone
            string i_vehicleLicense = generalDetails[0];
            string carModule = generalDetails[1];
            string owner = generalDetails[2];
            string i_CellphoneNumber = generalDetails[3];
            float i_currentPowerInPowerSource = i_PowerSourceDetails[0];

            if (typeOfVehicle == typeof(Car))
            {
                if (powerSource.Equals(e_TypeOfPowerSource.FuelTank))
                {
                    createARegularCar(io_Garage, owner, carModule, i_vehicleLicense,
                        i_CellphoneNumber, i_currentPowerInPowerSource, i_Wheels, i_VehicleDetails);

                }
                else
                {
                    createAElectricCar(io_Garage, owner, carModule, i_vehicleLicense,
                        i_CellphoneNumber, i_currentPowerInPowerSource, i_Wheels, i_VehicleDetails);
                }
            }
            else if (typeOfVehicle == typeof(Motorcycle))
            {
                if (powerSource.Equals(e_TypeOfPowerSource.FuelTank))
                {
                    createARegularMotorCycle(io_Garage, owner, carModule, i_vehicleLicense,
                        i_CellphoneNumber, i_currentPowerInPowerSource, i_Wheels, i_VehicleDetails);

                }
                else
                {
                    createAnElectricMotorCycle(io_Garage, owner, carModule,
                    i_vehicleLicense, i_CellphoneNumber, i_currentPowerInPowerSource, i_Wheels, i_VehicleDetails); 

                }

            }
            else
            {
                createATruck(io_Garage, owner, carModule,
                    i_vehicleLicense, i_CellphoneNumber, i_currentPowerInPowerSource, i_Wheels, i_VehicleDetails); 

            }
        }

        private static void createATruck(Garage io_Garage, string i_Owner, string i_Module, string i_vehicleLicense,
            string i_CellphoneNumber, float i_currentPowerInPowerSource, List<string> i_Wheels, Dictionary<string, string> i_VehicleDetails)
        {
            FuelTank fuelTank = new FuelTank(135f, i_currentPowerInPowerSource, PowerSource.eFuel.Octan96);
            string valueOfToxic;
            i_VehicleDetails.TryGetValue("carriesToxic", out valueOfToxic);
            bool isToxic = bool.Parse(valueOfToxic);
            string valueOfCarrayWeight;
            i_VehicleDetails.TryGetValue("maxCarryWeight",out valueOfCarrayWeight);
            float maxCarryWeight = float.Parse(valueOfCarrayWeight);
            if( maxCarryWeight > 0)
            {
                throw new FormatException("Cannot put negative value in the max Carry weight of the truck");
            }
            List<Wheel> wheels = generateWheels(12, 32, i_Wheels[0], i_Wheels[1]);
            Truck truckToAdd = new Truck(i_Module, i_vehicleLicense, isToxic, maxCarryWeight, wheels, fuelTank);
            Garage.GarageVehicle truckToAddToGarage = new Garage.GarageVehicle(i_Owner, i_CellphoneNumber,
                Garage.GarageVehicle.eVehicleStatus.InRepair, truckToAdd);
            io_Garage.addNewVehicleToGarage(truckToAddToGarage);
        }

        private static void createAnElectricMotorCycle(Garage io_Garage, string i_Owner, string i_Module, string i_vehicleLicense,
            string i_CellphoneNumber, float i_currentPowerInPowerSource, List<string> i_Wheels, Dictionary<string, string> i_VehicleDetails)
        {
            Battery battery = new Battery(2.7f, i_currentPowerInPowerSource);
            string licenceTypeValue;
            i_VehicleDetails.TryGetValue("licenceType", out licenceTypeValue);
            string engineVolumeValue;
            i_VehicleDetails.TryGetValue("engineVolume", out engineVolumeValue);
            Motorcycle.eLicenceType licenceType = (Motorcycle.eLicenceType)(Enum.Parse(typeof(Motorcycle.eLicenceType), engineVolumeValue));
            int engineVolume = int.Parse(engineVolumeValue);
            if( engineVolume > 0 )
            {
                throw new FormatException();
            }
			List<Wheel> wheels = generateWheels(2, 33, i_Wheels[0], i_Wheels[1]);
            Motorcycle motorcycleToAdd = new Motorcycle(i_Module, i_vehicleLicense, licenceType, engineVolume, wheels, battery);
            Garage.GarageVehicle motorCycleToAddToGarage = new Garage.GarageVehicle(i_Owner, i_CellphoneNumber,
                Garage.GarageVehicle.eVehicleStatus.InRepair, motorcycleToAdd);
            io_Garage.addNewVehicleToGarage(motorCycleToAddToGarage);
        }

        private static void createARegularMotorCycle(Garage io_Garage, string i_Owner, string i_Module, string i_vehicleLicense, 
            string i_CellphoneNumber, float i_currentPowerInPowerSource, List<string> i_Wheels, Dictionary<string, string> i_VehicleDetails)
        {
            FuelTank fuelTank = new FuelTank(5.5f, i_currentPowerInPowerSource, PowerSource.eFuel.Octan95);
            string licenceTypeValue;
            i_VehicleDetails.TryGetValue("licenceType", out licenceTypeValue);
            string engineVolumeValue;
            i_VehicleDetails.TryGetValue("engineVolume", out engineVolumeValue);
            Motorcycle.eLicenceType licenceType = (Motorcycle.eLicenceType)(Enum.Parse(typeof(Motorcycle.eLicenceType), licenceTypeValue));
            int engineVolume = int.Parse(engineVolumeValue);
            if (engineVolume > 0)
            {
                throw new FormatException();
            }
            List<Wheel> wheels = generateWheels(2, 33, i_Wheels[0], i_Wheels[1]);
            Motorcycle motorcycleToAdd = new Motorcycle(i_Module, i_vehicleLicense, licenceType, engineVolume, wheels, fuelTank);
            Garage.GarageVehicle motorCycleToAddToGarage = new Garage.GarageVehicle(i_Owner, i_CellphoneNumber,
                Garage.GarageVehicle.eVehicleStatus.InRepair, motorcycleToAdd);
            io_Garage.addNewVehicleToGarage(motorCycleToAddToGarage);
        }

        private static void createAElectricCar(Garage io_Garage, string i_Owner, string i_Module,
            string i_vehicleLicense, string i_CellphoneNumber, float i_currentPowerInPowerSource, List<string> i_Wheels,
            Dictionary<string, string> i_VehicleDetails)
        {
            Battery battery = new Battery(2.5f, i_currentPowerInPowerSource);
            string colorValue;
            i_VehicleDetails.TryGetValue("color", out colorValue);
            string numberOfDoorsValue;
            i_VehicleDetails.TryGetValue("numberOfDoors", out numberOfDoorsValue);

            Car.eColor color = (Car.eColor)(Enum.Parse(typeof(Car.eColor), colorValue));
            Car.eNumberOfDoors numberOfDoors = (Car.eNumberOfDoors)(Enum.Parse(typeof(Car.eNumberOfDoors), numberOfDoorsValue));
			List<Wheel> wheels = generateWheels(4, 30, i_Wheels[0], i_Wheels[1]);
            Car carToAdd = new Car(i_Module, i_vehicleLicense,color, numberOfDoors, wheels, battery);
            Garage.GarageVehicle carToAddToGarage = new Garage.GarageVehicle(i_Owner, i_CellphoneNumber,
                Garage.GarageVehicle.eVehicleStatus.InRepair, carToAdd);
            io_Garage.addNewVehicleToGarage(carToAddToGarage);
        }

        private static void createARegularCar(Garage io_Garage, string i_Owner, string i_Module,
            string i_vehicleLicense, string i_CellphoneNumber, float i_currentPowerInPowerSource, 
            List<string> i_Wheels, Dictionary<string, string> i_VehicleDetails)
        {
            FuelTank fuelTank = new FuelTank(42f, i_currentPowerInPowerSource, PowerSource.eFuel.Octan98);
            string colorValue;
            i_VehicleDetails.TryGetValue("color", out colorValue);
            string numberOfDoorsValue;
            i_VehicleDetails.TryGetValue("numberOfDoors", out numberOfDoorsValue);
            Car.eColor color = (Car.eColor)(Enum.Parse(typeof(Car.eColor), colorValue));
            Car.eNumberOfDoors numberOfDoors = (Car.eNumberOfDoors)(Enum.Parse(typeof(Car.eNumberOfDoors), numberOfDoorsValue));
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