using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorpCarpetEntry
{
    public class EndOfDayProcessor
    {
        private PricingInformationProcessor pricingInformation = new PricingInformationProcessor();

        public void ProcessEndOfDay()
        {
            ProcessFiles();
        }

        // Loop through all the files in the Unprocessed Directory
        private void ProcessFiles()
        {
            DirectoryInfo info = new DirectoryInfo(CarpetConfiguration.UnprocessedPath);

            foreach (FileInfo file in info.GetFiles())
            {
                CreateOutputFile(file.Name);
            }
        }

        private void CreateOutputFile(string fileName)
        {
            string[] dataRows = File.ReadAllLines(CarpetConfiguration.UnprocessedPath + fileName);

            string outputFileName = "processed_" + DateTime.Now.ToString("MMddyyyy") + ".csv";
            bool outputFileExists = File.Exists(CarpetConfiguration.ProcessingPath + outputFileName);

            StreamWriter sr = File.AppendText(CarpetConfiguration.ProcessingPath + outputFileName);

            if (!outputFileExists)
                sr.WriteLine("CustomerName,Address1,Address2,City,State,Zipcode,ProductCode,Length,Width,Area,TotalPrice");

            for (int i = 1; i < dataRows.Length; i++)
            {
                string[] row = dataRows[i].Split(',');

                Order order = new Order(row);
                decimal price = pricingInformation.GetPriceFromCode(order.ProductCode);

                OrderOutput output = new OrderOutput(order, price);
                sr.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", output.InputOrder.CustomerName, output.InputOrder.Address1, output.InputOrder.Address2,
                    output.InputOrder.City, output.InputOrder.State, output.InputOrder.Zipcode, output.InputOrder.ProductCode, output.InputOrder.Length, 
                    output.InputOrder.Width, output.Area, output.TotalPrice);
            }

            sr.Close();
        }
    }
}
