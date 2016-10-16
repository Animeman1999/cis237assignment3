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
    class UserInterface
    {
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

        private static void MaximizeConsole()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
        }
        //************************************End Code to Maxamize the Console***********************


        public void StartUserInterface()
        {
            Console.BufferHeight = Int16.MaxValue - 1;
            Console.Title = "Jawas of Tatooine Droids Sales List Program";
            MaximizeConsole();
        }

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

        public int LoadMenu()
        {
            ConsoleKeyInfo inputChar = LoadMenuMessage();
            Console.WriteLine();
            while (inputChar.KeyChar != '1' && inputChar.KeyChar != '2' && inputChar.KeyChar != '3')
            {
                ErrorMessage();
                inputChar = LoadMenuMessage();
                Console.WriteLine();
            }
            return int.Parse(inputChar.KeyChar.ToString());
        }

        public void ListLoadedMessage()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.Write("- List Loaded -");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

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

        public int MainMenu()
        {
            ConsoleKeyInfo inputChar = MainMenuMessage();
            Console.WriteLine();
            while (inputChar.KeyChar != '1' && inputChar.KeyChar != '2' && inputChar.KeyChar != '3' && inputChar.KeyChar != '4')
            {
                ErrorMessage();
                inputChar = MainMenuMessage();
                Console.WriteLine();
            }
            return int.Parse(inputChar.KeyChar.ToString());
        }
        public void PrintDroidList(string[] OutputString)
        {
            Console.Write("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.Write("- Start List -");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine();
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

        public void AddDroidSequence(DroidCollection droidCollection)
        {
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

            ConsoleKeyInfo inputChar = DroidTypeMenu();
            Console.WriteLine();
            while (inputChar.KeyChar != '1' && inputChar.KeyChar != '2' && inputChar.KeyChar != '3' && inputChar.KeyChar != '4')
            {
                ErrorMessage();
                inputChar = DroidTypeMenu();
                Console.WriteLine();
            }

            int droidTypeInputInt = int.Parse(inputChar.KeyChar.ToString());

            modelString = _droidList[droidTypeInputInt - 1];       

            int materialTypeInputInt = DroidMaterialMenu();

            materialString = _materialList[materialTypeInputInt - 1, 0];

            colorString = DroidColorMenu();

            switch (droidTypeInputInt)
            {
                case 1: //Protocol
                    numberLanguagesInt = NumberInput("Languages");
                    droidCollection.AddNewItem(materialString, modelString, colorString, numberLanguagesInt);
                    DroidAddedMessage();
                    break;
                case 2://Utility
                    BaseUtilityDroidInputs();
                    droidCollection.AddNewItem(materialString, modelString, colorString, toolboxBool, computerConnectionBool, armBool);
                    break;
                case 3://Janitor
                    BaseUtilityDroidInputs();
                    trashCompactorBool = BoolInput("a trash compactor");
                    vacuumBool = BoolInput("a vacuum");
                    droidCollection.AddNewItem(materialString, modelString, colorString,
                        toolboxBool, computerConnectionBool, armBool, trashCompactorBool, vacuumBool);
                    break;
                default://Astromech
                    BaseUtilityDroidInputs();
                    fireExtinquisher = BoolInput("fire extinquisher");
                    numberShips = NumberInput("ships");
                    droidCollection.AddNewItem(materialString, modelString, colorString,
                        toolboxBool, computerConnectionBool, armBool, fireExtinquisher, numberShips);
                    break;

            }

        }
        
        private void BaseUtilityDroidInputs()
        {
            toolboxBool = BoolInput("a toolbox");
            computerConnectionBool = BoolInput("a computer connection");
            armBool = BoolInput("an arm");
        }

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

        private ConsoleKeyInfo DroidMaterialMenuMessage()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (_materialList != null && _materialList.GetLength(0) < 10)
            {
                for (int index = 0; index < _materialList.GetLength(0); index++)
                {
                    Console.WriteLine($"{index + 1}) {_materialList[index, 0]} - cost mulitpler is: {_materialList[index, 1]}");
                }
                Console.Write("Press the number of the material you wish the droid made from: ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            return Console.ReadKey();
        }

        private int DroidMaterialMenu()
        {
            int materialTypeInt = 0;
            ConsoleKeyInfo inputChar = DroidMaterialMenuMessage();
            
            try
            {
                materialTypeInt = int.Parse(inputChar.KeyChar.ToString());
                if ((materialTypeInt > 0) && (materialTypeInt <= _materialList.GetLength(0)))
                {
                    //Valid choice
                }
                else
                {
                    ErrorMessage();
                    materialTypeInt = DroidMaterialMenu();
                }
            
            }
            catch
            {
                ErrorMessage();
                materialTypeInt = DroidMaterialMenu();
            }
            return materialTypeInt;
        }

        public string DroidColorMenu()
        {
            Console.WriteLine();
            Console.Write("Enter the color you wish the droid to be: ");
            string inputString = Console.ReadLine();
            if (inputString == "")
            {
                ErrorMessage();
                inputString = DroidColorMenu();
            }
            return inputString;
        }

        public int NumberInput(string typeOfInput)
        {
            int numbLangInt = 0;
            Console.WriteLine();
            Console.Write($"Enter the number of {typeOfInput} you wish the droid to know: ");
            string inputString = Console.ReadLine();
            if (inputString == "")
            {
                ErrorMessage();
                numbLangInt = NumberInput(typeOfInput);
            }
            else
            {
                try
                {
                    numbLangInt = int.Parse(inputString);
                }
                catch
                {
                    ErrorMessage();
                    numbLangInt = NumberInput(typeOfInput);
                }
            }
            return numbLangInt;
        }

        public void DroidAddedMessage()
        {
            Console.WriteLine("Droid has been added to the bottom of the list");
        }

        public void ErrorMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" Invalid Entry please try again.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public bool BoolInput(string typeOfItem)
        {
            ConsoleKeyInfo inputKey;
            inputKey = GetBoolInput(typeOfItem);
            while (inputKey.KeyChar != 'y' && inputKey.KeyChar != 'Y' && inputKey.KeyChar != 'n' && inputKey.KeyChar != 'N')
            {
                ErrorMessage();
                inputKey = GetBoolInput(typeOfItem);
            }
            if (inputKey.KeyChar == 'y' || inputKey.KeyChar == 'Y')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ConsoleKeyInfo GetBoolInput(string TypeOfItem)
        {
            ConsoleKeyInfo tempConsoleKeyInfo;
            Console.WriteLine($"Do you wish for your droid to have {TypeOfItem}?");
            Console.WriteLine("(Y)es or (N)o");
            tempConsoleKeyInfo = Console.ReadKey();
            Console.WriteLine();
            return tempConsoleKeyInfo;
        }

        public void ExitMessage()
        {
            Console.WriteLine("Exiting the Jawas of Tatooine Droids Sales List Program" );
            Console.Write("Press any key to exit. . .");
            Console.ReadKey();
        }
    }
}
