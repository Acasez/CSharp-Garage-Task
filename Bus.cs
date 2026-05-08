using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Garage_Task
{
    internal class Bus : Vehicle
    {
        public Bus(string name, string registerID, Garage.VehicleColors color, Garage.VehicleTypes vehicleType, int parkedNumber) : base(name, registerID, color, vehicleType, parkedNumber)
        {
            pluralName = "Busses";
        }
    }
}
