using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Interfaces;

namespace ParkingLot.Classes
{
    public struct LotInitializer {

        public LotInitializer(int spaces, int rows, int compact, int large, int motor)
        {
            Spaces = spaces;
            Rows = rows;
            CompactSpaces = compact;
            LargeSpaces = large;
            MotorSpaces = motor;
        }
        public int Spaces { get; set; }
        public int CompactSpaces { get; set; }
        public int LargeSpaces { get; set; }
        public int MotorSpaces { get; set; }
        public int Rows { get; set; }
        public int SpacesPerRow() => Spaces%Rows == 0 ? Spaces/Rows : Spaces/Rows + 1;
        
        

    }

    class ParkingLot : LotInterface
    {
        Dictionary<int, Space> lotSpaces;
        LotInitializer lotInitializer;
        public ParkingLot(int rate,int numberofSpaces, int numberOfRows, int numberofCompact = 0, int numberofLarge = 0, int numberofMotor =0)
        {
            Rate = rate; 
            Spaces = numberofSpaces;
            Rows = numberOfRows;
            EmptyLargeSpaces = numberofLarge;
            EmptyCompactSpaces = numberofCompact;
            EmptyMotorSpaces = numberofMotor;
            

            
            lotSpaces = new Dictionary<int, Space>();
            lotInitializer = new LotInitializer(numberofSpaces, numberOfRows, numberofCompact,numberofLarge,numberofMotor);
            int rowStart = 0;
            for(int i = 0 ; i < lotInitializer.Rows; i++)
            {
                
                for (int j = rowStart; j < lotInitializer.SpacesPerRow() + rowStart; j++)
                {
                    if (lotInitializer.CompactSpaces > 0)
                    {
                        lotSpaces.Add(j, new Space(i, j, SpaceSize.COMPACT));
                        lotInitializer.CompactSpaces -= lotInitializer.CompactSpaces;
                    }
                    else if (lotInitializer.LargeSpaces > 0)
                    {
                        lotSpaces.Add(j, new Space(i, j, SpaceSize.LARGE));
                        lotInitializer.LargeSpaces -= lotInitializer.CompactSpaces;
                    }
                    else
                    {
                        lotSpaces.Add(j, new Space(i, j, SpaceSize.MOTOR_SIZE));
                        lotInitializer.MotorSpaces -= lotInitializer.MotorSpaces;
                    }
                }

                rowStart += lotInitializer.SpacesPerRow();

            }


        }
        public string Park(int space, Vehicle vehicle)
        {
            if (IsAvailable(space, vehicle))
            {
                lotSpaces[space].TakeSpace(vehicle);
                return lotSpaces[space].ToString() + "Please remember the space number.";
            }
            return "This space is either full or not avaialable for your vehicle type. Choose another space";
        }

        public string Leave (int space, Vehicle vehicle)
        {
            if (!IsAvailable(space, vehicle))
            {
                double cost = lotSpaces[space].Vehicle.CalculateCost(Rate);
                lotSpaces[space].LeaveSpace();
                return lotSpaces[space].ToString() + "You owe $" + cost;
            }

            return "This space is not taken. Please ensure you have the correct space number.";
        }
        public int Rate { get; set; }
        public int Spaces { get; set; }
        public int EmptySpaces { get; set; }
        public int EmptyCompactSpaces { get; set; }
        public int EmptyLargeSpaces { get; set; }
        public int EmptyMotorSpaces { get; set; }
        public int Rows { get; set; }


        public bool IsAvailable(int space, Vehicle vehicle)
        {
            foreach (KeyValuePair<int, Space> pair in lotSpaces)
            {
                if (pair.Key == space && pair.Value.Taken == false)
                {
                   if(vehicle.TypeofVehicle == VehicleType.BUS && pair.Value.Size == SpaceSize.LARGE)
                    {
                        return true;
                    }
                   else if(vehicle.TypeofVehicle == VehicleType.CAR && pair.Value.Size == SpaceSize.COMPACT)
                    {
                        return true;
                    }
                   else if(vehicle.TypeofVehicle == VehicleType.MOTORCYCLE && pair.Value.Size == SpaceSize.MOTOR_SIZE)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void GetEmtpy(SpaceSize size)
        {
            int empty = 0;
            foreach(KeyValuePair<int,Space> pair in lotSpaces)
            {
                if(pair.Value.Size == size && pair.Value.Taken == false)
                {
                    empty++;
                }
            }

            switch (size) {
                case SpaceSize.COMPACT:
                    EmptyCompactSpaces = empty;
                    break;
                case SpaceSize.LARGE:
                    EmptyLargeSpaces = empty;
                    break;
                case SpaceSize.MOTOR_SIZE:
                    EmptyMotorSpaces = empty;
                    break;
                default:
                    break;

            }


        }
        
    }
}
