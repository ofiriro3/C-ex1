using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using Garage = Ex03.GarageLogic.Garage;
using SystemVehicleManger = Ex03.GarageLogic.SystemVehicleManger;

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
            throw new NotImplementedException();
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
4. Truck
or press Q to go back"));

            int commandToDo;
            getValidInputFromUser(out commandToDo);
            switch (commandToDo)
            {
                case -1: ; break;
                case 1: createRegularMotorCycle(io_Garage, carID); break;
                case 2: createElectornicMotorCycle(io_Garage, carID); break;
                case 3: createRegularCar(io_Garage, carID); break;
                case 4: createTruck(io_Garage, carID); break;
                case 7: printFullDetailsOfACar(io_Garage, carID); break;
                default: Console.WriteLine("Invalid input , please choose a number between 0 - 7 "); break;
            }

        }

        private static void createRegularMotorCycle(Garage io_Garage, string carID)
        {

            // CarID , car module , vehicleLicense , owner ,CellPhonenumber float powerLeft
            List<String> generalDetails = getGenralDeatailsVehicle(carID);
            List<float> electricalDetails = getElectricalDetails(); ;
            List<Wheel> wheelList = getWeelsDetails(2,33f);
            SystemVehicleManger.createRegularMotorCycle(io_Garage, generalDetails, electricalDetails, wheelList);

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
            Console.WriteLine("Please eneter how much fuel do you have in your tank");
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
