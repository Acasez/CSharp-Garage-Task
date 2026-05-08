using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Garage_Task
{
    abstract class Vehicle
    {
        public string Name { get; private set; }
        public int Wheels { get; private set; } = 4;
        public String RegisterID { get; private set; }
        public Garage.VehicleColors Color { get; private set; }
        public Garage.VehicleTypes VehicleType { get; private set; }

        public readonly int parkedNumber;
        public Vehicle (string name, string registerID, Garage.VehicleColors color, Garage.VehicleTypes vehicleType, int parkedNumber)
        {
            Name = name;
            RegisterID = registerID;
            Color = color;
            VehicleType = vehicleType;
            this.parkedNumber = parkedNumber;
        }

        public override string ToString()
        {
            return VehicleType.ToString() + ": " + Name + " with ID " + RegisterID + " of color " + Color.ToString();
        }
    }
}
