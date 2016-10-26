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
    public abstract class Droid : IDroid
    {
        //***************************************
        //Variables
        //***************************************
        string _materialString;
        string _modelString;
        string _color_string;
        decimal _baseCostDecimal;
        decimal _totalCostDecimal;
        string[,] _materialList =
            { { "plastic", ".5" },
                {"steele", "1" },
                {"Plass-Steele", "1.5"},
                {"Nevo-Titanium", "2" },
                {"Areogel","2.5" },
                {"Atomic-Aluminum","5" }};
        string[] _droidList = { "Protocol", "Utility", "Janitor", "Astromech" };

        //***************************************
        //Properties
        //***************************************

        public decimal TotalCost
        {
            get
            {
                return _totalCostDecimal;
            }

            set
            {
                _totalCostDecimal = value;
            }
        }

        //***************************************
        //Method
        //***************************************

            /// <summary>
            /// Used to calcualte the total cost
            /// </summary>
        virtual public void CalculateTotalCost()
        {
            //At the this level the total cost is the base cost.
            CalculateBaseCost();
            _totalCostDecimal = _baseCostDecimal;
        }

        /// <summary>
        /// Overide method to create information string for each droid
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return _color_string + " " + _materialString + " "  + _modelString + " Droid" ;
        }

        /// <summary>
        /// Calculates the base cost for each dfoid type.
        /// </summary>
        public void CalculateBaseCost()
        {
            //Get the MaterialMultipler which is based on the tye of matterial used.
            decimal materialMultiplier = MaterialCostMultiplier(_materialString);

            //Gets the cost for each type of model
            switch (_modelString)
            {
                case "Protocol":
                    _baseCostDecimal = 500m;
                    break;
                case "Utility":
                    _baseCostDecimal = 200m;
                    break;
                case "Janitor":
                    _baseCostDecimal = 350m;
                    break;
                case "Astromech":
                    _baseCostDecimal = 450m;
                    break;
            }
            // Calculate the base cost now that we have the model cost and material multiplier
            _baseCostDecimal = _baseCostDecimal * materialMultiplier;
        }

        /// <summary>
        /// Finds the value mulitplier from the _materialList based on material
        /// </summary>
        /// <param name="Material"></param>
        /// <returns>decimal</returns>
        public decimal MaterialCostMultiplier(string Material)
        {
            decimal materialCostDecimal = 0;

            for (int index = 0; index < _materialList.GetLength(0); index++ )
            {
                if (Material == _materialList[index,0])
                {
                    materialCostDecimal = decimal.Parse(_materialList[index, 1]);
                }
            }

            return materialCostDecimal;
        }


        //***************************************
        //Constructor
        //***************************************

            /// <summary>
            /// Every droid will have these base parameters
            /// </summary>
            /// <param name="MaterialString">string</param>
            /// <param name="ModelString">string</param>
            /// <param name="ColorString">string</param>
        public Droid (string MaterialString, string ModelString, string ColorString)
        {
            _materialString = MaterialString;
            _modelString = ModelString;
            _color_string = ColorString;
        }


    }
}
