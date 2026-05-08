using CSharp_Garage_Task;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
internal class Program
{
    const string garageMenu = "Welcome to the garage. \n" +
        "Select an option. \n" +
        "0 = Exit \n" +
        "1 = Add vehicle \n" +
        "2 = List garage spaces \n" +
        "3 = Remove vehicle \n" +
        "4 = List all vehicles of a type \n" +
        "5 = List vehicles types \n" +
        "6 = List all vehicles (filterable)";
    const string garageStart = "Lets create a garage. How many spaces do you want in the garage? \n"+
        "Type -1 for predefined luxury garage. \n" +
        "Type -2 for predefined huge garage. \n" +
        "Type -3 for predefined spaced garage";

    public static void Main()
    {
        try
        {
            Console.WriteLine(garageStart);
            if (!int.TryParse(Console.ReadLine(), out int garageSpaces))
            {
                Helper.WriteErrorMessage("Error, not a interger");
            }
            Garage ourGarage = null;

            if (garageSpaces > 0)
            {
                ourGarage = new Garage(garageSpaces);
            }
            switch (garageSpaces)
            {
                case -1:
                    ourGarage = PredefinedGarages.LuxuryGarage();
                    break;
                case -2:
                    ourGarage = PredefinedGarages.HugeGarage();
                    break;
                case -3:
                    ourGarage = PredefinedGarages.SpacedGarage();
                    break;
                default:
                    Helper.WriteErrorMessage("Invalid input, select a valid one.");
                    break;
            }

            bool looping = true;
            while (looping)
            {
                looping = LoopDisplay(looping, ourGarage);
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

    public static bool LoopDisplay(bool looping, Garage garage)
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
                garage.AddVehicle();
                break;
            case "2":
                garage.DisplayGarageSpaces();
                break;
            case "3":
                garage.RemoveVehicle();
                break;
            case "4":
                garage.ListAllVehiclesOfType();
                break;
            case "5":
                garage.ListVehiclesTypes();
                break;
            case "6":
                garage.ListAllVehicles();
                break;
            default:
                Helper.WriteErrorMessage("Invalid input, select a valid one.");
                break;
        }

        Console.WriteLine();
        return looping;
    }
}