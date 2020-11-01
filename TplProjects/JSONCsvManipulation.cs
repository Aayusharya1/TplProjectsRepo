using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace TplProjects
{
    class JSONCsvManipulation
    {
        public static void ImplementCsvToJson()
        {
            string importFilePath = @"C:\Users\Aayush Arya\source\repos\TplProjects\TplProjects\Utility\Address.csv";
            String exportFilePath = @"C:\Users\Aayush Arya\source\repos\TplProjects\TplProjects\Utility\addressDetails.json";
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
                JsonSerializer jsonSerializer = new JsonSerializer();
                using (StreamWriter streamWriter = new StreamWriter(exportFilePath))
                using (JsonWriter writer = new JsonTextWriter(streamWriter))
                {
                    jsonSerializer.Serialize(writer, records);
                }
            }
        }
        public static void ImplementJsonToCsv()
        {
            string importFilePath = @"";
            string exportFilePath = @"";
            IList<AddressData> addressData = JsonConvert.DeserializeObject<IList<AddressData>>(File.ReadAllText(importFilePath));
            Console.WriteLine("*************Now reading from jsonfile and write to csv file********");
            // writing csv file
            using (var writer = new StreamWriter(exportFilePath))
            using (var csvExport = new CsvWriter(writer,CultureInfo.InvariantCulture)) 
            {
                csvExport.WriteRecords(addressData);
            }
        }
    }
}