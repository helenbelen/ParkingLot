using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingLot.Classes;
using ParkingLot.Interfaces;

namespace TestProject
{
    [TestClass]
    public class VehicleTest
    {
        Vehicle vehicle;
        public void TestSetUp()
        {
            vehicle = new Vehicle(VehicleType.CAR);
            vehicle.ParkStart = new DateTime(2018, 03, 01, 3, 23, 00);
            vehicle.ParkEnd = new DateTime(2018, 03, 01, 4, 3, 23, 00);
        }

        [TestMethod]
        public void VehicleCalculate()
        {
            Random r = new Random();
            int rate = r.Next(1, 10);
            TestSetUp();
            using (vehicle)
            {
                double expected = rate * vehicle.ParkEnd.Subtract(vehicle.ParkStart).TotalHours;

                Assert.AreEqual(expected, vehicle.CalculateCost(rate), "Vehicle Cost Is Calculated Incorrectly");

            }
        }
    }
}
