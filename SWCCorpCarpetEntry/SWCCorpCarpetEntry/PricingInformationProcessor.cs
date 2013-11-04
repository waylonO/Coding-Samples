using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorpCarpetEntry
{
    public class PricingInformationProcessor
    {
        private Product[] products;

        public PricingInformationProcessor()
        {
            LoadDataFromFile();
        }

        private void LoadDataFromFile()
        {
            string[] lines = File.ReadAllLines(CarpetConfiguration.Pricing);
            products = new Product[lines.Length-1];

            for (int i = 1; i < lines.Length; i++)
            {
                string[] row = lines[i].Split(',');
                products[i - 1] = new Product {Price = decimal.Parse(row[1]), ProductCode = row[0]};
            }
        }

        public decimal GetPriceFromCode(string code)
        {
            foreach (Product p in products)
            {
                if (p.ProductCode == code)
                    return p.Price;
            }

            return 0;
        }
    }
}
