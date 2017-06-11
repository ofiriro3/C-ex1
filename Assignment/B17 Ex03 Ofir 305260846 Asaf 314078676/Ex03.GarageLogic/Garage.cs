using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        List<GarageVehicle> m_Vehicles;


        public Garage()
        {
            m_Vehicles = new List<GarageVehicle>();
        }

        public class GarageVehicle
        {
            private string m_OwnerName;
            private string m_OwnerNumber;
            private eVehicleStatus m_Status;
            Vehicle m_Vehicle;

            public enum eVehicleStatus
            {
                InRepair,
                Repaired,
                Paid
            }

            public GarageVehicle(string i_OwnerName, string i_OwnerNumber, eVehicleStatus i_Status, Vehicle i_Vehicle)
            {
                m_OwnerName = i_OwnerName;
                m_OwnerNumber = i_OwnerNumber;
                m_Status = i_Status;
                m_Vehicle = i_Vehicle;
            }

            public Vehicle Vehicle
            {
                get 
                {
                    return m_Vehicle;
                }
            }

			public eVehicleStatus Status
			{
				get
				{
                    return m_Status;
				}
                set
                {
                    m_Status = value;
                }
			}

            public override string ToString()
            {
                StringBuilder returnString = new StringBuilder();
                returnString.Append(String.Format(
@"Name of owner : {0}
Number of owner : {1}
Status in garage : {2}
"
                , m_OwnerName, m_OwnerNumber, m_Status));
                m_Vehicle.GetType().GetMethod("ToString").Invoke(m_Vehicle, null);
                returnString.Append(m_Vehicle.ToString());

                return returnString.ToString();
            }
        }
        
        public void addNewVehicleToGarage(GarageVehicle io_GarageVehicleToAdd)
        {
            m_Vehicles.Add(io_GarageVehicleToAdd);
        }

        public List<string> GetListOfLicensePlateNumbersOfVehiclesInGarageWithFilter(GarageVehicle.eVehicleStatus i_VehicleStatus)
        {
            List<string> listOfPlateNumbers = new List<string>();

            foreach(GarageVehicle garageVehicle in m_Vehicles)
            {
                if(garageVehicle.Status.Equals(i_VehicleStatus))
                {
                    listOfPlateNumbers.Add(garageVehicle.Vehicle.LicensePlate);
                }
            }

            return listOfPlateNumbers;
        }

		public List<string> GetListOfLicensePlateNumbersOfVehiclesInGarage()
		{
			List<string> listOfPlateNumbers = new List<string>();

			foreach (GarageVehicle garageVehicle in m_Vehicles)
			{
				listOfPlateNumbers.Add(garageVehicle.Vehicle.LicensePlate);
			}

			return listOfPlateNumbers;
		}

        //return true of car was in garage, false if not
        public bool ChangeStateOfVehicle(string i_LicensePlate, GarageVehicle.eVehicleStatus i_NewStatus)
        {
            bool carFound = false;

			foreach (GarageVehicle garageVehicle in m_Vehicles)
			{
                if (garageVehicle.Vehicle.LicensePlate.Equals(i_LicensePlate))
				{
                    carFound = true;
                    garageVehicle.Status = i_NewStatus;
                    break;
				}
			}

            return carFound;
        }

		//return true of car was in garage, false if not
		public bool InflateWheelsOfVehicleToMax(string i_LicensePlate)
        {
            bool carFound = false;

			foreach (GarageVehicle garageVehicle in m_Vehicles)
			{
				if (garageVehicle.Vehicle.LicensePlate.Equals(i_LicensePlate))
				{
					carFound = true;
                    foreach(Wheel wheel in garageVehicle.Vehicle.Wheels)
                    {
                        wheel.InflateToMax();
                    }
                    break;
				}
			}

            return carFound;
        }

		//return true of car was in garage, false if not
        public bool FillGasInGasVehicle(string i_LicensePlate, PowerSource.eFuel i_TypeOfGass, float i_AmountOfGass)
        {
            bool carFound = false;

			foreach (GarageVehicle garageVehicle in m_Vehicles)
			{
				if (garageVehicle.Vehicle.LicensePlate.Equals(i_LicensePlate))
				{
					carFound = true;
                    FuelTank fuelTank = garageVehicle.Vehicle.PowerSource as FuelTank;
                    if (fuelTank == null)
                    {
                        throw new ArgumentException("This vehicle doesn't run on gass");    
                    }

                    else
                    {
                        fuelTank.Charge(i_AmountOfGass, i_TypeOfGass);
                    }
					break;
				}
			}

            return carFound;
        }

        public Garage.GarageVehicle FindCarByLicensePlate(string i_LicensePlate)
        {
            // I've added this function
            GarageVehicle vehicleThatHasThisPlate = null;
            foreach (GarageVehicle vehicle in m_Vehicles )
            {
                if (vehicle.Vehicle.LicensePlate == i_LicensePlate)
                {
                    vehicleThatHasThisPlate = vehicle; 
                    break;
                }
            }

            return vehicleThatHasThisPlate;
        }

        public bool ChargeElectricVehicle(string i_LicensePlate, float i_AmountOfMinutes)
        {
			bool carFound = false;

			foreach (GarageVehicle garageVehicle in m_Vehicles)
			{
				if (garageVehicle.Vehicle.LicensePlate.Equals(i_LicensePlate))
				{
					carFound = true;
                    Battery battery = garageVehicle.Vehicle.PowerSource as Battery;
                    if (battery == null)
					{
						throw new ArgumentException("This vehicle isn't electric");
					}

					else
					{
                        battery.Charge(i_AmountOfMinutes);
					}
					break;
				}
			}

			return carFound;
        }

		public bool PrintGarageVehicle(string i_LicensePlate , out string VehicleDetailsToPrint)
		{
			bool carFound = false;
            VehicleDetailsToPrint = null;

            foreach (GarageVehicle garageVehicle in m_Vehicles)
			{
				if (garageVehicle.Vehicle.LicensePlate.Equals(i_LicensePlate))
				{
					carFound = true;
                    VehicleDetailsToPrint = garageVehicle.ToString();
                    break;
				}
			}

			return carFound;
		}
    }
}
