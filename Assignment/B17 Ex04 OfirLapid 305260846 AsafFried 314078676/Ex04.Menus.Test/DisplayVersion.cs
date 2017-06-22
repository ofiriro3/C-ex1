using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public class DisplayVersion : IFunction
    {
        public void run()
        {
            Console.WriteLine("App Version: 17.2.4.0");
        }
    }
}
