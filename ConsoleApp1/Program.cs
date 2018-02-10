using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot.Classes;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Lot parkingLot = new Lot(20, 50, 10); 
            string input = "";
            System.Console.WriteLine(parkingLot.ToString());
            System.Console.WriteLine(" ");
            Console.ReadLine();
            
        }
    }
}
