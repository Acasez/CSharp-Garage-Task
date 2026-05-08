using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Garage_Task
{
    internal class Boat(string name, string registerID, Garage.VehicleColors color, Garage.VehicleTypes vehicleType) : Vehicle(name, registerID, color, vehicleType)
    {
        //public override string ToString()
        //{
        //    return "Boat: " + Name + " with RegisterID " + RegisterID + " of color " + Color.ToString();
        //}
    }
}
