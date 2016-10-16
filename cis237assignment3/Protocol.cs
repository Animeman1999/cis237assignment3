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
    class Protocol : Droid
    {
        //***************************************
        //Variables
        //***************************************
        int _numberLanguages;
        const decimal COST_PER_LANGUAGE = 0.35M;

        //***************************************
        //Properties
        //***************************************

        public int NumberLanguagesInt
        {
            get { return _numberLanguages; }
            set { _numberLanguages = NumberLanguagesInt; }
        }

        //***************************************
        //Method
        //***************************************

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                " Speaks " + _numberLanguages.ToString() + " languages";
        }

        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            base.TotalCost += _numberLanguages * COST_PER_LANGUAGE; 
        }
        //***************************************
        //Constructor
        //***************************************

        public Protocol(string MaterialString, string ModelString, string ColorString, int NumberLanguagesInt)
            : base(MaterialString, ModelString, ColorString)
        {
            _numberLanguages = NumberLanguagesInt;
        }
    }
}
