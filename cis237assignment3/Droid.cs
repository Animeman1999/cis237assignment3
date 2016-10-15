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
    abstract class Droid : IDroid
    {
        //***************************************
        //Variables
        //***************************************
        string _materialString;
        string _modelString;
        string _color_string;
        decimal _baseCostDecimal;
        protected decimal _totalCostDecimal;
        string[,] _materialList =
            { { "plastic", ".5" },
                {"steele", "1" },
                {"Plass-Steele", "1.5"},
                {"Nevo-Titanium", "2" },
                {"Areogel","2.5" },
                {"Atomic-Aluminum","5" }};
        string[] _mechList = { "Protoco", "Utility", "Janitor", "Astromech" };

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
                throw new NotImplementedException();
            }
        }

        //***************************************
        //Method
        //***************************************

        virtual public void CalculateTotalCost()
        {
            CalculateBaseCost();
            _totalCostDecimal = _baseCostDecimal;
        }

        public override string ToString()
        {
            return _color_string + " " + _materialString + " "  + _modelString + " Droid" ;
        }

        public void CalculateBaseCost()
        {
            decimal materialMultiplier = MaterialCostMultiplier(_materialString);
            switch (_modelString)
            {
                case "Protoco":
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
            _baseCostDecimal = _baseCostDecimal * materialMultiplier;
            Console.WriteLine("Calculate base Cost =" + _baseCostDecimal);
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

        public Droid (string MaterialString, string ModelString, string ColorString)
        {
            _materialString = MaterialString;
            _modelString = ModelString;
            _color_string = ColorString;
        }


    }
}
