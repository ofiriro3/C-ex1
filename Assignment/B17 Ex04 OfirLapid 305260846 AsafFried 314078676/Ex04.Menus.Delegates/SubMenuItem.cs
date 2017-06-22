using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class SubMenuItem : MenuItem
    {
        protected List<MenuItem> m_MenuItems;

        public SubMenuItem(string i_Title) : base(i_Title)
        {
            m_MenuItems = new List<MenuItem>();
        }

		public SubMenuItem(string i_Title, List<MenuItem> i_MenuItems) : base(i_Title)
		{
            m_MenuItems = i_MenuItems;
		}

        public List<MenuItem> MenuItems
        {
            get 
            { 
                return m_MenuItems; 
            }

            set 
            { 
                m_MenuItems = value; 
            }
        }

        public bool AddItem(MenuItem i_Item)
        {
            bool succefulStatus = true;

            foreach(MenuItem item in m_MenuItems)
            {
                if(item.Equals(i_Item))
                {
                    succefulStatus = false;
                    break;
                }
            }

            if(succefulStatus)
            {
                m_MenuItems.Add(i_Item);
            }

            return succefulStatus;
        }

        public bool RemoveItem(MenuItem i_Item)
        {
            return m_MenuItems.Remove(i_Item);
        }

        public override void onClick()
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

                m_MenuItems[choice - 1].onClick();
                
                
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
                Console.WriteLine(string.Format("Please enter your choice({0}-{1}) or 0 to exit", minValidValueToChoose, maxValidValueToChoose));
                inputFromUser = Console.ReadLine();
                validCommandFromUser = int.TryParse(inputFromUser, out o_ValidAnswer);
                if (validCommandFromUser == false)
                {
                    Console.WriteLine("Wrong input format please type again");
                }

                else if ((o_ValidAnswer < minValidValueToChoose || o_ValidAnswer > maxValidValueToChoose) && o_ValidAnswer != 0)
                {
                    Console.WriteLine("Value is not in range");
                    validCommandFromUser = false;
                }

            }
        }
    }
}
