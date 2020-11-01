



namespace TplProjects
{
    using CsvHelper;
    using DocumentFormat.OpenXml.Bibliography;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    public class CSVHandler
    {
       
        public static void ImplementCSVDataHandling() 
        {
            string importFilePath = @"C:\Users\Aayush Arya\source\repos\TplProjects\TplProjects\Utility\Address.csv";
            String exportFilePath = @"C:\Users\Aayush Arya\source\repos\TplProjects\TplProjects\Utility\export.csv";
            using (var reader = new StreamReader(importFilePath)) 
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Data reading done successfully from Address.csv file");
                foreach (AddressData addressData in records)
                {
                    Console.WriteLine("\t" + addressData.FirstName);
                    Console.WriteLine("\t" + addressData.LastName);
                    Console.WriteLine("\t" + addressData.City);
                    Console.WriteLine("\t" + addressData.Address);
                    Console.WriteLine("\t" + addressData.State);
                    Console.WriteLine("\t" + addressData.Code);
                    Console.WriteLine("\n");
                }
                using (var writer = new StreamWriter(exportFilePath)) 
                using(var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
        }
    }
}
