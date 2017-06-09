using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using Garage = Ex03.GarageLogic.Garage;
using SystemVehicleManger = Ex03.GarageLogic.SystemVehicleManger;
using e_TypeOfVehicle = Ex03.GarageLogic.e_TypeOfVehicle;

namespace Ex03.ConsoleUI
{
    public static class UserInterfaceForGarage
    {
        public static void run()
        {
            Garage myGarage = new Garage();

            bool programIsRunning = true;
            while (programIsRunning)
            {
                Console.WriteLine(string.Format
(@"Please choose one of the folowing
Press 1 for add another Vehicle to the garage
Press 2 for print the License Plates of all cars that are now in the garage
Press 3 for change a car status in the garage
Press 4 to inflate one of the cars wheels
Press 5 to fuel a car
Press 6 to charge a battery of an electricity car
Press 7 for full details of a specific car"));

                int inputCommand;
                getValidInputFromUser(out inputCommand);
                switch (inputCommand)
                {
                    case -1: programIsRunning = false; break;
                    case 1: addNewCarToGarage(myGarage);break;
                    case 2: printCarList(myGarage); break;
                    case 3: changeCarStatus(myGarage); break;
                    case 4: inflateCarWheels(myGarage); break;
                    case 5: toFuelACar(myGarage); break;
                    case 6: toChargeAnElectricCar(myGarage); break;
                    case 7: printFullDetailsOfACar(myGarage); break;
                    default: Console.WriteLine("Invalid input , please choose a number between 0 - 7 "); break;
                }


            }
        }

        private static void printFullDetailsOfACar(Garage io_Garage)
        {
            throw new NotImplementedException();
        }

        private static void toChargeAnElectricCar(Garage io_Garage)
        {
            throw new NotImplementedException();
        }

        private static void toFuelACar(Garage io_Garage)
        {
            throw new NotImplementedException();
        }

        private static void inflateCarWheels(Garage io_Garage)
        {
            throw new NotImplementedException();
        }

        private static void changeCarStatus(Garage io_Garage)
        {
            throw new NotImplementedException();
        }

        private static void printCarList(Garage io_Garage)
        {
            Console.WriteLine(string.Format
("If you want to filter the results 1 and then press enter" +
"in case you do not want to filter the result press any other key"));
            String inputFromUser = Console.ReadLine();
            bool toFilter = (inputFromUser == "1");
            List<string> listOfVehicleToString;
            if(toFilter)
            {
                Console.WriteLine(string.Format(
 "For showing only the 'in repair cars' press 1" +
 "For showing only the 'Repaired' Vehicles press 2" +
 "For showing only the 'Paid' Vehicles press 3" ));
                int statusToFilter = int.Parse(Console.ReadLine());
                Garage.GarageVehicle.eVehicleStatus theStatusWeSee =  = Garage.GarageVehicle.eVehicleStatus.InRepair;
                switch (statusToFilter)
                {
                    case 1: theStatusWeSee = Garage.GarageVehicle.eVehicleStatus.InRepair; break;
                    case 2: theStatusWeSee = Garage.GarageVehicle.eVehicleStatus.Repaired; break;
                    case 3: theStatusWeSee = Garage.GarageVehicle.eVehicleStatus.Paid; break;
                }

               listOfVehicleToString = io_Garage.GetListOfLicensePlateNumbersOfVehiclesInGarageWithFilter(theStatusWeSee);
            }
            else
            {
                listOfVehicleToString = io_Garage.GetListOfLicensePlateNumbersOfVehiclesInGarage();
            }

            foreach(string vehicle in listOfVehicleToString)
            {
                Console.WriteLine(vehicle);
            }

            }

        private static void addNewCarToGarage(Garage io_Garage)
        {
            Console.WriteLine("Please enter your car ID");
            string carID = Console.ReadLine();
            bool exist = SystemVehicleManger.FindCarByLicensePlate(io_Garage, carID);
            if(exist)
            {
                Console.WriteLine(string.Format("Your car is already in the garage {0}", carID));
            }
            else
            {
                creatNewVehicle(carID, io_Garage);
            }
 
        }

        private static void creatNewVehicle(string carID,Garage io_Garage)
        {
            Console.WriteLine(string.Format
(@"Please choose the car type that you want to enter the garage
1. Regular motorcycle
2. Electircal motorcycle
3. Regular car
4. Electronic car
5. Truck
or press Q to go back"));

            int commandToDo;
            getValidInputFromUser(out commandToDo);
            bool workOnBattery = true;
            switch (commandToDo)
            {
                case -1: ; break;
                case 1: createVehicle(io_Garage, carID, !workOnBattery, e_TypeOfVehicle.MotorcycleOnFuel); break;
                case 2: createVehicle(io_Garage, carID, workOnBattery, e_TypeOfVehicle.MotorcycleOnBattey); break;
                case 3: createVehicle(io_Garage, carID, !workOnBattery, e_TypeOfVehicle.CarOnFuel); break;
                case 4: createVehicle(io_Garage, carID, workOnBattery, e_TypeOfVehicle.CarOnBattry); break;
                case 5: createVehicle(io_Garage, carID, workOnBattery, e_TypeOfVehicle.Truck); break;
                default: Console.WriteLine("Invalid input , please choose a number between 0 - 7 "); break;
            }

        }

        private static void createVehicle(Garage io_Garage, string carID, bool workOnBattry, e_TypeOfVehicle typeOfVehicle)
        {
            // CarID , car module , vehicleLicense , owner ,CellPhonenumber float powerLeft
            List<String> generalDetails = getGenralDeatailsVehicle(carID);
            List<float> powerSourceDeatails;
            if (workOnBattry == true)
            {
                powerSourceDeatails = getElectricalDetails();
            }
            else
            {
                powerSourceDeatails = GetVeichelByFuelDetails();
            }

            List<String> vehicleDetails;
            List<Wheel> wheels;
            switch (typeOfVehicle)
            {
                // in both cases do the same
                case e_TypeOfVehicle.CarOnBattry:
                case e_TypeOfVehicle.CarOnFuel:
                    vehicleDetails = getCarDetails();
                    wheels = getWeelsDetails(2, 33);
                    SystemVehicleManger.createVehicleInGarage(io_Garage, generalDetails, powerSourceDeatails,
                        wheels, vehicleDetails, typeOfVehicle);
                    break;
                case e_TypeOfVehicle.MotorcycleOnFuel:
                case e_TypeOfVehicle.MotorcycleOnBattey:
                    vehicleDetails = getMotorcycleDetails();
                    wheels = getWeelsDetails(4, 30);
                    SystemVehicleManger.createVehicleInGarage(io_Garage, generalDetails, powerSourceDeatails, wheels,
                        vehicleDetails, typeOfVehicle);
                    break;
                case e_TypeOfVehicle.Truck:
                    vehicleDetails = getTruckDetails();
                    wheels = getWeelsDetails(12, 32);
                    SystemVehicleManger.createVehicleInGarage(io_Garage, generalDetails, powerSourceDeatails, wheels,
                        vehicleDetails, typeOfVehicle);
                    break;
            }
        }

        private static List<String> getTruckDetails()
        {
            List<String> truckDetails = new List<string>();
            Console.WriteLine("Does your truck carry a toxic carrgo ?");
            string isToxic = Console.ReadLine();
            Console.WriteLine("What is your maximum carry weight ?");
            string maximumCarryWeight = Console.ReadLine();
            truckDetails.Add(isToxic);
            truckDetails.Add(maximumCarryWeight);

            return truckDetails;

        }
        private static List<float> getElectricalDetails()
        {
            List<float> electricDetails = new List<float>();
            Console.WriteLine("Please enter how much power left in your battery");
            float powerLeftInBattery = getValidNumberFromUser();
            electricDetails.Add(powerLeftInBattery);

            return electricDetails;
        }

        private static List<float> GetVeichelByFuelDetails()
        {
            List<float> FuelDetailsList = new List<float>();
            Console.WriteLine("Please eneter how much fuel d" +
                "o you have in your tank");
            float fuelLeftInTank = getValidNumberFromUser();
            FuelDetailsList.Add(fuelLeftInTank);

            return FuelDetailsList;
            

        }

        private static float getValidNumberFromUser()
        {
            float fuelLeftInTank;
            string inputFuelFromUser = Console.ReadLine();
            bool isNumber = float.TryParse(inputFuelFromUser, out fuelLeftInTank); ;
            while (!isNumber)
            {
                //TODO consider to throw an Exeception
                Console.WriteLine("Please enter a number");
                inputFuelFromUser = Console.ReadLine();
                bool isANumber = float.TryParse(inputFuelFromUser, out fuelLeftInTank);
            }

            return fuelLeftInTank;
        }

        private static List<String> getCarDetails()
        {
            List<String> carDetails = new List<string>();
            Console.WriteLine("What is your car color ? <Yellow,White,Black,Blue>");
            string color = Console.ReadLine();
            Console.WriteLine("How many doors do you have in your car? <2-5>");
            Console.WriteLine("Please enter the Vehicle module");
            string numberOfDoors = Console.ReadLine();
            carDetails.Add(color);
            carDetails.Add(numberOfDoors);

            return carDetails;
        }

        private static List<String> getGenralDeatailsVehicle (string carID)
        { 
            List<String> details = new List<string>();
            details.Add(carID);
            Console.WriteLine("We would like you to write few necessary details for our mangment System");
            Console.WriteLine("Please enter the Vehicle module");
            string carModule = Console.ReadLine();
            details.Add(carModule);
            Console.WriteLine("Please enter the Vehicle License Plate");
            string vehicleLicense = Console.ReadLine();
            details.Add(vehicleLicense);
            Console.WriteLine("Please enter the Name of the owner");
            string owner = Console.ReadLine();
            details.Add(owner);
            Console.WriteLine("Please enter your Cellphone");
            string CellPhonenumber = Console.ReadLine();
            details.Add(CellPhonenumber);

            return details;

        }

        private static List<String> getMotorcycleDetails()
        {
            List<String> motorcycleDetails = new List<String>();
            Console.WriteLine("Please enter your motorcycle licence type");
            string motorcycleLicenceType = Console.ReadLine();
            Console.WriteLine("Please enter your engine volume");
            string engingeVolumeInStringFormat = Console.ReadLine();
            int engineVolume;
            bool castingWasGood = int.TryParse(engingeVolumeInStringFormat, out engineVolume);
            if (!castingWasGood)
            {
                throw new ArgumentException("This is not a valid number for engine Volume");
            }
            motorcycleDetails.Add(motorcycleLicenceType);
            motorcycleDetails.Add(engingeVolumeInStringFormat);

            return motorcycleDetails;
        }

        private static List<Wheel> getWeelsDetails(int i_NumberOfWheels,float i_MaxTirePressure)
        {
            List<Wheel> listOfWheels = new List<Wheel>();
            
            for(int i = 0;i < i_NumberOfWheels;i++)
            {
                Console.WriteLine(string.Format("Please enter the current tire pressure of the {1} Wheel", i));
                float currentWheelPressure = getValidNumberFromUser();
                Console.WriteLine(string.Format("Please enter the manufacturer name of the Wheel"));
                string manufactor = Console.ReadLine();
                Wheel currentWheelToCreate = new Wheel(manufactor, currentWheelPressure, i_MaxTirePressure);
                listOfWheels.Add(currentWheelToCreate);
            }

            return listOfWheels;

        }
        private static void getValidInputFromUser(out int o_commandForTheComputerToexecute)
        {
                bool validCommandFromUser = false;
                string inputFromUser = "";
                o_commandForTheComputerToexecute = 0;
                while (!validCommandFromUser)
                {
                    Console.WriteLine("Please enter a command for the program or press Q to exit");
                    inputFromUser = Console.ReadLine();
                    if (inputFromUser == "Q")
                    {
                        o_commandForTheComputerToexecute = -1;
                    }
                    validCommandFromUser = int.TryParse(inputFromUser, out o_commandForTheComputerToexecute);         
                    
                    if( validCommandFromUser == false)
                    {
                    Console.WriteLine("Wrong input format please type again");
                    }
                }
        }

       



    }
}
