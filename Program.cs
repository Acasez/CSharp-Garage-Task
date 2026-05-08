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
        "2 = List garage spaces \n" +
        "3 = Remove vehicle \n" +
        "4 = List all vehicles of a type \n" +
        "5 = List vehicles types";
    const string garageStart = "Lets create a garage. How many spaces do you want in the garage? \n"+
        "Type -1 for predefined luxury garage.";

    public static void Main()
    {
        try
        {
            Console.Write(garageStart);
            if (!int.TryParse(Console.ReadLine(), out int garageSpaces))
            {
                Helper.WriteErrorMessage("Error, not a interger");
            }
            Garage ourGarage = null;
            if (garageSpaces == -1)
            {
                ourGarage = PredefinedGarages.LuxuryGarage();
            }
            else
            {
                ourGarage = new Garage(garageSpaces);
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
            default:
                Helper.WriteErrorMessage("Invalid input, select a valid one.");
                break;
        }

        Console.WriteLine();
        return looping;
    }
}