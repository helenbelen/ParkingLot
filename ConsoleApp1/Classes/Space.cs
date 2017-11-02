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
        bool spaceTaken = false;
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
        public bool hasRight() => this.getRight() == null ? false : true;
        public bool hasLeft() => this.getLeft() == null ? false : true;

        public void takeSpace(VehicleInterface vehicle)
        {
            this.spaceVehicle = vehicle;
            spaceTaken = true;
        }

        public VehicleInterface vehicleInSpace() => this.spaceVehicle;
       
        public virtual string Print()
        {
           
            if (isTaken())
                return this.vehicleInSpace().GetType().ToString();
            else
                return "|     EMPTY     |";
        }
    }
}
