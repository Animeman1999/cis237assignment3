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

            string[] outputString;


            Droid testDroid = new Protocol(materialTest, DroidTypeTest, colorTest, numberLanguagesTest);
            Droid testDroid2 = new Utility("steele", "Utility", "white", true, true, true);
            Droid testDroid3 = new Janitor("Plass-Steele", "Janitor", "blue", true, true, false, true, true);
            Droid testDroid4 = new Astromech("Nevo-Titanium", "Astromech", "orange", true, false, true, true, 10);

            DroidCollection droidCollection = new DroidCollection(1000);
            droidCollection.AddNewItem(materialTest, DroidTypeTest, colorTest, numberLanguagesTest);
            droidCollection.AddNewItem("steele", "Utility", "white", true, true, true);
            droidCollection.AddNewItem("Plass-Steele", "Janitor", "blue", true, true, false, true, true);
            droidCollection.AddNewItem("Nevo-Titanium", "Astromech", "orange", true, false, true, true, 10);

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

            Console.WriteLine(testDroid4);
            //testDroid2.CalculateBaseCost();
            testDroid4.CalculateTotalCost();
            Console.WriteLine(testDroid4.TotalCost.ToString());

            outputString = droidCollection.GetListOfAllDroids();
            Console.WriteLine("****************list****************");
            for (int i =0; i < outputString.Length; i++ )
            {
                Console.WriteLine(outputString[i]);
            }

        }
    }
}
