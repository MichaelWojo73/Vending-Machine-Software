using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineProject.Vending_Logic
{
    public class Change
    {
        public int AmountOfQuarters { get; }

        public int AmountOfDimes { get; }

        public int AmountOfNickels { get; }

        public int AmountOfPennies { get; }

       

        public Change(decimal changeDue)
        {
            this.AmountOfQuarters = (int)(changeDue/.25M);

            changeDue -= AmountOfQuarters * .25M;
            this.AmountOfDimes = (int)(changeDue / .10M);

            changeDue -= AmountOfDimes * .10M;
            this.AmountOfNickels = (int)(changeDue / .05M);

            changeDue -= AmountOfNickels * .05M;
            this.AmountOfPennies = (int)(changeDue / .01M);
        }
    }
}
