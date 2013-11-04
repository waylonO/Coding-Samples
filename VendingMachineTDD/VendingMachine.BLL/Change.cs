using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.BLL
{
    public class Change
    {
        public int Quarters, Dimes, Nickles, Pennies;

        public decimal GetTotal()
        {
            decimal total = 0;

            total = Quarters*0.25M;
            total += Dimes*0.10M;
            total += Nickles*0.05M;
            total += Pennies*0.01M;

            return total;
        }
    }
}
