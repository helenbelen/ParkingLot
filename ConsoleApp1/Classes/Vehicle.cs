using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Interfaces;

namespace ParkingLot.Classes
{
    public class Vehicle : VehicleInterface
    {
       
       public Vehicle(VehicleType vType)
        {
            this.TypeofVehicle = vType;
        }

        public VehicleType TypeofVehicle { get; set; }

        public DateTime ParkStart { get; set; }

        public DateTime ParkEnd { get; set; }

        public double Cost { get; set; }

        public double CalculateCost(int rate) => ParkEnd.Subtract(ParkStart).TotalHours * rate;
        
        public void Dispose(){

            this.TypeofVehicle = VehicleType.NULL;
        }
        

    }
}
