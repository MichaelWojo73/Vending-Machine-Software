using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using VendingMachineProject.Vending_Logic;

namespace VendingMachineProject.Documentation
{
    public static class SalesReport
    {
        public static void MakeSalesReport()
        {
            using (StreamWriter sw = new StreamWriter("SalesReport.txt", true))
            {
            }
        }

    }
}
