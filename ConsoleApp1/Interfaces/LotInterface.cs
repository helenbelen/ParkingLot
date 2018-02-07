using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Interfaces;
using ParkingLot.Classes;

namespace ParkingLot.Interfaces
{
    public interface LotInterface
    {
        string Park(int space, Vehicle vehicle);
        string Leave(int space, Vehicle vehicle);
        

    }
}
