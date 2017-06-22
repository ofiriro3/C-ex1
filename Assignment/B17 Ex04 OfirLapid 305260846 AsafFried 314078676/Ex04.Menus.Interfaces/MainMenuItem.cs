using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    class MainMenuItem : SubMenuItem
    {
        internal override void onClick()
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
                    Console.WriteLine(execption.ToString());
                }
            }
            
        }
    }
}
