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
}