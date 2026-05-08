using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Garage_Task
{
    internal class Car : Vehicle
    {
        public Car(string name, string registerID, Garage.VehicleColors color) : base(name, registerID, color)
        {
        }
    }
}
