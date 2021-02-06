using CSItDevRisk.Objects;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CSItDevRisk
{
    class Program
    {
        static void Main(string[] args)
        {
            //extract the information from input file
            var pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InputData", "data.txt");
            var file = File.ReadAllLines(pathFile).ToList();

            //get reference date from first line
            DateTime referenceDate = DateTime.ParseExact(file.First(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

            //eliminates the 2 fist two lines ( reference date + number of trade lines)
            file = file.Skip(2).ToList();

            //loop through trades
            foreach (var line in file)
            {
                var data = line.Split(" ");
                var trade = new Trade
                {
                    Value = double.Parse(data[0]),
                    ClientSector = data[1],
                    NextPaymentDate = DateTime.ParseExact(data[2], "MM/dd/yyyy", CultureInfo.InvariantCulture)
                };

                Console.WriteLine(trade.GetCategory(referenceDate));
            }
        }
    }
}
