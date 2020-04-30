using System;
using System.Data;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using DataRowExtensions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var mockData = GetMockData();

            var parsedData = new SkuData();
            mockData[0].ReadObject(parsedData);

            Console.WriteLine(GetAllPublicPropertyValues(parsedData));
        }

        private static DataRowCollection GetMockData()
        {
            var table = new DataTable("SkuData");
            table.Columns.Add("Stockcode", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("QC13Ref", typeof(string));
            table.Columns.Add("Notes", typeof(string));
            table.Columns.Add("STKState_ID", typeof(int));
            table.Columns.Add("Mass", typeof(double));

            table.Rows.Add(
                "123",
                "Blah",
                "QCREF",
                "My Note",
                456,
                789
            );

            return table.Rows;
        }

        private static string GetAllPublicPropertyValues<T>(T o)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var result = new StringBuilder();

            foreach (var propInfo in properties)
            {
                result.Append($"{propInfo.Name}: {propInfo.GetValue(o)}, ");
            }

            return result.ToString();
        }
    }
}
