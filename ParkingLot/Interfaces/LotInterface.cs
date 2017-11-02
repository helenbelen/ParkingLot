using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Interfaces;

namespace ParkingLot.Interfaces
{
    interface LotInterface
    {
        string Print();
        void addSpace(SpaceInterface s);

    }
}
