//Jeffrey Martin
//CIS 237 Assignment 3
//Due 10-19-2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment3
{//Clas created by Dave to force all students to use the CalculateTotalCost method and TotalCost property
    interface IDroid
    {
        void CalculateTotalCost();

        decimal TotalCost { get; set; }
    }
}
