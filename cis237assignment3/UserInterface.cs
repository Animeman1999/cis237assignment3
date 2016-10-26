//Jeffrey Martin
//CIS 237 Assignment 3
//Due 10-19-2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;//Needed to maxamize the console
using System.Runtime.InteropServices;//Needed to maxamize the console

namespace cis237assignment3
{
    public class UserInterface
    {
        //***************************************
        //Variables
        //***************************************

        //Utility Droids
        bool toolboxBool;
        bool computerConnectionBool;
        bool armBool;

        string[,] _materialList =
                { { "plastic", ".5" },
                {"steele", "1" },
                {"Plass-Steele", "1.5"},
                {"Nevo-Titanium", "2" },
                {"Areogel","2.5" },
                {"Atomic-Aluminum","5" }};

        string[] _droidList = { "Protocol", "Utility", "Janitor", "Astromech" };

        //****************************************Code to Maxamize the Console***********************
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        /// <summary>
        /// Method to maxamize the console window
        /// </summary>
        private static void MaximizeConsole()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
        }
        //************************************End Code to Maxamize the Console***********************

            /// <summary>
            /// Adjust the console to increase the console buffer, change the title and maxamize the window
            /// </summary>
        public void StartUserInterface()
        {
            Console.BufferHeight = Int16.MaxValue - 1;
            Console.Title = "Jawas of Tatooine Droids Sales List Program";
            MaximizeConsole();
        }

