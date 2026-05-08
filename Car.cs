using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Garage_Task
{
    internal class Car(string name, string registerID, Garage.VehicleColors color) : Vehicle(name, registerID, color)
    {
        public override string ToString()
        {
            return "Car: " + Name + " with RegisterID " + RegisterID + " of color " + Color.ToString();
        }
    }
}
