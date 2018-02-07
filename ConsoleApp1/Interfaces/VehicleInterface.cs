using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Interfaces
{
    public enum VehicleType
    {
        MOTORCYCLE = 0,
        CAR = 1,
        BUS = 2
    }
   public interface VehicleInterface
    {
        double CalculateCost(int rate); 
    }
}
