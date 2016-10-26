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
    public class DroidCollection : IDroidCollection
    {
        //***************************************
        //Variables
        //***************************************
        Droid[] droidItemsCollection;
        int droidItemsLengthInt;

        //***************************************
        //Properties
        //***************************************

        public int NumberOfDroidsInList
        {
            get { return droidItemsLengthInt; }
        }


        //***************************************
        //Method
        //***************************************

        public void AddNewItem(string MaterialString, string ModelString, string ColorString, int NumberLanguagesInt)
        {
            droidItemsCollection[droidItemsLengthInt] = new Protocol(MaterialString, ModelString, ColorString, NumberLanguagesInt);
            droidItemsLengthInt++;
        }

        public void AddNewItem(string MaterialString, string ModelString, string ColorString, bool ToolboxBool, bool ComputerConnectionBool, bool ArmBool)
        {
            droidItemsCollection[droidItemsLengthInt] = new Utility(MaterialString, ModelString, ColorString, ToolboxBool, ComputerConnectionBool, ArmBool);
            droidItemsLengthInt++;
        }

        public void AddNewItem(string MaterialString, string ModelString, string ColorString, bool ToolboxBool,
            bool ComputerConnectionBool, bool ArmBool, bool TrashCompactorBool, bool VacuumBool)
        {
            droidItemsCollection[droidItemsLengthInt] = new Janitor(MaterialString, ModelString, ColorString, ToolboxBool,
            ComputerConnectionBool, ArmBool, TrashCompactorBool, VacuumBool);
            droidItemsLengthInt++;
        }

        public void AddNewItem(string MaterialString, string ModelString, string ColorString, bool ToolboxBool,
            bool ComputerConnectionBool, bool ArmBool, bool FireExtinquisher, int NumberShips)
        {
            droidItemsCollection[droidItemsLengthInt] = new Astromech(MaterialString, ModelString, ColorString, ToolboxBool,
            ComputerConnectionBool, ArmBool, FireExtinquisher, NumberShips);
            droidItemsLengthInt++;
        }

        public void DeleteItem(int ItemToDelete)
        {
            if (droidItemsLengthInt > 0)
            {
                for (int index = ItemToDelete; index < droidItemsLengthInt -1; index++)
                {
                    droidItemsCollection[index] = droidItemsCollection[index + 1];
                }
                droidItemsCollection[droidItemsLengthInt -1] = null;
                droidItemsLengthInt = droidItemsLengthInt -1;
            }
                
        }
        public string[] GetListOfAllDroids()
        {
            string[] listOfAllDroids = new string[droidItemsLengthInt];
            int counter = 0;
            if (droidItemsLengthInt > 0 )
            {
                foreach (Droid droid in droidItemsCollection)
                {
                    if (droid != null)
                    {
                        droid.CalculateTotalCost();
                        listOfAllDroids[counter] = (counter + 1) + ") " + droid.ToString() + Environment.NewLine +
                            " ***** Total Cost = " + droid.TotalCost + " *****";
                        counter++;
                    }
                }
            }

            return listOfAllDroids;
        }

        public string GetASingleDroid(int WhichDroid)
        {
            return droidItemsCollection[WhichDroid].ToString();
        }


        //***************************************
        //Constructor
        //***************************************

        public DroidCollection (int Size)
        {
            droidItemsCollection = new Droid[Size];
            droidItemsLengthInt = 0;
        }

    }
}
