using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    class SubMenuItem : MenuItem
    {
        protected List<MenuItem> m_MenuItems;

        public SubMenuItem()
        {
            m_MenuItems = new List<MenuItem>();
        }

        public bool AddItem(MenuItem i_Item)
        {
            return false;
        }

        public bool RemoveItem(MenuItem i_Item)
        {
            return false;
        }

        internal override void onClick()
        {
            bool stillRunning = true;
            
            while(stillRunning)
            {
                Console.Clear();
                this.Show();
                Console.WriteLine("=========================");
                int counter = 1;

                foreach(MenuItem item in m_MenuItems)
                {
                    item.Index = counter;
                    item.Show();
                    counter++;
                }

                if(this.GetType().Equals(typeof(MainMenuItem)))
                {
                    Console.WriteLine("0. Exit");
                }
                else
                {
                    Console.WriteLine("0. Back");
                }

                int choice;
                getValidAnswerToMultyplyChoiceAnswer(out choice);
                if( choice == 0)
                {
                    stillRunning = false;
                    continue;
                }

                m_MenuItems[choice].onClick();
                
            }
            
        }
        
        protected void getValidAnswerToMultyplyChoiceAnswer(out int o_ValidAnswer)
        {
            int minValidValueToChoose = 1;
            int maxValidValueToChoose = m_MenuItems.Count;
            bool validCommandFromUser = false;
            string inputFromUser;
            o_ValidAnswer = -1;

            while (!validCommandFromUser)
            {
                Console.WriteLine(string.Format("Please enter your choice({0}-{1} or 0 to exit", minValidValueToChoose, maxValidValueToChoose));
                inputFromUser = Console.ReadLine();
                validCommandFromUser = int.TryParse(inputFromUser, out o_ValidAnswer);
                if (validCommandFromUser == false)
                {
                    Console.WriteLine("Wrong input format please type again");
                }

                else if (o_ValidAnswer < minValidValueToChoose || o_ValidAnswer > maxValidValueToChoose || o_ValidAnswer != 0)
                {
                    Console.WriteLine("Value is not in range");
                    validCommandFromUser = false;
                }

            }
        }
    }
}
