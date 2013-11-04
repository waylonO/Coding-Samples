using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorpCarpetEntry
{
    public class OrderEntryProcessor
    {
        private Order _currentOrder;

        public void TakeOrder()
        {
            string userInput = "";

            while (userInput != "C")
            {
                PopulateOrder();
                userInput = PromptValidation();

                switch (userInput)
                {
                    case "R":
                        break;
                    case "A":
                        WriteToFile();
                        userInput = "C";
                        break;
                    case "C":
                        break;
                }
            }
        }

        private void WriteToFile()
        {
            string fileName = "orders_" + DateTime.Now.ToString("MMddyyyy") + ".csv";

            bool fileExists = File.Exists(CarpetConfiguration.UnprocessedPath + fileName);

            StreamWriter fs = File.AppendText(CarpetConfiguration.UnprocessedPath + fileName);

            if(!fileExists)
                fs.WriteLine("CustomerName,Address1,Address2,City,State,Zipcode,ProductCode,Length,Width");

            fs.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", _currentOrder.CustomerName, _currentOrder.Address1, _currentOrder.Address2, 
                _currentOrder.City, _currentOrder.State, _currentOrder.Zipcode, _currentOrder.ProductCode, 
                _currentOrder.Length, _currentOrder.Width);

            fs.Close();
        }

        private string PromptValidation()
        {
            Console.Clear();
            Console.WriteLine("You entered: ");
            Console.WriteLine(_currentOrder.CustomerName);
            Console.WriteLine(_currentOrder.Address1);

            if(!string.IsNullOrEmpty(_currentOrder.Address2))
                Console.WriteLine(_currentOrder.Address2);

            Console.WriteLine("{0}, {1} {2}", _currentOrder.City, _currentOrder.State, _currentOrder.Zipcode);
            Console.WriteLine();
            Console.WriteLine("Product Code: {0}  {1} x {2}", _currentOrder.ProductCode, _currentOrder.Length, _currentOrder.Width);

            Console.WriteLine("\n");
            Console.Write("(A)ccept, (C)ancel, (R)e-enter: ");
            return Console.ReadLine();
        }

        private void PopulateOrder()
        {
            _currentOrder = new Order();
            Console.Clear();

            Console.WriteLine("Order Entry");
            Console.WriteLine("----------------------");

            _currentOrder.CustomerName = PromptForData("Customer Name: ");

            Console.WriteLine();
            Console.WriteLine("Location");
            Console.WriteLine("----------------------");
            _currentOrder.Address1 = PromptForData("Address 1: ");
            _currentOrder.Address2 = PromptForData("Address 2: ");
            _currentOrder.City = PromptForData("City: ");
            _currentOrder.State = PromptForData("State: ");
            _currentOrder.Zipcode = PromptForData("Zip Code: ");

            Console.WriteLine();
            Console.WriteLine("Purchase Information");
            Console.WriteLine("----------------------");
            _currentOrder.ProductCode = PromptForData("Product Code: ");
            _currentOrder.Length = int.Parse(PromptForData("Length: "));
            _currentOrder.Width = int.Parse(PromptForData("Width: "));
        }

        private string PromptForData(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
