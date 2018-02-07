using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Classes;

namespace ParkingLot.Interfaces
{
    public enum SpaceSize
    {
        MOTOR_SIZE = 0,
        COMPACT = 1,
        LARGE = 2,
        NULL = 3
    }
    interface SpaceInterface
    {
        void TakeSpace(VehicleInterface v);
        void LeaveSpace();
       
    }
}
