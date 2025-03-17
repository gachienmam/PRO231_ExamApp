using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ManagementApp.Helper
{
    internal class JsonDataTable
    {
        public DataTable ConvertJsonToDataTable(string jsonString)
        {
            DataTable dataTable = new DataTable();

            try
            {
                JArray jsonArray = JArray.Parse(jsonString);

                if (jsonArray.Count > 0)
                {
                    // Create columns based on the first row
                    JObject firstRow = (JObject)jsonArray[0];
                    foreach (JProperty property in firstRow.Properties())
                    {
                        dataTable.Columns.Add(property.Name, typeof(object)); // Use object type initially
                    }

                    // Populate rows
                    foreach (JObject row in jsonArray)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        foreach (JProperty property in row.Properties())
                        {
                            dataRow[property.Name] = property.Value;
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting JSON to DataTable: {ex.Message}");
            }

            return dataTable;
        }
    }
}
