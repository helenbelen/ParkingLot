using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Classes;
using ParkingLot.Interfaces;

namespace ParkingLot.Classes
{
    public class NullSpace : Space
    {
        public NullSpace() : base(-1, -1, SpaceSize.NULL)
        {
            
        }

        public override string Print()
        {
            return "NO SPACE";
        }
    }
}
