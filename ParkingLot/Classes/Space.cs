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
        Space Left, Right;
        int row, number;
        SpaceSize size;
        bool spaceTaken;
        VehicleInterface spaceVehicle;
        public Space(int row, int number, SpaceSize size)
        {
            this.row = row;
            this.number = number;
            this.size = size;
        }
        public void setLeft(Space space)
        {
            this.Left = space;

        }

        public Space getLeft() => this.Left;

        public void setRight(Space space)
        {
            this.Right = space ;

        }
        public Space getRight() => this.Right;

        public SpaceSize getSize() => this.size;

        public int Number() => this.number;

        public int Row() => this.row;

        public bool isTaken() => this.spaceTaken;

        public void takeSpace(VehicleInterface vehicle)
        {
            this.spaceVehicle = vehicle;
        }

        public VehicleInterface vehicleInSpace() => this.spaceVehicle;
        public string PrintRight()
        {
            if(getRight() != null)
            {
                return getRight().Print();
            }

            return "NO SPACE" + Environment.NewLine;
        }
        public string Print()
        {
            if (this.isTaken())
            {
                return this.spaceVehicle.getType().ToString() + " " + PrintRight();
            }

            return "EMPTY" + " " + PrintRight();
            
        }
    }
}
