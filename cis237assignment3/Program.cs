//Jeffrey Martin
//CIS 237 Assignment 3
//Due 10-19-2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            string materialTest = "plastic";
            string DroidTypeTest = "Protoco"; 
            string colorTest = "red";
            int numberLanguagesTest = 1000;
            Droid testDroid = new Protocol(materialTest, DroidTypeTest, colorTest, numberLanguagesTest);
            Droid testDroid2 = new Utility("steele", "Utility", "white", true, true, true);
            Droid testDroid3 = new Janitor("Plass-Steele", "Janitor", "blue", true, true, false, true, true);

            Console.WriteLine(testDroid);
           // testDroid.CalculateBaseCost();
            testDroid.CalculateTotalCost();
            Console.WriteLine(testDroid.TotalCost.ToString());

            Console.WriteLine(testDroid2);
            //testDroid2.CalculateBaseCost();
            testDroid2.CalculateTotalCost();
            Console.WriteLine(testDroid2.TotalCost.ToString());

            Console.WriteLine(testDroid3);
            //testDroid2.CalculateBaseCost();
            testDroid3.CalculateTotalCost();
            Console.WriteLine(testDroid3.TotalCost.ToString());

        }
    }
}
