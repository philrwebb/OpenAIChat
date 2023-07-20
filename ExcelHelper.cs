using ExcelDataReader;
using Microsoft.VisualBasic;
using System.Linq;

namespace Helpers;
public static class ExcelHelper
{
    public static void ReadWorkBook()
    {
        using var stream = File.Open("./titanic.csv", FileMode.Open, FileAccess.Read);
        using var reader = ExcelReaderFactory.CreateCsvReader(stream);
        while (reader.Read())
        {
            var row = reader;
            Console.WriteLine($"{row[1]} / {row[2]} / {row[3]} / {row[4]}" );
        }
    }
}
