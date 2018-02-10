using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Classes;
using ParkingLot.Interfaces;

namespace TestProject
{
    [TestClass]
    public class LotTest
    {
        Lot parkingLot;
        int rate,NumberSpaces,NumberRows;
        List<Space> filledSpaces;
        public void TestSetup()
        {
            Random random = new Random();
            NumberSpaces = random.Next(50, 101);
            NumberRows = random.Next(5, 10);
            rate = random.Next(20, 40);
                parkingLot = new Lot(rate,NumberSpaces, NumberRows);
        }
        public void ParkVehicles()
        {
            TestSetup();
            Random random = new Random();
            List<Vehicle> vehicles = new List<Vehicle>() { new Vehicle((VehicleType)random.Next(1, 3)), new Vehicle((VehicleType)random.Next(1, 3)), new Vehicle((VehicleType)random.Next(1, 3)) };
            filledSpaces = new List<Space>();
            foreach(Vehicle v in vehicles)
            {
                int spaceNumber = random.Next(1, parkingLot.Spaces);
                parkingLot.Park(spaceNumber, v);
                filledSpaces.Add(parkingLot.AllSpaces[spaceNumber]);
            }
        }
        [TestMethod]
        public void LotInitialized_Correctly()
        {
            TestSetup();
            using (parkingLot)
            {
                int expectedCompact = NumberSpaces % 2 == 0 ? NumberSpaces / 2 : (int)NumberSpaces / 2 + 1;
                int expectedLarge = expectedCompact % 2 == 0 ? expectedCompact / 2 : (int)expectedCompact / 2 + 1;
                int expectedMotor = NumberSpaces - (expectedCompact + expectedLarge);
              
                int actualCompact = parkingLot.EmptyCompactSpaces;
                int actualLarge = parkingLot.EmptyLargeSpaces;
                int actualMotor = parkingLot.EmptyMotorSpaces;
               

                Assert.AreEqual(expectedCompact, actualCompact, "The Number of compact spaces in the parking lot is incorrect");
                Assert.AreEqual(expectedLarge, actualLarge, "The Number of Large spaces in the parking lot is incorrect");
                Assert.AreEqual(expectedMotor, actualMotor, "The Number of Motor spaces in the parking lot is incorrect");
              


            }
        }

        [TestMethod]
        public void LotParking_Works()
        {
            ParkVehicles();
            bool filledCorrectly = true;
            using (parkingLot)
            {
                foreach (KeyValuePair<int,Space> pair in parkingLot.AllSpaces)
                {
                    if(pair.Value.Taken == true && !filledSpaces.Contains(pair.Value))
                    {
                        filledCorrectly = false;
                        break;
                    }
                }

            }

            Assert.AreEqual(true, filledCorrectly, "Lot is not Parking Vehicles Correctly");
        }

        [TestMethod]
        public void LotParking_CorrectEmptyCompactSpaces()
        {
            ParkVehicles();
            int expectFilledCompact = 0;
            foreach(KeyValuePair<int,Space> pair in parkingLot.AllSpaces)
            {
                if(pair.Value.Taken == true && pair.Value.Vehicle.TypeofVehicle == VehicleType.CAR)
                {
                    expectFilledCompact++;
                }
            }
                     
            Assert.AreEqual(parkingLot.TotalCompactSpaces -expectFilledCompact, parkingLot.EmptyCompactSpaces, "The number of empty compact spaces is not being update properly with vehicles park");
        }

        [TestMethod]
        public void LotParking_CorrectEmptyLargeSpaces()
        {
            ParkVehicles();
            int expectedFilledLarge = 0;
            foreach (KeyValuePair<int, Space> pair in parkingLot.AllSpaces)
            {
                if (pair.Value.Taken == true && pair.Value.Vehicle.TypeofVehicle == VehicleType.BUS)
                {
                    expectedFilledLarge++;
                }
            }

            Assert.AreEqual(parkingLot.TotalLargeSpaces - expectedFilledLarge, parkingLot.EmptyLargeSpaces, "The number of empty compact spaces is not being update properly with vehicles park");
        }

        [TestMethod]
        public void LotParking_CorrectEmptyMotorSpaces()
        {
            ParkVehicles();
            int expectedFilledMotor = 0;
            foreach (KeyValuePair<int, Space> pair in parkingLot.AllSpaces)
            {
                if (pair.Value.Taken == true && pair.Value.Vehicle.TypeofVehicle == VehicleType.MOTORCYCLE)
                {
                    expectedFilledMotor++;
                }
            }

            Assert.AreEqual(parkingLot.TotalMotorSpaces - expectedFilledMotor, parkingLot.EmptyMotorSpaces, "The number of empty compact spaces is not being update properly with vehicles park");

        }
    }
}
