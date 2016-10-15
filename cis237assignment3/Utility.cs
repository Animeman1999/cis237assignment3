using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment3
{
    class Utility : Droid
    {
        //***************************************
        //Variables
        //***************************************

        bool _toolboxBool;
        bool _computerConnectionBool;
        bool _armBool;
        const decimal TOOL_BOX_COST = 75M;
        const decimal COMPUTER_CONNECTION_COST = 20M;
        const decimal ARM_COST = 50M;

        //***************************************
        //Method
        //***************************************

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + 
                " Toolbox = " + _toolboxBool + Environment.NewLine +
                " Computer Connection = " + _computerConnectionBool +  Environment.NewLine +
                " Arm = " + _armBool;
        }

        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            if (_toolboxBool) { base._totalCostDecimal += TOOL_BOX_COST; }
            if (_computerConnectionBool) { base._totalCostDecimal += COMPUTER_CONNECTION_COST; }
            if (_armBool) { base._totalCostDecimal += ARM_COST; }
        }

        //***************************************
        //Constructor
        //***************************************
        public Utility(string MaterialString, string ModelString, string ColorString, bool ToolboxBool, bool ComputerConnectionBool, bool ArmBool)
            : base(MaterialString, ModelString, ColorString)
        {
            _toolboxBool = ToolboxBool;
            _computerConnectionBool = ComputerConnectionBool;
            _armBool = ArmBool;
        }
    }
}
