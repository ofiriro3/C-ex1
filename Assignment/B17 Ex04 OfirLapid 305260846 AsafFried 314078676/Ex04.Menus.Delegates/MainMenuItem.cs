using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenuItem : SubMenuItem
    {
        public MainMenuItem(string i_Title) : base(i_Title){}

        public MainMenuItem(string i_Title, List<MenuItem> i_MenuItems) : base(i_Title, i_MenuItems){}

        public override void onClick()
        {
            bool isRunning = true;
            while (isRunning)
            {
                try
                {
                    base.onClick();
                    isRunning = false;
                }

                catch(FinishedOperation execption)
                {
                    Console.WriteLine(execption.Message);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                      
                }
            } 
        }
    }
}
