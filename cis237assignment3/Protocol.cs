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
    public class Protocol : Droid
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

            /// <summary>
            /// Adds data from Protocol droid to Droid ToString() method
            /// </summary>
            /// <returns>string</returns>
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                " Speaks " + _numberLanguages.ToString() + " languages";
        }

        /// <summary>
        /// Adds the additional cost for the Protocol droid to the base Droid amount
        /// </summary>
        public override void CalculateTotalCost()
        {
            base.CalculateTotalCost();
            base.TotalCost += _numberLanguages * COST_PER_LANGUAGE; 
        }
        //***************************************
        //Constructor
        //***************************************

            /// <summary>
            /// Has one additional parameter than the base Droid.
            /// </summary>
            /// <param name="MaterialString">string</param>
            /// <param name="ModelString">string</param>
            /// <param name="ColorString">string</param>
            /// <param name="NumberLanguagesInt"></param>
        public Protocol(string MaterialString, string ModelString, string ColorString, int NumberLanguagesInt)
            : base(MaterialString, ModelString, ColorString)
        {
            _numberLanguages = NumberLanguagesInt;
        }
    }
}