        /// <summary>
        /// Print out the Load Menu and returns the input from the user
        /// </summary>
        /// <returns>ConsoleKeyInfo</returns>
        private ConsoleKeyInfo LoadMenuMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.Write("- Load Menu -");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1) Load Droid list");
            Console.WriteLine("2) Continue without loading Droid list");
            Console.WriteLine("3) Exit");
            Console.WriteLine("Press number of item you wish to do.");

            return Console.ReadKey();
        }

        /// <summary>
        /// Makes sure the user enters valid data from LoadMenuMessage and returns it after casting it into an integer
        /// </summary>
        /// <returns>int</returns>
        public int LoadMenu()
        {
            ConsoleKeyInfo inputChar = LoadMenuMessage();
            Console.WriteLine();

            //Continue getting user input until the user enters valid input
            while (inputChar.KeyChar != '1' && inputChar.KeyChar != '2' && inputChar.KeyChar != '3')
            {
                ErrorMessage();
                inputChar = LoadMenuMessage();
                Console.WriteLine();
            }
            return int.Parse(inputChar.KeyChar.ToString());
        }

        /// <summary>
        /// Prints out the List Loaded message
        /// </summary>
        public void ListLoadedMessage()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.Write("- List Loaded -");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        /// <summary>
        /// Print out the Main Menu and returns the input from the user
        /// </summary>
        /// <returns>ConsoleKeyInfo</returns>
        private ConsoleKeyInfo MainMenuMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.Write("- Main Menu -");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1) Print Droid list");
            Console.WriteLine("2) Add Droid to list");
            Console.WriteLine("3) Delete Droid from list");
            Console.WriteLine("4) Exit");
            Console.WriteLine("Press number of item you wish to do.");
            return Console.ReadKey();
        }

        /// <summary>
        /// Makes sure the user enters valid data from ManMenuMessage and returns it after casting it into an integer
        /// </summary>
        /// <returns>int</returns>
        public int MainMenu()
        {
            ConsoleKeyInfo inputChar = MainMenuMessage();
            Console.WriteLine();

            //Continue getting user input until the user enters valid input
            while (inputChar.KeyChar != '1' && inputChar.KeyChar != '2' && inputChar.KeyChar != '3' && inputChar.KeyChar != '4')
            {
                ErrorMessage();
                inputChar = MainMenuMessage();
                Console.WriteLine();
            }
            return int.Parse(inputChar.KeyChar.ToString());
        }

        /// <summary>
        /// Prints out the Droid List
        /// </summary>
        /// <param name="OutputString">string[]</param>
        public void PrintDroidList(string[] OutputString)
        {
            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.Write("- Start List -");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine();

            //Takes the OutputString passed in and prints out each item as a seperate line
            for (int i = 0; i < OutputString.Length; i++)
            {
                Console.WriteLine(OutputString[i]);
                Console.WriteLine();
            }
            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.Write("- End List -");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine();
        }

        /// <summary>
        /// Adds a droid to the Droid Collection by getting user information
        /// </summary>
        /// <param name="droidCollection">DroidCollection</param>
        public void AddDroidSequence(DroidCollection droidCollection)
        {
            //***************************************
            //Local Variables
            //***************************************

            //All Droids
            string materialString;
            string modelString;
            string colorString;

            //Protocol Droids
            int numberLanguagesInt;

            //Janitor Droids
            bool trashCompactorBool;
            bool vacuumBool;

            //Astromech Droids
            bool fireExtinquisher;
            int numberShips;


            //Get the user data of the type of droid to be added
            ConsoleKeyInfo inputChar = DroidTypeMenu();
            Console.WriteLine();

            //Make sure the user inputs the correct data
            while (inputChar.KeyChar != '1' && inputChar.KeyChar != '2' && inputChar.KeyChar != '3' && inputChar.KeyChar != '4')
            {
                ErrorMessage();
                inputChar = DroidTypeMenu();
                Console.WriteLine();
            }

            // Parse the validated user data 
            int droidTypeInputInt = int.Parse(inputChar.KeyChar.ToString());

            //Get the type of the Droid from the modelString
            modelString = _droidList[droidTypeInputInt - 1];       

            //Get the type of materail from the user
            int materialTypeInputInt = DroidMaterialMenu();

            //Get the type of material from the materalString based on the user input
            materialString = _materialList[materialTypeInputInt - 1, 0];

            //Get the color from the user
            colorString = DroidColorMenu();

            //Takes the base droid type and get additonal information for each droid type than adds the droid to the DroidCollection
            switch (droidTypeInputInt)
            {
                case 1: //Protocol
                    //Get the number of languges from the user
                    numberLanguagesInt = NumberInput("How many languages do you wish the droid to understand?");
                    //Add droid to DroidCollection
                    droidCollection.AddNewItem(materialString, modelString, colorString, numberLanguagesInt);                   
                    break;
                case 2://Utility
                    //Call the method to get the input from user for the Utility Droid
                    BaseUtilityDroidInputs();
                    //Add droid to DroidCollection
                    droidCollection.AddNewItem(materialString, modelString, colorString, toolboxBool, computerConnectionBool, armBool);
                    break;
                case 3://Janitor
                    //Call the method to get the input from user for the Utility Droid
                    BaseUtilityDroidInputs();
                    //Find out if the user wants a trash compactor
                    trashCompactorBool = BoolInput("Do you wish for your droid to have a trash compactor");
                    //Find out if the user wants a Vacuum
                    vacuumBool = BoolInput("Do you wish for your droid to have a vacuum");
                    //Add droid to DroidCollection
                    droidCollection.AddNewItem(materialString, modelString, colorString,
                        toolboxBool, computerConnectionBool, armBool, trashCompactorBool, vacuumBool);
                    break;
                default://Astromech
                    //Call the method to get the input from user for the Utility Droid
                    BaseUtilityDroidInputs();
                    //Find out if the user wants a fire extinguiser
                    fireExtinquisher = BoolInput("Do you wish for your droid to have fire extinquisher");
                    //Find out the number of ships the mech has data on
                    numberShips = NumberInput("How many ships do you wish the droid to have data on?");
                    //Add droid to DroidCollection
                    droidCollection.AddNewItem(materialString, modelString, colorString,
                        toolboxBool, computerConnectionBool, armBool, fireExtinquisher, numberShips);
                    break;

            }
            //Print out the Droid added message
            DroidAddedMessage();

        }

        /// <summary>
        /// Finds out which Droid the user wants deleted and deletes it
        /// </summary>
        /// <param name="droidCollection">DroidCollection</param>
        public void DeleteDroid(DroidCollection droidCollection)
        {
            //Gets the number of the droid to be deleted from the user
            int droidNumber = GetDroidNumber(droidCollection);

            //Output the message to confirm the droid to be deleted.
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Droid to delete:");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            //Calls the method to print out a single droid from the DroidCollection
            Console.WriteLine(droidCollection.GetASingleDroid(droidNumber));
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            //Gets the user input to confirm to delete the droid
            bool deleteDroid = BoolInput("Are you sure you want to delete the prevous droid?");

            if (deleteDroid)
            {//Delete the droid now that it has been confirmed and tell the user it has been deleted and reprint the list
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                droidCollection.DeleteItem(droidNumber);
                Console.WriteLine("Droid Delted!");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Gets the number of the droid to delete from the user and validates the data
        /// </summary>
        /// <param name="droidCollection"></param>
        /// <returns>int</returns>
        private int GetDroidNumber(DroidCollection droidCollection)
        {
            //Get the number from the user
            int numberOfDroid = NumberInput("Which numbered droid do you wish to delete?");

            //Continue to get the user input until they enter a valid number
            while((numberOfDroid < 1) || (numberOfDroid > droidCollection.NumberOfDroidsInList))
            {
                ErrorMessage();
                numberOfDroid = NumberInput("Which numbered droid do you wish to delete?");
            }
            //Subtracting one to make it equal to the index
            return numberOfDroid - 1;
        }
        
        /// <summary>
        /// Get the input need for the Utility Mech to be added
        /// </summary>
        private void BaseUtilityDroidInputs()
        {//Used a method sice it needs to be used for 3 droids
            //Find out if the user wants a toolbos
            toolboxBool = BoolInput("Do you wish for your droid to have a toolbox");
            //Find out if the user wants a computer connection
            computerConnectionBool = BoolInput("Do you wish for your droid to have a computer connection");
            //Find out if the user wants an arm
            armBool = BoolInput("Do you wish for your droid to have an arm");
        }

        /// <summary>
        /// Prints out the Droid types and gets the user's input
        /// </summary>
        /// <returns>ConsoleKeyInfo</returns>
        private ConsoleKeyInfo DroidTypeMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.Write("- Creating a New Droid -");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1) Protocol Droid");
            Console.WriteLine("2) Utility Droid");
            Console.WriteLine("3) Janitor Droid");
            Console.WriteLine("4) Astromech Droid");
            Console.Write("Press the number of the type Droid you wish create: ");
            return Console.ReadKey();
        }

        /// <summary>
        /// Creates the Droid Materail Menu and gets the users input
        /// </summary>
        /// <returns>ConsoleKeyInf</returns>
        private ConsoleKeyInfo DroidMaterialMenuMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;

            //Makes sure there is somthing in the _materialList
            if (_materialList != null && _materialList.GetLength(0) < 10)
            {
                //Prints out the Matial list with the cost multiplier
                for (int index = 0; index < _materialList.GetLength(0); index++)
                {
                    Console.WriteLine($"{index + 1}) {_materialList[index, 0]} - cost mulitpler is: {_materialList[index, 1]}");
                }
                Console.Write("Press the number of the material you wish the droid made from: ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            //Gets the users input
            return Console.ReadKey();
        }

        /// <summary>
        /// Makes sure that the input from the DroidMaterialMenuMessage is valid and if so casts it into an integer
        /// </summary>
        /// <returns>int</returns>
        private int DroidMaterialMenu()
        {
            bool NotValidData = true;
            int materialTypeInt = 0;
            //Gets the users input
            ConsoleKeyInfo inputChar;
            
            while(NotValidData)
            {
                inputChar = DroidMaterialMenuMessage();
                try
                {
                    //Parse the data to see if it causes an error
                    materialTypeInt = int.Parse(inputChar.KeyChar.ToString());

                    //Check to see if the integer is within the valid range
                    if ((materialTypeInt > 0) && (materialTypeInt <= _materialList.GetLength(0)))
                    {
                        NotValidData = false;
                    }
                    else
                    {
                        ErrorMessage();
                    }            
                }
                catch
                {
                    ErrorMessage();
                }
            }
            return materialTypeInt;
        }

        /// <summary>
        /// Gets the color from the user
        /// </summary>
        /// <returns></returns>
        public string DroidColorMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter the color you wish the droid to be: ");
            string inputString = Console.ReadLine();
            //Allows any string to be entered as long as there is one.
            while (inputString == "")
            {
                ErrorMessage();
                Console.Write("Enter the color you wish the droid to be: ");
                inputString = Console.ReadLine();
            }
            return inputString;
        }

        /// <summary>
        /// Generic user interface to get an integer for QuestionString asked.
        /// </summary>
        /// <param name="QuestionString">string</param>
        /// <returns>int</returns>
        public int NumberInput(string QuestionString)
        {
            bool dataNotValid = true;
            int numbLangInt = 0;

            string inputString = GetNumberInput(QuestionString);
            //If no input get error message and try again

            while (dataNotValid)
            {
                if (inputString == "")
                {
                    ErrorMessage();
                    inputString = GetNumberInput(QuestionString);
                }
                else
                {
                    //Make sure there is an integer inside
                    try
                    {
                        numbLangInt = int.Parse(inputString);
                        dataNotValid = false;
                    }
                    catch
                    {
                        ErrorMessage();
                        inputString = GetNumberInput(QuestionString);
                    }
                }
            }
            return numbLangInt;
        }

        public string GetNumberInput(string QuestionString)
        {
            Console.WriteLine();
            Console.Write(QuestionString + " ");
            //Get the users input
            string inputString = Console.ReadLine();
            return inputString;
        }

        /// <summary>
        /// Message displayed when a droid is added
        /// </summary>
        public void DroidAddedMessage()
        {
            Console.WriteLine("Droid has been added to the bottom of the list");
        }

        /// <summary>
        /// Standard error message
        /// </summary>
        public void ErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine(" Invalid Entry please try again.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Generic method to test if a yes/no question was answered correctly and assign appropiate bool value 
        /// </summary>
        /// <param name="YesNoQuestion"></param>
        /// <returns>bool</returns>
        public bool BoolInput(string YesNoQuestion)
        {
            ConsoleKeyInfo inputKey;
            //Print out the YesNoQuestion and get the users response
            inputKey = GetBoolInput(YesNoQuestion);

            //Get user response until correct data input
            while (inputKey.KeyChar != 'y' && inputKey.KeyChar != 'Y' && inputKey.KeyChar != 'n' && inputKey.KeyChar != 'N')
            {
                ErrorMessage();
                inputKey = GetBoolInput(YesNoQuestion);
            }

            //Assign correct bool value
            if (inputKey.KeyChar == 'y' || inputKey.KeyChar == 'Y')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Generic method to print out the YesNoQuestion and get the users response
        /// </summary>
        /// <param name="YesNoQuestion"></param>
        /// <returns>ConsoleKeyInfo</returns>
        public ConsoleKeyInfo GetBoolInput(string YesNoQuestion)
        {
            ConsoleKeyInfo tempConsoleKeyInfo;
            Console.WriteLine();
            Console.WriteLine($"{YesNoQuestion}?");
            Console.WriteLine("(Y)es or (N)o");
            tempConsoleKeyInfo = Console.ReadKey();
            Console.WriteLine();
            return tempConsoleKeyInfo;
        }

        /// <summary>
        /// Message to print when no droids are in the DroidCollection
        /// </summary>
        public void NoDroidsInListMessage()
        {
            Console.WriteLine("No droids in the list. Need to add droids before you can delete one.");
        }

        /// <summary>
        /// Message to display when exiting the program.
        /// </summary>
        public void ExitMessage()
        {
            Console.WriteLine("Exiting the Jawas of Tatooine Droids Sales List Program" );
            Console.Write("Press any key to exit. . .");
            Console.ReadKey();
        }
    }
}
