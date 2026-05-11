using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Garage_Task
{
    internal class Car : Vehicle
    {
        public int TopSpeed { get; private set; }
        public Car(string name, string registerID, Garage.VehicleColors color, Garage.VehicleTypes vehicleType, int parkedNumber) : base(name, registerID, color, vehicleType, parkedNumber)
        {
            pluralName = "Cars";
        }
    }
}
