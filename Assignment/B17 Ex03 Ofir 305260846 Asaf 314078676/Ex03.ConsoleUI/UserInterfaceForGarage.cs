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
                try
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
                    getValidAnswerToMultyplyChoiceAnswer(out inputCommand, 1, 7);
                    switch (inputCommand)
                    {
                        case -1: programIsRunning = false; break;
                        case 1: addNewCarToGarage(myGarage); break;
                        case 2: printCarList(myGarage); break;
                        case 3: changeVehicleStatus(myGarage); break;
                        case 4: inflateCarWheels(myGarage); break;
                        case 5: toFuelACar(myGarage); break;
                        case 6: toChargeAnElectricCar(myGarage); break;
                        case 7: printFullDetailsOfACar(myGarage); break;
                        default: Console.WriteLine("Invalid input , please choose a number between 0 - 7 "); break;
                    }

                }
                catch(FormatException e)
                {
                    Console.Write(e.Message);
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void printFullDetailsOfACar(Garage io_Garage)
        {
            Console.WriteLine("Please enter the License Plate of the car you would like to charge");
            string licensePlate = Console.ReadLine();
            string carDetailsToPrint;
            bool isTheCarInTheGarage = io_Garage.PrintGarageVehicle(licensePlate, out carDetailsToPrint);
            hadnleInputCarFoundOrNot(isTheCarInTheGarage," ");
        }

        private static void hadnleInputCarFoundOrNot(bool i_Found, string i_Message)
        {
            if (!i_Found)
			{
				Console.WriteLine("sorry your car was not found!");
			}
			else
			{
                Console.WriteLine(i_Message);
			}
        }

        private static void toChargeAnElectricCar(Garage io_Garage)
        {
            Console.WriteLine("Please enter the License Plate of the car you would like to charge");
            string licensePlate = Console.ReadLine();
            Console.WriteLine("Please enter the amount of hours that you would like to charge your charger");
            float amountOfTimeToChargeBattery = getValidFloatFromUser();
            bool isTheCarInTheGarage = io_Garage.ChargeElectricVehicle(licensePlate, amountOfTimeToChargeBattery);
            hadnleInputCarFoundOrNot(isTheCarInTheGarage, "Car was charged!");
        }

        private static void toFuelACar(Garage io_Garage)
        {
            Console.WriteLine("Please enter the car's License Plate that you would like to fuel ");
            string licensePlate = Console.ReadLine();
            PowerSource.eFuel typeOfGass = getValidFuelTypeFromUser();
            float amountOfGasToAdd = getValidFloatFromUser();
            bool isTheCarInTheGarage = io_Garage.FillGasInGasVehicle(licensePlate, typeOfGass, amountOfGasToAdd);
            hadnleInputCarFoundOrNot(isTheCarInTheGarage, "Car was Fueled!");
        }

        private static void inflateCarWheels(Garage io_Garage)
        {

            Console.WriteLine("Please enter the car's License Plate that you would like to inflate it's wheels");
            string licensePlate = Console.ReadLine();
            bool isTheCarInTheGarage = io_Garage.InflateWheelsOfVehicleToMax(licensePlate);
            hadnleInputCarFoundOrNot(isTheCarInTheGarage, "Wheels were inflated!");
        }

        private static void changeVehicleStatus(Garage io_Garage)
        {
            Console.WriteLine("Please enter the License Plate that you would like to change it status");
            string licensePlate = Console.ReadLine();
            Console.WriteLine("Please enter your desired status for the car"); 
            Garage.GarageVehicle.eVehicleStatus newStatusForVehicle = getValidStatusCar();
            bool isTheCarInTheGarage = io_Garage.ChangeStateOfVehicle(licensePlate, newStatusForVehicle);
            hadnleInputCarFoundOrNot(isTheCarInTheGarage, "Wheels were inflated!");
        }

        private static void printCarList(Garage io_Garage)
        {
            Console.WriteLine(string.Format
(@"If you want to filter results please press'y' and then press enter" +
"in case you do not want to filter the result press any other key and then press enter"));
            String inputFromUser = Console.ReadLine();
            bool toFilter = (inputFromUser == "y");
            List<string> listOfVehicleToString;
            if(toFilter)
            {
                Console.WriteLine(string.Format(
 "Please enter the category that you are looking for"));
                Garage.GarageVehicle.eVehicleStatus theStatusTheUserChose = getValidStatusCar();
               listOfVehicleToString = io_Garage.GetListOfLicensePlateNumbersOfVehiclesInGarageWithFilter(theStatusTheUserChose);
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
            Console.WriteLine("Please enter your car's license number");
            string licenseNumber = Console.ReadLine();
            Garage.GarageVehicle vehicleWeWantToAdd = io_Garage.FindCarByLicensePlate(licenseNumber);
            if(vehicleWeWantToAdd != null)
            {
                Console.WriteLine(string.Format("Your car is already in the garage {0}", licenseNumber));
                vehicleWeWantToAdd.Status = Garage.GarageVehicle.eVehicleStatus.InRepair;
            }
            else
            {
                creatNewVehicle(licenseNumber, io_Garage);
            }
 
        }

        private static void creatNewVehicle(string i_CarLicense, Garage io_Garage)
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
            getValidAnswerToMultyplyChoiceAnswer(out commandToDo,1,5);
            bool workOnBattery = true;
            switch (commandToDo)
            {
                case -1: ; throw new FormatException();
                case 1: createNewVehicleHelper(io_Garage, i_CarLicense, !workOnBattery, e_TypeOfVehicle.MotorcycleOnFuel); break;
                case 2: createNewVehicleHelper(io_Garage, i_CarLicense, workOnBattery, e_TypeOfVehicle.MotorcycleOnBattey); break;
                case 3: createNewVehicleHelper(io_Garage, i_CarLicense, !workOnBattery, e_TypeOfVehicle.CarOnFuel); break;
                case 4: createNewVehicleHelper(io_Garage, i_CarLicense, workOnBattery, e_TypeOfVehicle.CarOnBattry); break;
                case 5: createNewVehicleHelper(io_Garage, i_CarLicense, workOnBattery, e_TypeOfVehicle.Truck); break;
            }

        }

        private static void createNewVehicleHelper(Garage io_Garage, string i_CarLicense, bool workOnBattry, e_TypeOfVehicle typeOfVehicle)
        {
            // CarID , car module , vehicleLicense , owner ,CellPhonenumber float powerLeft
            List<String> generalDetails = getGenralDeatailsVehicle(i_CarLicense);
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
                    wheels = getWheelsDetails(2, 33);
                    SystemVehicleManger.createVehicleInGarage(io_Garage, generalDetails, powerSourceDeatails,
                        wheels, vehicleDetails, typeOfVehicle);
                    break;
                case e_TypeOfVehicle.MotorcycleOnFuel:
                case e_TypeOfVehicle.MotorcycleOnBattey:
                    vehicleDetails = getMotorcycleDetails();
                    wheels = getWheelsDetails(4, 30);
                    SystemVehicleManger.createVehicleInGarage(io_Garage, generalDetails, powerSourceDeatails, wheels,
                        vehicleDetails, typeOfVehicle);
                    break;
                case e_TypeOfVehicle.Truck:
                    vehicleDetails = getTruckDetails();
                    wheels = getWheelsDetails(12, 32);
                    SystemVehicleManger.createVehicleInGarage(io_Garage, generalDetails, powerSourceDeatails, wheels,
                        vehicleDetails, typeOfVehicle);
                    break;
            }
        }

        private static List<String> getTruckDetails()
        {
            List<String> truckDetails = new List<string>();
            Console.WriteLine("Does your truck carry a toxic carrgo ?");
            bool isToxicBool = getValidboolFromUser();
            string isToxic = isToxicBool.ToString();
            Console.WriteLine("What is your maximum carry weight ?");
            int maximumCarryWeight = getValidIntFromUser();
            string maximumCarryWeightStringFormat = Console.ReadLine();
            truckDetails.Add(isToxic);
            truckDetails.Add(maximumCarryWeightStringFormat);

            return truckDetails;

        }
        private static List<float> getElectricalDetails()
        {
            List<float> electricDetails = new List<float>();
            Console.WriteLine("Please enter how much power left in your battery");
            float powerLeftInBattery = getValidFloatFromUser();
            electricDetails.Add(powerLeftInBattery);

            return electricDetails;
        }

        private static List<float> GetVeichelByFuelDetails()
        {
            List<float> FuelDetailsList = new List<float>();
            Console.WriteLine("Please enter how much fuel do you have in your tank");
            float fuelLeftInTank = getValidFloatFromUser();
            FuelDetailsList.Add(fuelLeftInTank);

            return FuelDetailsList;
            
        }

        private static List<String> getCarDetails()
        {
            List<String> carDetails = new List<string>();
            Car.eColor color = getValidColorFromUser();
            Console.WriteLine("How many doors do you have in your car? <2-5>");
            Console.WriteLine("Please enter the Vehicle module");
            Car.eNumberOfDoors numberOfDoors = getValidNumberOfDoorsFromUser();
            carDetails.Add(color.ToString());
            carDetails.Add(numberOfDoors.ToString());

            return carDetails;
        }

        private static List<String> getGenralDeatailsVehicle (string i_CarLicense)
        {
            
            List<String> details = new List<string>();
            details.Add(i_CarLicense);
            Console.WriteLine("We would like you to write few necessary details for our mangment System");
            Console.WriteLine("Please enter the Vehicle module");
            string carModule = Console.ReadLine();
            details.Add(carModule);
            Console.WriteLine("Please enter the Name of the owner");
            string owner = Console.ReadLine();
            details.Add(owner);
            Console.WriteLine("Please enter your Cellphone");
            string CellPhoneNumber = Console.ReadLine();
            details.Add(CellPhoneNumber);

            return details;

        }

        private static List<String> getMotorcycleDetails()
        {
            List<String> motorcycleDetails = new List<String>();
            Console.WriteLine("Please enter your motorcycle licence type");
            Motorcycle.eLicenceType motorcycleLicenceType = getValidLicenceType();
            Console.WriteLine("Please enter your engine volume");
            int engineVolume = getValidIntFromUser();
            motorcycleDetails.Add(motorcycleLicenceType.ToString());
            motorcycleDetails.Add(engineVolume.ToString());

            return motorcycleDetails;
        }

        private static List<Wheel> getWheelsDetails(int i_NumberOfWheels,float i_MaxTirePressure)
        {
            List<Wheel> listOfWheels = new List<Wheel>();
            
            for(int i = 0;i < i_NumberOfWheels;i++)
            {
                Console.WriteLine(string.Format("Please enter the tire pressure of the {0} Wheel", i));
                float currentWheelPressure = getValidFloatFromUser();
                Console.WriteLine(string.Format("Please enter the manufacturer name of the Wheel"));
                string manufactor = Console.ReadLine();
                Wheel currentWheelToCreate = new Wheel(manufactor, currentWheelPressure, i_MaxTirePressure);
                listOfWheels.Add(currentWheelToCreate);
            }

            return listOfWheels;

        }

        private static void getValidAnswerToMultyplyChoiceAnswer(out int o_validAnswer, int i_MinValidValueToChoose,
                                                    int i_MaxValidValueToChoose)
        {
                bool validCommandFromUser = false;
                string inputFromUser ;
                o_validAnswer = -1;
                while (!validCommandFromUser)
                {
                    Console.WriteLine("Please enter a command for the program or press Q to exit");
                    inputFromUser = Console.ReadLine();
                    if (inputFromUser == "Q")
                    {
                        o_validAnswer = -1;
                        break;
                     }

                    validCommandFromUser = int.TryParse(inputFromUser, out o_validAnswer);
                 
                    if( validCommandFromUser == false)
                    {
                        Console.WriteLine("Wrong input format please type again");
                    }

                    else if (o_validAnswer < i_MinValidValueToChoose || o_validAnswer > i_MaxValidValueToChoose)
                    {
                        Console.WriteLine("Value is not in range, please enter a value between {0} - {1}",
                            i_MinValidValueToChoose, i_MaxValidValueToChoose);
                        validCommandFromUser = false;
                    }
                }
        }

        private static float getValidFloatFromUser()
        {
            float validFloat;
            bool isValidFloat = float.TryParse(Console.ReadLine(), out validFloat);
            while(! isValidFloat)
            {
                Console.WriteLine("Invalid Input please enter a real number");
                isValidFloat= float.TryParse(Console.ReadLine(), out validFloat);
            }

            return validFloat;
        }


        private static int getValidIntFromUser()
        {
            int validInt = -1;
            bool isValidInt = int.TryParse(Console.ReadLine(), out validInt);
            while (! isValidInt)
            {
                Console.WriteLine("Invalid Input please enter a number");
                isValidInt = int.TryParse(Console.ReadLine(), out validInt);
            }

            return validInt;
        }

        private static bool getValidboolFromUser()
        {
            bool validBool = false;
            bool isValidInt = bool.TryParse(Console.ReadLine(), out validBool);
            while (! isValidInt)
            {
                Console.WriteLine("Invalid Input please enter a boolean <true,false>");
                isValidInt = bool.TryParse(Console.ReadLine(), out validBool);
            }

            return validBool;
        }

        private static PowerSource.eFuel getValidFuelTypeFromUser()
        {

            int numberOfFuelTheUserChose;
            Console.WriteLine(string.Format(
@"Which fuel would you like to use?  +
1.Octan 95
2.Octan 96
3.Octan 98
4.Soler"));
            getValidAnswerToMultyplyChoiceAnswer(out numberOfFuelTheUserChose,1, 3);
            PowerSource.eFuel fuelToReturn = PowerSource.eFuel.Octan95;

            switch (numberOfFuelTheUserChose)
            {
                case -1: throw new FormatException();
                case 1: fuelToReturn = PowerSource.eFuel.Octan95;break;
                case 2: fuelToReturn = PowerSource.eFuel.Octan96; break;
                case 3: fuelToReturn = PowerSource.eFuel.Octan98; break;
                case 4: fuelToReturn = PowerSource.eFuel.Soler; break;

            }

            return fuelToReturn;
        }

        private static Car.eColor getValidColorFromUser()
        {

            int color;
            Console.WriteLine(string.Format(
@"What is your car color?  +
1.Black
2.Blue
3.White
4.Yellow"));
            getValidAnswerToMultyplyChoiceAnswer(out color, 1, 4);
            Car.eColor colorToReturn = Car.eColor.Black;

            switch (color)
            {
                case -1: throw new FormatException();
                case 1: colorToReturn = Car.eColor.Black; ; break;
                case 2: colorToReturn = Car.eColor.Blue; ; break;
                case 3: colorToReturn = Car.eColor.While; ; break;
                case 4: colorToReturn = Car.eColor.Yellow; ; break;

            }

            return colorToReturn;
        }

    
    private static Car.eNumberOfDoors getValidNumberOfDoorsFromUser()
    {
            

        int numberOfDoors;
        Console.WriteLine(string.Format(
@"What is the number of doors in your car?  +
2.Two
3.Three
4.Four
5.Five"));
        getValidAnswerToMultyplyChoiceAnswer(out numberOfDoors, 2, 5);
        Car.eNumberOfDoors colorToReturn = Car.eNumberOfDoors.Four;

        switch (numberOfDoors)
        {
            case -1: throw new FormatException();
            case 2: colorToReturn = Car.eNumberOfDoors.Two; ; break;
            case 3: colorToReturn = Car.eNumberOfDoors.Three; ; break;
            case 4: colorToReturn = Car.eNumberOfDoors.Four; ; break;
            case 5: colorToReturn = Car.eNumberOfDoors.Five; ; break;

        }

        return colorToReturn;
    }


        private static Motorcycle.eLicenceType getValidLicenceType()
        {

            int licenceTypeOfTheMotorecycle;
            Console.WriteLine(string.Format(
    @"What is your motorcycle licence type?  +
1.A
2.AB
3.A2
4.B1"));
            getValidAnswerToMultyplyChoiceAnswer(out licenceTypeOfTheMotorecycle, 1, 4);
            Motorcycle.eLicenceType licenceType = Motorcycle.eLicenceType.A;

            switch (licenceTypeOfTheMotorecycle)
            {
                case -1: throw new FormatException();
                case 1: licenceType = Motorcycle.eLicenceType.A; ; break;
                case 2: licenceType = Motorcycle.eLicenceType.A2; ; break;
                case 3: licenceType = Motorcycle.eLicenceType.AB; ; break;
                case 4: licenceType = Motorcycle.eLicenceType.B1; ; break;

            }

            return licenceType;
        }
        private static Garage.GarageVehicle.eVehicleStatus getValidStatusCar()
        {
            Console.WriteLine(string.Format(
"1 for 'in repaired'" +
"2 for 'Repaired'" +
"3 for 'Paid' "));
            int statusToFilter;
            getValidAnswerToMultyplyChoiceAnswer(out statusToFilter, 1, 3);
            Garage.GarageVehicle.eVehicleStatus statusForCar = Garage.GarageVehicle.eVehicleStatus.InRepair;
            switch (statusToFilter)
            {
                case -1: throw new FormatException();
                case 1: statusForCar = Garage.GarageVehicle.eVehicleStatus.InRepair; break;
                case 2: statusForCar = Garage.GarageVehicle.eVehicleStatus.Repaired; break;
                case 3: statusForCar = Garage.GarageVehicle.eVehicleStatus.Paid; break;
            }

            return statusForCar;

        }
    }
}
