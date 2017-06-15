﻿using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using e_TypeOfPowerSource = Ex03.GarageLogic.SystemVehicleManger.e_TypeOfPowerSource;

namespace Ex03.ConsoleUI
{
    public static class UserInterfaceForGarage
    {
        public static void Run()
        {
            Garage myGarage = new Garage();
            bool programIsRunning = true;

            while (programIsRunning)
            {
                try
                {
                    Console.WriteLine(string.Format
    (@"
=================================
Please choose one of the folowing : 

Press 1 for add another vehicle to the garage
Press 2 for print the License Plates of all vehicles that are now in the garage
Press 3 for change a vehicle status in the garage
Press 4 to inflate the vehicles wheels
Press 5 to fuel a vehicle
Press 6 to charge a battery of an electricity vehicle
Press 7 for full details of a specific vehicle"));
                    int inputCommand;
                    getValidAnswerToMultyplyChoiceAnswer(out inputCommand, 1, 7);
                    Console.Clear();
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

                catch(ValueOutOfRangeException e)
                {
                    Console.Write(e.Message);
                }

                catch(FormatException e)
                {
                    Console.Write(e.Message);
                }

                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Please press any key to continue");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        private static void printFullDetailsOfACar(Garage io_Garage)
        {
            Console.WriteLine("Please enter the License Plate of the vehicle you would like to charge");
            string licensePlate = Console.ReadLine();
            string carDetailsToPrint;
            bool isTheCarInTheGarage = io_Garage.PrintGarageVehicle(licensePlate, out carDetailsToPrint);
            hadnleInputCarFoundOrNot(isTheCarInTheGarage, carDetailsToPrint);
        }

        private static void hadnleInputCarFoundOrNot(bool i_Found, string i_Message)
        {
            if (!i_Found)
			{
				Console.WriteLine("sorry your vehicle was not found!");
			}
			else
			{
                Console.WriteLine(i_Message);
			}
        }

        private static void toChargeAnElectricCar(Garage io_Garage)
        {
            Console.WriteLine("Please enter the License Plate of the vehicle you would like to charge");
            string licensePlate = Console.ReadLine();
            Console.WriteLine("Please enter the amount of hours that you would like to charge your charger");
            float amountOfTimeToChargeBattery = getValidPositiveFloatFromUser();
            bool isTheCarInTheGarage = io_Garage.ChargeElectricVehicle(licensePlate, amountOfTimeToChargeBattery);
            hadnleInputCarFoundOrNot(isTheCarInTheGarage, String.Format("Vehicle {0} was chraged!", licensePlate));
        }

        private static void toFuelACar(Garage io_Garage)
        {
            Console.WriteLine("Please enter the vehicle's License Plate that you would like to fuel ");
            string licensePlate = Console.ReadLine();
            PowerSource.eFuel typeOfGass = getValidFuelTypeFromUser();
            Console.WriteLine("Please enter the amount of fuel to add");
            float amountOfGasToAdd = getValidPositiveFloatFromUser();
            bool isTheCarInTheGarage = io_Garage.FillGasInGasVehicle(licensePlate, typeOfGass, amountOfGasToAdd);
            hadnleInputCarFoundOrNot(isTheCarInTheGarage, String.Format("Vehicle {0} was fueld!", licensePlate));
        }

        private static void inflateCarWheels(Garage io_Garage)
        {
            Console.WriteLine("Please enter the vehicle's License Plate that you would like to inflate it's wheels");
            string licensePlate = Console.ReadLine();
            bool isTheCarInTheGarage = io_Garage.InflateWheelsOfVehicleToMax(licensePlate);
            hadnleInputCarFoundOrNot(isTheCarInTheGarage, String.Format("Wheels of vehicle {0} were inflated!", licensePlate));
        }

        private static void changeVehicleStatus(Garage io_Garage)
        {
            Console.WriteLine("Please enter the License Plate that you would like to change it status");
            string licensePlate = Console.ReadLine();
            Console.WriteLine("Please enter your desired status for the vehicle"); 
            Garage.GarageVehicle.eVehicleStatus newStatusForVehicle = getValidStatusCar();
            bool isTheCarInTheGarage = io_Garage.ChangeStateOfVehicle(licensePlate, newStatusForVehicle);
            hadnleInputCarFoundOrNot(isTheCarInTheGarage, String.Format(
@"Status for vehicle {0} was changed to {1}!", licensePlate, newStatusForVehicle));
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

            if (listOfVehicleToString.Count == 0)
            {
                Console.WriteLine("No Vehicles in garage!");
            }

            else
            {
                foreach (string vehicle in listOfVehicleToString)
                {
                    Console.WriteLine(vehicle);
                }
            }
        }

        private static void addNewCarToGarage(Garage io_Garage)
        {
            Console.WriteLine("Please enter your vehicle's license number");
            string licenseNumber = Console.ReadLine();
            Garage.GarageVehicle vehicleWeWantToAdd = io_Garage.FindCarByLicensePlate(licenseNumber);
            if(vehicleWeWantToAdd != null)
            {
                Console.WriteLine(string.Format("Vehicle {0} is already in the garage", licenseNumber));
                vehicleWeWantToAdd.Status = Garage.GarageVehicle.eVehicleStatus.InRepair;
            }

            else
            {
                creatNewVehicle(licenseNumber, io_Garage);
                Console.WriteLine("Vehicle was successfuly added to garage!");
            }
        }

        private static void creatNewVehicle(string i_CarLicense, Garage io_Garage)
        {
            StringBuilder query = new StringBuilder();
            Dictionary<Type, List<e_TypeOfPowerSource>> supportredVehicles = SystemVehicleManger.GetSupportedVehicle();
            int runningIndex = 1;
            Type userChosenVehicle = null;
            e_TypeOfPowerSource userChosenVehiclePowersource = e_TypeOfPowerSource.Battery;

            query.AppendLine("Please choose the vehicle type that you want to enter the garage: ");
            foreach(Type type in supportredVehicles.Keys)
            {
                List<e_TypeOfPowerSource> powerSources = null;
                supportredVehicles.TryGetValue(type, out powerSources);
                foreach (e_TypeOfPowerSource powerSource in powerSources)
                {
                    query.AppendLine(String.Format("{0} .  {1}  {2}", runningIndex, type.Name.ToString(), powerSource.ToString()));
                    runningIndex++;
                }
            }

            Console.WriteLine(query.ToString());
            int commandToDo;
            getValidAnswerToMultyplyChoiceAnswer(out commandToDo, 1, runningIndex);
            runningIndex = 1;
            if(commandToDo == -1) // user decided to exit
            {
                throw new FormatException("You are back in the main menu");
            }

            bool finishClassifyVehicle = false;
			foreach (Type type in supportredVehicles.Keys)
			{
				List<e_TypeOfPowerSource> powerSources = null;
				supportredVehicles.TryGetValue(type, out powerSources);
				foreach (e_TypeOfPowerSource powerSource in powerSources)
				{
					if (runningIndex == commandToDo)
					{
						userChosenVehicle = type;
                        userChosenVehiclePowersource = powerSource;
                        finishClassifyVehicle = true;
                        break;
					}
					runningIndex++;
				}

                if (finishClassifyVehicle)
                {
                    break;
                }
			}

            createNewVehicleHelper(io_Garage, i_CarLicense, userChosenVehiclePowersource, userChosenVehicle);
        }

        private static void createNewVehicleHelper(Garage io_Garage, string i_CarLicense, e_TypeOfPowerSource i_TypeOfPowerSource, Type i_TypeOfVehicle)
        {
            List<String> generalDetails = getGenralDeatailsVehicle(i_CarLicense); // CarID , car module , vehicleLicense , owner ,CellPhonenumber float powerLeft
			List<float> powerSourceDeatails = (i_TypeOfPowerSource.Equals(e_TypeOfPowerSource.Battery)) ? getElectricalDetails() : getVeichelByFuelDetails();
            List<string> wheels = getWheelDetails();
            Dictionary<string, List<string>> vehicleUniqeProperties = SystemVehicleManger.GetVehicleUniqeProperties(i_TypeOfVehicle);
            Dictionary<string, string> vehicleUniqeDetails = getVehicleUniqDetails(vehicleUniqeProperties);   

			SystemVehicleManger.CreateVehicleInGarage(io_Garage, generalDetails, powerSourceDeatails, wheels,
                                                      vehicleUniqeDetails, i_TypeOfVehicle, i_TypeOfPowerSource);
        }

        private static Dictionary<string, string> getVehicleUniqDetails(Dictionary<string, List<string>> i_VehicleUniqeProperties)
        {
            Dictionary<string,string> vehicleUniqDetails = new Dictionary<string, string>(i_VehicleUniqeProperties.Count);

            foreach(string parameter in i_VehicleUniqeProperties.Keys)
            {
				List<string> parameterOptions = null;
				i_VehicleUniqeProperties.TryGetValue(parameter, out parameterOptions);
                Console.WriteLine(String.Format("Please enter parameter : {0}", parameter));
                if (parameterOptions != null)
                {
                    int runningIndex = 1;
                    foreach (string parameterOption in parameterOptions)
                    {
                        Console.WriteLine(String.Format(@"{0} . {1}", runningIndex, parameterOption));
                        runningIndex++;
                    }

					int commandToDo;
					getValidAnswerToMultyplyChoiceAnswer(out commandToDo, 1, parameterOptions.Count);
                    if(commandToDo == -1) // user decided to exit
                    {
                        throw new FormatException("You are back in the main menu");
                    }

                    vehicleUniqDetails.Add(parameter,parameterOptions[commandToDo - 1]);
                }

                else
                {
                    string answerFromUser = Console.ReadLine();
                    vehicleUniqDetails.Add(parameter, answerFromUser);
                }
            }

            return vehicleUniqDetails;
        }

        private static List<float> getElectricalDetails()
        {
            List<float> electricDetails = new List<float>();
            Console.WriteLine("Please enter how much power left in your battery");
            float powerLeftInBattery = getValidPositiveFloatFromUser();
            electricDetails.Add(powerLeftInBattery);

            return electricDetails;
        }

        private static List<float> getVeichelByFuelDetails()
        {
            List<float> FuelDetailsList = new List<float>();
            Console.WriteLine("Please enter how much fuel do you have in your tank");
            float fuelLeftInTank = getValidPositiveFloatFromUser();
            FuelDetailsList.Add(fuelLeftInTank);

            return FuelDetailsList;   
        }


        private static List<String> getGenralDeatailsVehicle(string i_CarLicense)
        {
            List<String> details = new List<string>();
            details.Add(i_CarLicense);
            Console.WriteLine("We would like you to write few necessary details for our mangment System");
            Console.WriteLine("Please enter the Vehicle module");
            string carModule = getValidStringFromUser();
            details.Add(carModule);
            Console.WriteLine("Please enter the Name of the owner");
            string owner = getValidStringFromUser();
            details.Add(owner);
            Console.WriteLine("Please enter your Cellphone");
            string CellPhoneNumber = getValidStringFromUser();
            details.Add(CellPhoneNumber);

            return details;
        }

        private static List<string> getWheelDetails()
        {
            List<string> wheelDetail = new List<string>();

            Console.WriteLine(string.Format("Please enter the tire pressure of the Wheel"));
            float currentWheelPressure = getValidPositiveFloatFromUser();
            Console.WriteLine(string.Format("Please enter the manufacturer name of the Wheel"));
            string manufactor = Console.ReadLine();
            wheelDetail.Add(manufactor);
            wheelDetail.Add(currentWheelPressure.ToString());

            return wheelDetail;
        }

        private static void getValidAnswerToMultyplyChoiceAnswer(out int o_ValidAnswer, int i_MinValidValueToChoose,
                                                    int i_MaxValidValueToChoose)
        {
            bool validCommandFromUser = false;
            string inputFromUser;
            o_ValidAnswer = -1;

            while (!validCommandFromUser)
            {
                Console.WriteLine("Please enter a command for the program or press Q to exit");
                inputFromUser = Console.ReadLine();
                if (inputFromUser == "Q")
                {
                    o_ValidAnswer = -1;
                    break;
                }

                validCommandFromUser = int.TryParse(inputFromUser, out o_ValidAnswer);
                if( validCommandFromUser == false)
                {
                    Console.WriteLine("Wrong input format please type again");
                }

                else if (o_ValidAnswer < i_MinValidValueToChoose || o_ValidAnswer > i_MaxValidValueToChoose)
                {
                    Console.WriteLine("Value is not in range, please enter a value between {0} - {1}",
                        i_MinValidValueToChoose, i_MaxValidValueToChoose);
                    validCommandFromUser = false;
                }
            }
        }


        private static string getValidStringFromUser()
        {
            string validString = "";

            while ((validString = Console.ReadLine()).Length == 0)
            {
              Console.WriteLine("Invalid Input please enter a non empty string");  
            }

            return validString;
        }


        private static float getValidPositiveFloatFromUser()
        {
            float validFloat = -1;
            bool isValidFloat = float.TryParse(Console.ReadLine(), out validFloat);

            while(! isValidFloat || validFloat < 0)
            {
                Console.WriteLine("Invalid Input please enter a positive number");
                isValidFloat= float.TryParse(Console.ReadLine(), out validFloat);
            }

            return validFloat;
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
            getValidAnswerToMultyplyChoiceAnswer(out numberOfFuelTheUserChose,1, 4);
            PowerSource.eFuel fuelToReturn = PowerSource.eFuel.Octan95;
            switch (numberOfFuelTheUserChose)
            {
                case -1: throw new FormatException("You are back in the main menu");
                case 1: fuelToReturn = PowerSource.eFuel.Octan95;break;
                case 2: fuelToReturn = PowerSource.eFuel.Octan96; break;
                case 3: fuelToReturn = PowerSource.eFuel.Octan98; break;
                case 4: fuelToReturn = PowerSource.eFuel.Soler; break;

            }

            return fuelToReturn;
        }

        private static Garage.GarageVehicle.eVehicleStatus getValidStatusCar()
        {
            Console.WriteLine(string.Format(
@"1 for 'in repaired'
2 for 'Repaired'
3 for 'Paid' "));
            int statusToFilter;
            getValidAnswerToMultyplyChoiceAnswer(out statusToFilter, 1, 3);
            Garage.GarageVehicle.eVehicleStatus statusForCar = Garage.GarageVehicle.eVehicleStatus.InRepair;
            switch (statusToFilter)
            {
                case -1: throw new FormatException("You are back in the main menu");
                case 1: statusForCar = Garage.GarageVehicle.eVehicleStatus.InRepair; break;
                case 2: statusForCar = Garage.GarageVehicle.eVehicleStatus.Repaired; break;
                case 3: statusForCar = Garage.GarageVehicle.eVehicleStatus.Paid; break;
            }

            return statusForCar;
        }
    }
}