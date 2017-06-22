using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public class ShowDate : IFunction
    {
        public void run()
        {
            DateTime dateAndTime = new DateTime();
            Console.WriteLine("The time now is {0}", dateAndTime.Date.ToString());
        }
    }
}
