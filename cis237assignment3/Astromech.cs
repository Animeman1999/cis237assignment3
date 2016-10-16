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
    class Astromech : Utility
    {
        //***************************************
        //Variables
        //***************************************
        bool _fireExtinquisher;
        int _numberShips;
        const decimal FIRE_EXTINGUISHER_COST = 5M;
        const decimal COST_PER_SHIP = 2M;

        //***************************************
        //Method
        //***************************************

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + " Fire Extinquisher = " + _fireExtinquisher +
                Environment.NewLine + "Number of Ships = " + _numberShips;
        }

        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            if (_fireExtinquisher) { base.TotalCost += FIRE_EXTINGUISHER_COST; }
            base.TotalCost += _numberShips * COST_PER_SHIP;
        }

        //***************************************
        //Constructor
        //***************************************
        public Astromech(string MaterialString, string ModelString, string ColorString, bool ToolboxBool,
            bool ComputerConnectionBool, bool ArmBool, bool FireExtinquisher, int NumberShips)
            : base(MaterialString, ModelString, ColorString, ToolboxBool, ComputerConnectionBool, ArmBool)
        {
            _fireExtinquisher = FireExtinquisher;
            _numberShips = NumberShips;
        }
    }
}
