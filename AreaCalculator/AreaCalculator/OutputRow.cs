using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator
{
    class OutputRow
    {
        public string CustomerName ;
        public decimal Width;
        public decimal Length;
        public decimal Area;
        public decimal Price;

        public void SetData(string inputData, decimal pricePerSquareFoot)
        {
            string[] data = inputData.Split(',');

            CustomerName = data[0];
            Width = decimal.Parse(data[1]);
            Length = decimal.Parse(data[2]);

            Area = Length*Width;
            Price = Area*pricePerSquareFoot;
        }

        public string CreateOutputRow()
        {
            return string.Format("{0},{1},{2},{3},{4:C}", CustomerName, Width, Length, Area, Price);
        }
    }
}
