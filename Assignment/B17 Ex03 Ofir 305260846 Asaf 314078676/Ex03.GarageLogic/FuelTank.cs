﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelTank : PowerSource
    {
        private eFuel m_FuelType;


        public FuelTank(float i_MaxCampacity,float i_CurrentCampacity,eFuel i_FuelType)
        :base(i_MaxCampacity,i_CurrentCampacity)
        {
            m_FuelType = i_FuelType;
        }
        public void Charge(float i_Liters, eFuel i_FuelType)
        {
            float expectedAmountOfFuel = i_Liters + m_CurrentCampacity;
            
            if(i_FuelType.Equals(m_FuelType))
            {
                throw new ArgumentException("You are trying to add wrong fuel to the vehicle");
            }
            else if(m_CurrentCampacity < v_MinCampacity || r_MaxCampacity < expectedAmountOfFuel )
            {
                throw new ValueOutOfRangeException(v_MinCampacity, r_MaxCampacity, expectedAmountOfFuel);
            }
            else
            {
                m_CurrentCampacity = expectedAmountOfFuel;
            }
            // throw execption if exceeded
        }
    }
}
