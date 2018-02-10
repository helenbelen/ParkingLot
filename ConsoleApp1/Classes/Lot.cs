using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Interfaces;

namespace ParkingLot.Classes
{
    public struct LotInitializer {

        public LotInitializer(int spaces, int rows)
        {
            Spaces = spaces;
            Rows = rows;
            CompactSpaces = spaces % 2 == 0 ? spaces/2 : (int)spaces/2 + 1;
            LargeSpaces = CompactSpaces %2 == 0? CompactSpaces/2 : (int)CompactSpaces/2 + 1;
            MotorSpaces = Spaces - (CompactSpaces + LargeSpaces);
        }
        public int Spaces { get; set; }
        public int CompactSpaces { get; set; }
        public int LargeSpaces { get; set; }
        public int MotorSpaces { get; set; }
        public int Rows { get; set; }
        public int SpacesPerRow() => Spaces%Rows == 0 ? Spaces/Rows : (int)Spaces/Rows + 1;
      
    }

    public class Lot : LotInterface
    {
        Dictionary<int, Space> lotSpaces;
        LotInitializer lotInitializer;
        public Lot(int rate,int numberofSpaces, int numberOfRows)
        {
            Rate = rate; 
            Spaces = numberofSpaces;
            
            
            lotSpaces = new Dictionary<int, Space>();
            lotInitializer = new LotInitializer(numberofSpaces, numberOfRows);
            Rows = lotInitializer.Rows;
            EmptySpaces = lotInitializer.Spaces;
            EmptyLargeSpaces = lotInitializer.LargeSpaces;
            EmptyCompactSpaces = lotInitializer.CompactSpaces;
            EmptyMotorSpaces = lotInitializer.MotorSpaces;
            TotalCompactSpaces = lotInitializer.CompactSpaces;
            TotalLargeSpaces = lotInitializer.LargeSpaces;
            TotalMotorSpaces = lotInitializer.MotorSpaces;


            int rowStart = 0;
            for(int i = 0 ; i < lotInitializer.Rows; i++)
            {
                
                for (int j = rowStart; j < lotInitializer.SpacesPerRow() + rowStart; j++)
                {
                    if (lotInitializer.CompactSpaces > 0)
                    {
                        lotSpaces.Add(j, new Space(i, j, SpaceSize.COMPACT));
                        lotInitializer.CompactSpaces--;
                    }
                    else if (lotInitializer.LargeSpaces > 0)
                    {
                        lotSpaces.Add(j, new Space(i, j, SpaceSize.LARGE));
                        lotInitializer.LargeSpaces--;
                    }
                    else
                    {
                        lotSpaces.Add(j, new Space(i, j, SpaceSize.MOTOR_SIZE));
                        lotInitializer.MotorSpaces--;
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
                GetEmtpy(lotSpaces[space].Size);
                vehicle.ParkStart = DateTime.Now;
                return lotSpaces[space].ToString() + "Please remember the space number.";
            }
            return "This space is either full or not avaialable for your vehicle type. Choose another space";
        }

        public string Leave (int space, Vehicle vehicle)
        {
            if (!IsAvailable(space, vehicle))
            {
                vehicle.ParkEnd = DateTime.Now;
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
        public int TotalCompactSpaces { get; set; }
        public int TotalLargeSpaces { get; set; }
        public int TotalMotorSpaces { get; set; }
        public int Rows { get; set; }
        public Dictionary<int,Space> AllSpaces { get { return lotSpaces; } }



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

        public override string ToString()
        {
            string output = "";
            foreach(KeyValuePair<int,Space> pair in lotSpaces)
            {
                output = output + pair.Value.ToString() + System.Environment.NewLine;
            }
            return output;
        }

        public void Dispose()
        {
            lotSpaces.Clear();
           
        }
        
    }
}
