using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Garage_Task
{
    internal class Garage
    {
        const string vehicleCreation = "Lets create a vehicle. What type do you want?" +
            "1 = Car \n" +
            "2 = Motorcycle \n" +
            "3 = Boat \n" +
            "4 = Airplane \n";
        public enum VehicleTypes
        {
            Car,
            Motorcycle,
            Boat,
            Airplane
        }
        Vehicle[] vehicles;
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
            Console.WriteLine("Displaying vehicles");
            for (int i = 0; i < ParkedVehicles; i++) {
                Console.WriteLine(vehicles[i].ToString());
            }
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

        public void AddVehicle()
        {
            if (!CheckForGarageSpace())
            {
                Helper.WriteWarningMessage("Garage Full");
                return;
            }
            Console.WriteLine(vehicleCreation);
            Console.Write("Your choice: ");

            string? input = Console.ReadLine();
            VehicleTypes vehicleType = VehicleTypes.Car;

            switch (input)
            {
                case "1":
                    Console.WriteLine("Creating car");
                    break;
                case "2":
                    Console.WriteLine("Creating motorcycle");
                    vehicleType = VehicleTypes.Motorcycle;
                    break;
                case "3":
                    Console.WriteLine("Creating boat");
                    vehicleType = VehicleTypes.Boat;
                    break;
                case "4":
                    Console.WriteLine("Creating airplane");
                    vehicleType = VehicleTypes.Airplane;
                    break;
                default:
                    Helper.WriteErrorMessage("Invalid input, select a valid one.");
                    break;
            }
            Console.Write("Write vehicle name: ");
            string vehicleName = Console.ReadLine();
            Console.Write("Write register ID");
            string vehicleID = Console.ReadLine();
            Console.Write("Write vehicle color");
            string vehicleColor = Console.ReadLine();
            Vehicle newVehicle = null;
            switch (vehicleType)
            {
                case VehicleTypes.Car:
                    newVehicle = new Car(vehicleName, vehicleName, vehicleColor);
                    break;
                case VehicleTypes.Motorcycle:
                    newVehicle = new Motorcycle(vehicleName, vehicleName, vehicleColor);
                    break;
                case VehicleTypes.Boat:
                    newVehicle = new Boat(vehicleName, vehicleName, vehicleColor);
                    break;
                case VehicleTypes.Airplane:
                    newVehicle = new Airplane(vehicleName, vehicleName, vehicleColor);
                    break;
                default:
                    Helper.WriteErrorMessage("Invalid input, select a valid one.");
                    break;
            }
            if (newVehicle != null)
            {
                vehicles[ParkedVehicles] = newVehicle;
            }
            ParkedVehicles++;
        }
    }
}
