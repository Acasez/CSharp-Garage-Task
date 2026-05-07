using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Garage_Task
{
    internal class Garage
    {
        List<Vehicle> vehicles = new List<Vehicle>();
        public int GarageCapacity { get; private set; }
        public Garage(int size)
        {
            if (size > 0)
            {
                GarageCapacity = size;
            }
            else
            {
                throw new ArgumentException("Garage cannot be smaller than 0");
            }
        }
    }
}
