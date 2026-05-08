using System;
using System.Collections.Generic;
using System.Text;
using static CSharp_Garage_Task.Garage;

namespace CSharp_Garage_Task
{
    internal class PredefinedGarages
    {
        internal static Garage LuxuryGarage()
        {
            Garage luxuryGarage = new Garage(5);
            Vehicle fastCar = new Car("Wroom", "24", VehicleColors.Red, VehicleTypes.Car, 0);
            luxuryGarage.AddPredefinedVehicle(fastCar, 0);

            Vehicle coolPlane = new Airplane("Zoom", "87", VehicleColors.Silver, VehicleTypes.Airplane, 1);
            luxuryGarage.AddPredefinedVehicle(coolPlane, 1);

            Vehicle yacht = new Boat("Yacht", "420", VehicleColors.Blue, VehicleTypes.Boat, 2);
            luxuryGarage.AddPredefinedVehicle(yacht, 2);
            return luxuryGarage;
        }
    }
}
