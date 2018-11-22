using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using VendingMachineProject.Vending_Logic;

namespace VendingMachineProject.Documentation
{
    public  static class Audit
    {
        public static void MakeAudit(decimal beforeBalance, decimal tFedMoney, string actionAudited)
        {
            using (StreamWriter sw = new StreamWriter("Log.txt", true))
            {
                DateTime currentDateTime = DateTime.Today;
                sw.WriteLine($"{currentDateTime} {actionAudited}:   {beforeBalance:c}  {tFedMoney:c}");
            }
        }
    }
}
