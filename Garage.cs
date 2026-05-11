using System;
using System.Collections.Generic;
using System.Text;
using static CSharp_Garage_Task.Garage;

namespace CSharp_Garage_Task
{
    internal class Garage
    {
        const string vehicleCreation = "Lets create a vehicle. What type do you want?";
        const string vehicleColorChoice = "What color should our vehicle be? \n";
        const string vehicleFilter = "What should we filter for? \n";
            //+ "1 - Vehicle Type \n"
            //+ "2 - Vehicle Color \n"
            //+ "3 - Wheel Count \n";
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

        public enum FilterOptions
        {
            Type,
            Color,
            Wheels,
            Exit
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

        public void DisplayGarageSpaces()
        {
            Helper.WriteMessage("There are " + ParkedVehicles + " vehicles and " + vehicles.Length + " spaces.");
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] != null)
                {
                    Helper.WriteMessage("Space " + i + " - " + vehicles[i].ToString());
                }
                else
                {
                    Helper.WriteMessage("Space " + i + " - No vehicles parked");
                }
            }
        }

        public Vehicle? GetVehicleByID(string ID)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] != null && vehicles[i].RegisterID == ID)
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

            Helper.WriteMessage(vehicleCreation);
            VehicleTypes vehicleType = GetVehicleType();
            if (!Enum.IsDefined(vehicleType))
            {
                return;
            }
            Helper.WriteMessage("Creating " + vehicleType); //If invalid type, return here

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
                case VehicleTypes.Car: //TODO, custom properties
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
                Helper.WriteMessage("Added vehicle " + newVehicle.ToString() + " to garage space " + garageSpace);
                vehicles[(int)garageSpace] = newVehicle;
                ParkedVehicles++;
            }
        }

        internal void RemoveVehicle()
        {
            DisplayGarageSpaces();
            Helper.WriteMessage("Enter the ID of the vehicle you wish to remove");
            string? vehicleID = Console.ReadLine();
            if (GetVehicleByID(vehicleID) != null)
            {
                Vehicle vehicle = GetVehicleByID(vehicleID);
                Helper.WriteMessage("Removing vehicle" + vehicle.ToString());
                vehicles[vehicle.parkedNumber] = null;
                ParkedVehicles --;
                return;
            }
        }

        internal void AddPredefinedVehicle(Vehicle vehicle, int space)
        {
            vehicles[space] = vehicle;
            ParkedVehicles ++;
        }

        internal void ListAllVehiclesOfType()
        {
            VehicleTypes vehicleType = GetVehicleType();

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] != null && vehicles[i].VehicleType == vehicleType)
                {
                    Helper.WriteMessage(vehicles[i].ToString());
                }
            }
        }

        internal void ListAllVehiclesFilterable()
        {
            VehicleTypes? typeFilter = null;
            VehicleColors? colorFilter = null;
            int? wheelCountFilter = null;
            bool looping = true;
            while (looping)
            {
                int fittingVehicles = 0;
                DisplayCurrentFilters(typeFilter, colorFilter, wheelCountFilter);
                for (int i = 0; i < vehicles.Length; i++)
                {
                    if (vehicles[i] != null)
                    {
                        if (typeFilter != null)
                        {
                            if (vehicles[i].VehicleType != typeFilter)
                            {
                                continue;
                            }
                        }
                        if (colorFilter != null)
                        {
                            if (vehicles[i].Color != colorFilter)
                            {
                                continue;
                            }
                        }
                        if (wheelCountFilter != null)
                        {
                            if (vehicles[i].Wheels != wheelCountFilter)
                            {
                                continue;
                            }
                        }
                        fittingVehicles++;
                        Helper.WriteMessage(vehicles[i].ToString());
                    }
                }
                if (fittingVehicles == 0)
                {
                    Helper.WriteWarningMessage("No vehicles fitting filters");
                }
                Helper.WriteMessage(vehicleFilter);
                FilterOptions filter = GetFilterOption();
                Helper.WriteMessage("Setup " + filter);
                switch (filter)
                {
                    case FilterOptions.Type:
                        typeFilter = GetVehicleType();
                        break;
                    case FilterOptions.Color:
                        colorFilter = GetVehicleColor();
                        break;
                    case FilterOptions.Wheels:
                        if (!int.TryParse(Console.ReadLine(), out int wheelCount))
                        {
                            Helper.WriteErrorMessage("Error, not a interger");
                        }
                        wheelCountFilter = wheelCount;
                        break;
                    case FilterOptions.Exit:
                        Helper.WriteMessage("Exiting view");
                        looping = false;
                        break;
                    default:
                        Helper.WriteErrorMessage("Invalid input, select a valid one.");
                        break;
                }
            }
        }

        private static void DisplayCurrentFilters(VehicleTypes? typeFilter, VehicleColors? colorFilter, int? wheelCountFilter)
        {
            if (typeFilter == null && colorFilter == null && wheelCountFilter == null)
            {
                Helper.WriteMessage("No filters currently", ConsoleColor.Green);
            }
            if (typeFilter != null)
            {
                Helper.WriteMessage("Type filter: " + typeFilter, ConsoleColor.Green);
            }
            if (colorFilter != null)
            {
                Helper.WriteMessage("Color filter: " + colorFilter, ConsoleColor.Green);
            }
            if (wheelCountFilter != null)
            {
                Helper.WriteMessage("Wheel count filter: " + wheelCountFilter, ConsoleColor.Green);
            }
        }

        #region Filters
        private static VehicleColors GetVehicleColor()
        {
            foreach (VehicleColors type in Enum.GetValues<VehicleColors>())
            {
                Helper.WriteMessage((int)type + ": Color " + type.ToString());
            }
            if (!int.TryParse(Console.ReadLine(), out int vehicleColorInt))
            {
                Helper.WriteErrorMessage("Error, not a interger");
            }
            if (!Enum.IsDefined(typeof(VehicleColors), vehicleColorInt))
            {
                Helper.WriteErrorMessage("Invalid input, select a valid vehicle color.");
            }
            return (VehicleColors)vehicleColorInt;
        }

        private static VehicleTypes GetVehicleType()
        {
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
            }
            return (VehicleTypes)vehicleTypeInt;
        }

        private static FilterOptions GetFilterOption()
        {
            foreach (FilterOptions type in Enum.GetValues<FilterOptions>())
            {
                Helper.WriteMessage((int)type + ": Vehicle " + type.ToString());
            }
            if (!int.TryParse(Console.ReadLine(), out int vehicleFilterInt))
            {
                Helper.WriteErrorMessage("Error, not a interger");
            }
            if (!Enum.IsDefined(typeof(FilterOptions), vehicleFilterInt))
            {
                Helper.WriteErrorMessage("Invalid input, select a valid vehicle filter.");
            }
            return (FilterOptions)vehicleFilterInt;
        }
        #endregion

        internal void ListVehiclesTypes()
        {
            foreach (VehicleTypes type in Enum.GetValues<VehicleTypes>())
            {
                int vehiclesOfType = 0;
                for (int i = 0; i < vehicles.Length; i++)
                {
                    if (vehicles[i] != null && vehicles[i].VehicleType == type)
                    {
                        vehiclesOfType++;
                    }
                }
                Helper.WriteMessage("There are " + vehiclesOfType + " " + type.ToString() + "s" );
            }
        }
    }
}
