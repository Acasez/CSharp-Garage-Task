using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Garage_Task
{
    internal class Boat : Vehicle
    {
        public bool Sail { get; private set; }
        public Boat(string name, string registerID, Garage.VehicleColors color, Garage.VehicleTypes vehicleType, int parkedNumber) : base(name, registerID, color, vehicleType, parkedNumber)
        {
            Wheels = 0;
            pluralName = "Boats";
        }
    }
}
