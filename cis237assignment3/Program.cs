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
    public class Program
    {
        static void Main(string[] args)
        {
            //***************************************
            //Variables
            //***************************************

            string materialTest = "plastic";
            string DroidTypeTest = "Protocol"; 
            string colorTest = "red";
            int numberLanguagesTest = 1000;
            int menuChoice;
            const int DROID_COLLECTION_SIZE = 1000; 
            
            //Create a single DroidCollection to be used for the entire program
            DroidCollection droidCollection = new DroidCollection(DROID_COLLECTION_SIZE);

            //Create a single UserInterface to be used for the entire program
            UserInterface ui = new UserInterface();

            //Create the console to be used
            ui.StartUserInterface();

            //Create the LoadMenu and load the user choice
            menuChoice = ui.LoadMenu();

            // Either user wants to load a droid list or  not
            switch (menuChoice)
            {
                case 1:             
                    droidCollection.AddNewItem(materialTest, DroidTypeTest, colorTest, numberLanguagesTest);
                    droidCollection.AddNewItem("steele", "Utility", "white", true, true, true);
                    droidCollection.AddNewItem("Plass-Steele", "Janitor", "blue", true, true, false, true, true);
                    droidCollection.AddNewItem("Nevo-Titanium", "Astromech", "orange", true, false, true, true, 10);

                    ui.ListLoadedMessage();
         
                    break;
                case 2:// If droidCollection was not created need to start by adding a droid.
                    ui.AddDroidSequence(droidCollection);
                    break;  
            }

            //Continue to loop until the user chooses 4 which is to exit.
            while (menuChoice != 4)
            {
                menuChoice = ui.MainMenu();
                switch (menuChoice)
                {
                    case 1://Print out the droid list
                        ui.PrintDroidList(droidCollection.GetListOfAllDroids());
                        break;
                    case 2://Add a new droid to the DroidCollection
                        ui.AddDroidSequence(droidCollection);
                        break;
                    case 3://Delete a droid from the DroidCollection
                                //Make sure the DroidCollection has Droids in them
                        if(droidCollection.NumberOfDroidsInList > 0)
                        {
                            ui.PrintDroidList(droidCollection.GetListOfAllDroids());
                            ui.DeleteDroid(droidCollection);
                        }
                        else
                        {
                            ui.NoDroidsInListMessage();
                        }
                        
                        break;
                    default://Exit the program
                        ui.ExitMessage();
                        break;
                }
            }
        }
    }
}
