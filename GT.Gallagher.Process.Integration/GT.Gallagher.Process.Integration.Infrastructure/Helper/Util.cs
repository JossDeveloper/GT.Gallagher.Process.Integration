using Newtonsoft.Json;
using OfficeOpenXml;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace GT.Gallagher.Process.Integration.Infrastructure.Helper;

public class Util
{
    public static DataTable ToDataTable<T>(T model)
    {
        PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
        DataTable dt = new DataTable();

        foreach (PropertyDescriptor p in props)
        {
            var notMapped = typeof(T).GetProperty(p.Name).GetCustomAttributes(typeof(NotMappedAttribute), true);

            if (!notMapped.Any())
                dt.Columns.Add(p.Name, Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType);
        }
        DataRow row = dt.NewRow();

        foreach (PropertyDescriptor prop in props)
        {
            var notMapped = typeof(T).GetProperty(prop.Name).GetCustomAttributes(typeof(NotMappedAttribute), true);

            if (!notMapped.Any())
                row[prop.Name] = prop.GetValue(model) ?? DBNull.Value;
        }
        dt.Rows.Add(row);

        return dt;
    }

    public static DataTable ListToDataTable<T>(IList<T> model)
    {
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
        DataTable dt = new DataTable();

        foreach (PropertyDescriptor prop in properties)
        {
            var notMapped = typeof(T).GetProperty(prop.Name).GetCustomAttributes(typeof(NotMappedAttribute), true);

            if (!notMapped.Any())
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        }

        foreach (T item in model)
        {
            DataRow row = dt.NewRow();

            foreach (PropertyDescriptor prop in properties)
            {
                var notMapped = typeof(T).GetProperty(prop.Name).GetCustomAttributes(typeof(NotMappedAttribute), true);

                if (!notMapped.Any())
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            }
            dt.Rows.Add(row);
        }
        return dt;
    }

    public static byte[] GenerateExcel<T>(IEnumerable<T> data, string sheetName = "Sheet1")
    {
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add(sheetName);
        var properties = typeof(T).GetProperties();

        for (int i = 0; i < properties.Length; i++)
        {
            worksheet.Cells[1, i + 1].Value = properties[i].Name;
        }
        int row = 2;

        foreach (var item in data)
        {
            for (int col = 1; col <= properties.Length; col++)
            {
                worksheet.Cells[row, col].Value = properties[col - 1].GetValue(item);
            }
            row++;
        }
        return package.GetAsByteArray();
    }

    public static void SaveFile<T>(string route, string nameFile, T model)
    {
        var jsonOptions = new JsonSerializerSettings() { Formatting = Formatting.Indented, NullValueHandling = NullValueHandling.Ignore };

        Directory.CreateDirectory(route);
        File.WriteAllText(string.Concat(route, nameFile), JsonConvert.SerializeObject(model, jsonOptions));
    }
}

