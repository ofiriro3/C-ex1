using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public static class UserInterfaceForGarage
    {



        public static void run()
        {
            bool programIsRunning = true;
            while (programIsRunning)
            {
                Console.WriteLine(string.Format
(@"Please choose one of the folowing
Press 1 for add another Vehicle to the garage
Press 2 for print the License Plates of all cars that are now in the garage
Press 3 for print the License Plates of all cars that are now in the garage with specific status
Press 4 for change a car status in the garage
Press 5 to inflate one of the cars wheels
Press 6 to fuel a car
Press 7 to charge a battery of an electricity car
Press 8 for full details of a specific car"));

                int inputCommand;
                getValidInputFromUser(out inputCommand);
                switch (inputCommand)
                {
                    case -1: programIsRunning = false; break;
                    case 1:AddNewCarToGarage();break;
                    case 2: AddNewCarToGarage(); break;
                    case 3: AddNewCarToGarage(); break;
                    case 4: AddNewCarToGarage(); break;
                    case 5: AddNewCarToGarage(); break;
                    case 6: AddNewCarToGarage(); break;
                    case 7: AddNewCarToGarage(); break;
                    case 8: AddNewCarToGarage(); break;
                    default: Console.WriteLine("Invalid input , please choose a number between 0 - 8");
                }


            }
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
                }
        }

       



    }
}
