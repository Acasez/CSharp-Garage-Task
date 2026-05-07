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
        Console.Write(garageStart);
        if (!int.TryParse(Console.ReadLine(), out int garageSpaces))
        {
            Console.Write("Error, not a interger");
        }

        try
        {
            bool looping = true;
            while (looping)
            {
                LoopDisplay(looping, garageMenu);
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

    public static bool LoopDisplay(bool looping, string garageMenu)
    {
        Console.WriteLine(garageMenu);
        Console.Write("Ditt val: ");

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
                Helper.WriteErrorMessage("Felaktig input, välj 0-4.");
                break;
        }

        Console.WriteLine();
        return looping;
    }
}