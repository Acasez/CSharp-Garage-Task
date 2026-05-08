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

        internal static Garage HugeGarage()
        {
            Garage hugeGarage = new Garage(25);
            Vehicle fastCar = new Car("Wroom", "24", VehicleColors.Red, VehicleTypes.Car, 0);
            hugeGarage.AddPredefinedVehicle(fastCar, 0);

            Vehicle mcBike = new Airplane("mcBike", "994MCC", VehicleColors.Black, VehicleTypes.Motorcycle, 1);
            hugeGarage.AddPredefinedVehicle(mcBike, 1);

            Vehicle yesINeedASUV = new Car("yesINeedASUV", "221SUV", VehicleColors.White, VehicleTypes.Car, 2);
            hugeGarage.AddPredefinedVehicle(yesINeedASUV, 2);

            Vehicle fancyElectric = new Car("fancyElectric", "410POW", VehicleColors.Silver, VehicleTypes.Car, 3);
            hugeGarage.AddPredefinedVehicle(fancyElectric, 3);

            Vehicle rustyButWorking = new Car("rustyButWorking", "822YER", VehicleColors.Green, VehicleTypes.Car, 4);
            hugeGarage.AddPredefinedVehicle(rustyButWorking, 4);

            Vehicle schoolBus = new Car("schoolBus", "123BUS", VehicleColors.Yellow, VehicleTypes.Bus, 5);
            hugeGarage.AddPredefinedVehicle(schoolBus, 5);

            Vehicle ordinaryBus = new Car("ordinaryBus", "321BUS", VehicleColors.Red, VehicleTypes.Bus, 6);
            hugeGarage.AddPredefinedVehicle(ordinaryBus, 6);

            Vehicle coolerBike = new Airplane("coolerBike", "995WIN", VehicleColors.Silver, VehicleTypes.Motorcycle, 7);
            hugeGarage.AddPredefinedVehicle(coolerBike, 7);
            return hugeGarage;
        }
    }
}
