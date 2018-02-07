using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Interfaces;
using ParkingLot.Classes;

namespace ParkingLot.Classes
{
    public class ParkingLotManager
    {
        ParkingLot lot;
        int rowLength, numberofRows;
        int numberSpaces, numberMotor, numberCompact, numberLarge;

        public ParkingLotManager(int lengthofRow,int spaces)
        {
            rowLength = lengthofRow;
            numberSpaces = spaces;
           
            lot = new ParkingLot();
            LoadLot();
        }

        public void LoadLot()
        {
            numberMotor = (int)(numberSpaces * .10);
            numberCompact = numberSpaces % 2 == 0 ? (numberSpaces / 2) :  (int)(numberSpaces / 2 + .5);
            numberLarge = numberSpaces - numberMotor - numberCompact;
            if (numberLarge + numberCompact + numberMotor != numberSpaces)
            {
                System.Console.Write("An Error Occured When Created Spaces. The Wrong Number Of Spaces Was Calculated. Parking Lot Will Be Empty");

            }
            else
            {
                if (rowLength <= 0 || numberSpaces <= 0)
                {
                    numberofRows = 0;
                }
                else
                {
                    numberofRows = numberSpaces % rowLength == 0 ? (int)numberSpaces / rowLength : (int)(numberSpaces / rowLength + .5);
                }
                int motors = numberMotor;
                int compact = numberCompact;
                int largespaces = numberLarge;


                for (int i = 0; i < numberofRows; i++)
                {
                    for (int t = 0; t < rowLength; t++)
                    {
                        if (motors > 0)
                        {
                            lot.addSpace(this.newMotorSpace(i, t));
                            motors--;
                        }
                        else if (compact > 0)
                        {
                            lot.addSpace(this.newCompactSpace(i, t));
                            compact--;
                        }
                        else
                        {
                            if (largespaces > 0)
                            {
                                lot.addSpace(this.newLargeSpace(i, t));
                                largespaces--;
                            }
                        }

                    }
                    lot.addSpace(new NullSpace());

                }
            }

        }

        public void printLot() => lot.Print();
        
       
        public Space newMotorSpace(int row, int number) => new Space(row, number, SpaceSize.MOTOR_SIZE);
        public Space newCompactSpace(int row, int number) => new Space(row, number, SpaceSize.COMPACT);
        public Space newLargeSpace(int row, int number) => new Space(row, number, SpaceSize.LARGE);

    }
}
