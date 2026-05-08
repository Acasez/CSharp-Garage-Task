using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Garage_Task
{
    internal class Garage
    {
        const string vehicleCreation = "Lets create a vehicle. What type do you want?";
        const string vehicleColorChoice = "What color should our vehicle be? \n";
        public enum VehicleTypes
        {
            Car,
            Motorcycle,
            Boat,
            Airplane,
            Bus
        }
        public enum VehicleColors
        {
            White,
            Black,
            Red,
            Blue,
            Green,
            Silver,
            Yellow
        }
        private Vehicle[] vehicles;
        public int GarageCapacity { get; private set; }
        public int ParkedVehicles { get; private set; }
        public Garage(int size)
        {
            if (size > 0)
            {
                GarageCapacity = size;
                vehicles = new Vehicle[size];
            }
            else
            {
                throw new ArgumentException("Garage cannot be smaller than 0");
            }
        }
        public void DisplayVehicles()
        {
            Helper.WriteMessage("There are " + ParkedVehicles + " vehicles");
            for (int i = 0; i < ParkedVehicles; i++) {
                Helper.WriteMessage(vehicles[i].ToString());
            }
        }

        public void DisplayGarageSpaces()
        {
            Helper.WriteMessage("There are " + ParkedVehicles + " vehicles and " + vehicles.Length + " spaces.");
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] != null)
                {
                    Helper.WriteMessage(vehicles[i].ToString() + "parked at space " + i);
                }
                else
                {
                    Helper.WriteMessage("No vehicles parked at space " + i);
                }
            }
        }

        public Vehicle? GetVehicleByID(string ID)
        {
            for (int i = 0; i < ParkedVehicles; i++)
            {
                if (vehicles[i].RegisterID == ID)
                {
                    return vehicles[i];
                }
            }
            return null;
        }

        public bool CheckForGarageSpace()
        {
            if (GarageCapacity > ParkedVehicles)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int? GetFirstEmptySpace()
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    return i;
                }
            }
            return null;
        }

        public void AddVehicle()
        {
            
            if (!CheckForGarageSpace())
            {
                Helper.WriteWarningMessage("Garage Full");
                return;
            }
            int? garageSpace = GetFirstEmptySpace();
            if (garageSpace == null)
            {
                Helper.WriteWarningMessage("No fitting space");
                return;
            }

            Console.WriteLine(vehicleCreation);
            foreach (VehicleTypes type in Enum.GetValues<VehicleTypes>())
            {
                Helper.WriteMessage((int)type + ": " + type.ToString());
            }
            if (!int.TryParse(Console.ReadLine(), out int vehicleTypeInt))
            {
                Helper.WriteErrorMessage("Error, not a interger");
            }
            if (!Enum.IsDefined(typeof(VehicleTypes), vehicleTypeInt))
            {
                Helper.WriteErrorMessage("Invalid input, select a valid vehicle type.");
                return;
            }
            VehicleTypes vehicleType = (VehicleTypes)vehicleTypeInt;
            Console.WriteLine("Creating " + vehicleType);

            Helper.WriteMessage("Write vehicle name: ");
            string vehicleName = Console.ReadLine();
            Helper.WriteMessage("Write register ID");
            string vehicleID = Console.ReadLine();
            if (GetVehicleByID(vehicleID) != null) {
                Helper.WriteWarningMessage("Another vehicle with same ID already parked here");
                return;
            }

            Helper.WriteMessage(vehicleColorChoice);
            foreach (VehicleColors color in Enum.GetValues<VehicleColors>())
            {
                Helper.WriteMessage((int)color + ": " + color.ToString());
            }
            if (!int.TryParse(Console.ReadLine(), out int vehicleColorInt))
            {
                Helper.WriteErrorMessage("Error, not a interger");
            }
            if (!Enum.IsDefined(typeof(VehicleColors), vehicleColorInt))
            {
                Helper.WriteErrorMessage("Invalid input, select a valid vehicle type.");
                return;
            }
            VehicleColors vehicleColor = (VehicleColors)vehicleColorInt;

            Vehicle newVehicle = null;
            switch (vehicleType)
            {
                case VehicleTypes.Car:
                    newVehicle = new Car(vehicleName, vehicleID, vehicleColor, vehicleType, ParkedVehicles);
                    break;
                case VehicleTypes.Motorcycle:
                    newVehicle = new Motorcycle(vehicleName, vehicleID, vehicleColor, vehicleType, ParkedVehicles);
                    break;
                case VehicleTypes.Boat:
                    newVehicle = new Boat(vehicleName, vehicleID, vehicleColor, vehicleType, ParkedVehicles);
                    break;
                case VehicleTypes.Airplane:
                    newVehicle = new Airplane(vehicleName, vehicleID, vehicleColor, vehicleType, ParkedVehicles);
                    break;
                case VehicleTypes.Bus:
                    newVehicle = new Bus(vehicleName, vehicleID, vehicleColor, vehicleType, ParkedVehicles);
                    break;
                default:
                    Helper.WriteErrorMessage("Invalid input, select a valid one.");
                    break;
            }
            if (newVehicle != null)
            {
                vehicles[ParkedVehicles] = newVehicle;
                ParkedVehicles++;
            }
        }

        internal void RemoveVehicle()
        {
            DisplayVehicles();
            Helper.WriteMessage("Enter the ID of the vehicle you wish to remove");
            string? vehicleID = Console.ReadLine();
            if (GetVehicleByID(vehicleID) != null)
            {
                Vehicle vehicle = GetVehicleByID(vehicleID);
                Helper.WriteMessage("Removing vehicle" + vehicle.ToString());
                vehicles[vehicle.parkedNumber] = null;
                return;
            }
        }
    }
}
