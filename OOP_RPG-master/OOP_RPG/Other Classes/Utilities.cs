using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG.Other_Classes
{
    class Utilities
    {
        public static bool IsValidInput(string input, int low, int high)//Using in Shop class with userChoice
        {
            int output;
            bool isGood = false;
            if (Int32.TryParse(input, out output))//converts string to integer
            {
                if (output >= low && output <= high)//if integer bewteen the low and high values, program will run
                                                    //if not program won't run (returns false)
                {
                    isGood = true;
                }
            }
            return isGood;
        }
    }
}
