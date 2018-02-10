using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Interfaces;

namespace ParkingLot.Classes
{
   public class Space : SpaceInterface
    {
       
        public Space(int row, int number, SpaceSize size)
        {
            Row = row;
            Number = number;
            Size = size;
            Taken = false;
        }
       

        public SpaceSize Size { get; set; }

        public int Number { get; set; }

        public int Row { get; set; }

        public bool Taken { get; set; }

        public Vehicle Vehicle { get; set; }

        public void TakeSpace(Vehicle vehicle)
        {
            Vehicle = vehicle;
            Taken = true;
            
        }

        public void LeaveSpace()
        {
            Vehicle = null;
            Taken = false;
        }
        public override string ToString()
        {
            return "This Space is On Row: " + Row + " and has Space Number: " + Number + " has a Taken Status of " + Taken.ToString();
        }

        public void Dispose()
        {
            this.Taken = false;
            this.Vehicle = null;

        }
        
    }
}
