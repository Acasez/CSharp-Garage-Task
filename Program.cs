using CSharp_Garage_Task;
using System;
using System.Collections.Generic;
using System.Linq;
internal class Program
{
    const string garageMenu = "Welcome to the garage. \n" +
        "Select an option. \n" +
        "0 = Exit \n" +
        "1 = Add vehicle \n" +
        "2 = List all vehicles \n";
    const string garageStart = "Lets create a garage. How many spaces do you want in the garage?";

    public static void Main()
    {
        try
        {
            Console.Write(garageStart);
            if (!int.TryParse(Console.ReadLine(), out int garageSpaces))
            {
                Helper.WriteErrorMessage("Error, not a interger");
            }
            Garage ourGarage = new Garage(garageSpaces);

            bool looping = true;
            while (looping)
            {
                looping = LoopDisplay(looping);
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            Console.ResetColor();
        }
    }

    public static bool LoopDisplay(bool looping)
    {
        Console.WriteLine(garageMenu);
        Console.Write("Your choice: ");

        string? input = Console.ReadLine();

        switch (input)
        {
            case "0":
                looping = false;
                Console.WriteLine("Leaving the garage");
                break;
            case "1":
                Console.WriteLine("Todo, add vehicle");
                break;
            case "2":
                Console.WriteLine("Todo, display vehicles");
                break;
            default:
                Helper.WriteErrorMessage("Invalid input, select a valid one.");
                break;
        }

        Console.WriteLine();
        return looping;
    }

    const string vehicleCreation = "Lets create a vehicle. What type do you want?" +
        "1 = Car \n" +
        "2 = Motorcycle \n" +
        "3 = Boat \n" +
        "4 = Airplane \n";


    public static void AddVehicle()
    {
        Console.WriteLine(vehicleCreation);
        Console.Write("Your choice: ");

        string? input = Console.ReadLine();
        Garage.VehicleTypes vehicleType = Garage.VehicleTypes.Car;
        
        switch (input)
        {
            case "1":
                Console.WriteLine("Creating car");
                break;
            case "2":
                Console.WriteLine("Creating motorcycle");
                vehicleType = Garage.VehicleTypes.Motorcycle;
                break;
            case "3":
                Console.WriteLine("Creating boat");
                vehicleType = Garage.VehicleTypes.Boat;
                break;
            case "4":
                Console.WriteLine("Creating airplane");
                vehicleType = Garage.VehicleTypes.Airplane;
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
            case Garage.VehicleTypes.Car:
                newVehicle = new Car(vehicleName, vehicleName, vehicleColor);
                break;
            case Garage.VehicleTypes.Motorcycle:
                newVehicle = new Car(vehicleName, vehicleName, vehicleColor);
                break;
            case "3":
                Console.WriteLine("Creating boat");
                vehicleType = Garage.VehicleTypes.Boat;
                break;
            case "4":
                Console.WriteLine("Creating airplane");
                vehicleType = Garage.VehicleTypes.Airplane;
                break;
            default:
                Helper.WriteErrorMessage("Invalid input, select a valid one.");
                break;
        }
    }
}