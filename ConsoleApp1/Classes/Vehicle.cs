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
       
        VehicleType type;
        public Vehicle(VehicleType vType)
        {
            this.type = vType;
        }

        public VehicleType getType() => this.type;
    }
}
