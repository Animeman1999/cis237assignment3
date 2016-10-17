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
    /// <summary>
    /// Make sure that the DroidCollection will have 4 overloaded methods for AddNewItem
    /// </summary>
    interface IDroidCollection
    {
        void AddNewItem(string MaterialString, string ModelString, string ColorString, int NumberLanguagesInt);

        void AddNewItem(string MaterialString, string ModelString, string ColorString, bool ToolboxBool, bool ComputerConnectionBool, bool ArmBool);

        void AddNewItem(string MaterialString, string ModelString, string ColorString, bool ToolboxBool,
            bool ComputerConnectionBool, bool ArmBool, bool TrashCompactorBool, bool VacuumBool);

        void AddNewItem(string MaterialString, string ModelString, string ColorString, bool ToolboxBool,
            bool ComputerConnectionBool, bool ArmBool, bool FireExtinquisher, int NumberShips);
    }

    
}
