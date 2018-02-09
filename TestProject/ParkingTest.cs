using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.Classes;
using ParkingLot.Interfaces;


namespace TestProject
{
    [TestClass]
    public class SpaceTest
    {
        Space space;
        int[] spaceParameters;

        [TestMethod]
        public void CreateSpace_Correctly()
        {
            spaceParameters = getSpaceInputs();
            using (space)
            {
                space = new Space(spaceParameters[0], spaceParameters[1], (SpaceSize)spaceParameters[2]);
                Assert.AreEqual(spaceParameters[0], space.Row, "Space Row was not set correctly");
                Assert.AreEqual(spaceParameters[1], space.Number, "Space Number was not set correctly");
                Assert.AreEqual((SpaceSize)spaceParameters[2], space.Size, "Space Size was not set correctly");
            }


        }

        [TestMethod]
        public void TakeSpace_Works()
        {
            spaceParameters = getSpaceInputs();
            using (space)
            {
                space = new Space(spaceParameters[0], spaceParameters[1], (SpaceSize)spaceParameters[2]);
                switch (space.Size)
                {
                    case SpaceSize.COMPACT:
                        space.TakeSpace(new Vehicle(VehicleType.CAR));
                        break;
                    case SpaceSize.LARGE:
                        space.TakeSpace(new Vehicle(VehicleType.BUS));
                        break;
                    case SpaceSize.MOTOR_SIZE:
                        space.TakeSpace(new Vehicle(VehicleType.MOTORCYCLE));
                        break;
                    default:
                        break;

                }

                Assert.AreEqual(true, space.Taken, "Space was not 'Taken' correctly");
            }
            

        }

        [TestMethod]
        public void LeaveSpace_Works()
        {
            spaceParameters = getSpaceInputs();
            using (space)
            {
                space = new Space(spaceParameters[0], spaceParameters[1], (SpaceSize)spaceParameters[2]);
                switch (space.Size)
                {
                    case SpaceSize.COMPACT:
                        space.TakeSpace(new Vehicle(VehicleType.CAR));
                        break;
                    case SpaceSize.LARGE:
                        space.TakeSpace(new Vehicle(VehicleType.BUS));
                        break;
                    case SpaceSize.MOTOR_SIZE:
                        space.TakeSpace(new Vehicle(VehicleType.MOTORCYCLE));
                        break;
                    default:
                        break;

                }
                space.LeaveSpace();

                Assert.AreEqual(false, space.Taken, "Space was not 'Left' correctly");

            }


        }

        public int[] getSpaceInputs()
        {
            Random r = new Random();
            int row = r.Next(1, 10);
            int space = r.Next(10, 20);
            int size = r.Next(-1, 3);

            return new int[] { row, space, size };

        }

    }
}
