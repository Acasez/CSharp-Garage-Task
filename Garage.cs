using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Garage_Task
{
    internal class Garage
    {
        public enum VehicleTypes
        {
            Car,
            Motorcycle,
            Boat,
            Airplane
        }
        Vehicle[] vehicles;
        public int GarageCapacity { get; private set; }
        public Garage(int size)
        {
            if (size > 0)
            {
                GarageCapacity = size;
                vehicles = new Vehicle[size];
            }
            else
            {
                throw new ArgumentException("Garage cannot be smaller than 0");
            }
        }
    }
}
