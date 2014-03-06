using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalculator
{
    class Program
    {
        const string path = @"..\..\";

        static void Main(string[] args)
        {
              // AreaCalculator\bin\debug   We have to go up two directories 
            decimal costPerSquareFoot;
            string inputFileName;
            string outputFileName;

            inputFileName = GetInputFile();
            outputFileName = GetOutputFileName();
            costPerSquareFoot = GetCostPerSquareFoot();

            string[] lines = File.ReadAllLines(inputFileName);

            StreamWriter writer = File.AppendText(path + outputFileName);
            writer.WriteLine("CustomerName,Width,Length,Area,Price");

            for (int i = 1; i < lines.Length; i++)
            {
                OutputRow row = new OutputRow();
                row.SetData(lines[i], costPerSquareFoot);
                writer.WriteLine(row.CreateOutputRow());
            }

            writer.Close();
        }

        private static decimal GetCostPerSquareFoot()
        {
            bool validDecimal = false;
            decimal output = 0;

            while (!validDecimal)
            {
                Console.WriteLine("Enter cost per square foot: ");
                if (decimal.TryParse(Console.ReadLine(), out output))
                    validDecimal = true;
                else
                    Console.WriteLine("Bad data!  Decimal stupid!");
            }

            return output;
        }

        static string GetOutputFileName()
        {
            Console.WriteLine("Name of output file: ");
            return Console.ReadLine();
        }

        static string GetInputFile()
        {
            bool fileExists = false;
            string inputFileName ="";

            while (!fileExists)
            {
                Console.Write("Provide input file name: ");
                inputFileName = Console.ReadLine();
                fileExists = File.Exists(path + inputFileName);
            }

            return path + inputFileName;
        }
    }
}
