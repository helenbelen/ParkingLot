using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Interfaces;

namespace ParkingLot.Classes
{
    class ParkingLot : LotInterface
    {
        public List<SpaceInterface> Spaces = new List<SpaceInterface>();

        public void addSpace(SpaceInterface space)
        {
            Spaces.Add(space);
        }
        public string Print()
        {
            return Spaces[0].Print();
        }  


        
    }
}
