using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Garage_Task
{
    internal class Bus(string name, string registerID, Garage.VehicleColors color, Garage.VehicleTypes vehicleType, int parkedNumber)
        : Vehicle(name, registerID, color, vehicleType, parkedNumber)
    {

    }
}
