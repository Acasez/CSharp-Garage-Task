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
        public string Color { get; private set; }

        public Vehicle (string name, string registerID, string color)
        {
            Name = name;
            RegisterID = registerID;
            Color = color;
        }

        public override string ToString()
        {
            return "Vehicle: " + Name + " with RegisterID " + RegisterID + " of color " + Color;
        }
    }
}
