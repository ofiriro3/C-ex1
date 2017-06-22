using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public class ShowTime : IFunction
    {
        public void Run()
        {
            DateTime dateAndTime = DateTime.Now;   
            Console.WriteLine("The time now is {0}", dateAndTime.ToString("T"));
        }
    }
}
