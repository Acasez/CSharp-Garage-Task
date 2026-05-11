using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Garage_Task
{
    internal class Airplane : Vehicle
    {
        public int FlightHours { get; private set; }
        public Airplane(string name, string registerID, Garage.VehicleColors color, Garage.VehicleTypes vehicleType, int parkedNumber) : base(name, registerID, color, vehicleType, parkedNumber)
        {
            Wheels = 2;
            pluralName = "Airplanes";
        }
    }
}
