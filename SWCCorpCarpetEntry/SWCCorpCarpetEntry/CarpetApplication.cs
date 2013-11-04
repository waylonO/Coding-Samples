using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCCorpCarpetEntry
{
    public class CarpetApplication
    {

        public void Run()
        {
            string userChoice = "";

            while (userChoice != "3")
            {
                DisplayMenu();
                userChoice = PromptUser();

                switch (userChoice)
                {
                    case "1":
                        OrderEntryProcessor processor = new OrderEntryProcessor();
                        processor.TakeOrder();
                        break;
                    case "2":
                        EndOfDayProcessor endOfDayProcessor = new EndOfDayProcessor();
                        endOfDayProcessor.ProcessEndOfDay();
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("That is not a recognized option!  Press enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private string PromptUser()
        {
            string returnValue;

            Console.Write("Enter choice: ");
            returnValue = Console.ReadLine();

            return returnValue;
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("SWC Corp Carpet Entry System");
            Console.WriteLine("");
            Console.WriteLine("1. Add a New Order");
            Console.WriteLine("2. End of Day Processing");
            Console.WriteLine("3. Quit");
            Console.WriteLine("");
            Console.WriteLine("===================================");

            Console.WriteLine("");
        }
    }
}
