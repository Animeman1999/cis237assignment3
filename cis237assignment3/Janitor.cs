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
    class Janitor : Utility
    {
        //***************************************
        //Variables
        //***************************************
        bool _trashCompactorBool;
        bool _vacuumBool;
        const decimal TRASH_COMPATOR_COST = 35M;
        const decimal VACUUM_COST = 20M;

        //***************************************
        //Method
        //***************************************
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + " Trash Compactor = " + _trashCompactorBool +
                Environment.NewLine + " Vacum = " + _vacuumBool;
        }

        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            if (_trashCompactorBool) { base._totalCostDecimal += TRASH_COMPATOR_COST; }
            if (_vacuumBool) { base._totalCostDecimal += VACUUM_COST; }
        }
        //***************************************
        //Constructor
        //***************************************

        public Janitor(string MaterialString, string ModelString, string ColorString, bool ToolboxBool, 
            bool ComputerConnectionBool, bool ArmBool, bool TrashCompactorBool, bool VacuumBool)
            : base(MaterialString, ModelString, ColorString, ToolboxBool, ComputerConnectionBool, ArmBool)
        {
            
            _trashCompactorBool = TrashCompactorBool;
            _vacuumBool = VacuumBool; 
        }
    }
}
