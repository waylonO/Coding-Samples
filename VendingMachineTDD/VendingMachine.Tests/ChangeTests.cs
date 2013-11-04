using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VendingMachine.BLL;

namespace VendingMachine.Tests
{
    [TestFixture]
    public class ChangeTests
    {
        [Test]
        public void ChangeTotalTest()
        {
            Change changeInstance = new Change();

            changeInstance.Quarters = 1;
            changeInstance.Dimes = 2;
            changeInstance.Nickles = 3;
            changeInstance.Pennies = 4;

            decimal total = changeInstance.GetTotal();
            Assert.AreEqual(total, 0.64M);
        }
    }
}
