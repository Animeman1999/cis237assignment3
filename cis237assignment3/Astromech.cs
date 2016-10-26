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
    pubic class Astromech : Utility
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

            /// <summary>
            /// Add Astomech Droid informatioin to the base Utility Droid ToString
            /// </summary>
            /// <returns>string</returns>
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + " Fire Extinquisher = " + _fireExtinquisher +
                Environment.NewLine + " Number of Ships = " + _numberShips;
        }

        /// <summary>
        /// Adds additional cost of the Astromech to the base Utility Droid
        /// </summary>
        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            if (_fireExtinquisher) { base.TotalCost += FIRE_EXTINGUISHER_COST; }
            base.TotalCost += _numberShips * COST_PER_SHIP;
        }

        //***************************************
        //Constructor
        //***************************************

            /// <summary>
            /// Astromech has 2 additional parameters over the base Utility Class
            /// </summary>
            /// <param name="MaterialString">string</param>
            /// <param name="ModelString">string</param>
            /// <param name="ColorString">string</param>
            /// <param name="ToolboxBool">bool</param>
            /// <param name="ComputerConnectionBool">bool</param>
            /// <param name="ArmBool">bool</param>
            /// <param name="FireExtinquisher">bool</param>
            /// <param name="NumberShips">int</param>
        public Astromech(string MaterialString, string ModelString, string ColorString, bool ToolboxBool,
            bool ComputerConnectionBool, bool ArmBool, bool FireExtinquisher, int NumberShips)
            : base(MaterialString, ModelString, ColorString, ToolboxBool, ComputerConnectionBool, ArmBool)
        {
            _fireExtinquisher = FireExtinquisher;
            _numberShips = NumberShips;
        }
    }
}
