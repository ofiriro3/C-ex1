using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;
using Wheel = Ex03.GarageLogic.Wheel;
namespace Ex03.ConsoleUI
{
    public abstract class Vehicle
    {
        string m_ModuleName;
        string m_LicensePlate;
        float m_RemainingPower;
        List<Wheel> m_Wheels;
        PowerSource m_PowerSource;









    }
}
