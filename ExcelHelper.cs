using ExcelDataReader;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections.Generic;

namespace Helpers;
// public static class ExcelHelper
// {

//     public static void ReadWorkBook()
//     {
//         using var stream = File.Open("./titanic.csv", FileMode.Open, FileAccess.Read);
//         using var reader = ExcelReaderFactory.CreateCsvReader(stream);
//         while (reader.Read())
//         {
//             var row = reader;
//             Console.WriteLine($"{row[1]} / {row[2]} / {row[3]} / {row[4]}" );
//         }
//     }
// }

public class ExcelHelper 
{
    private string _filepath;
    List<string> _headers = new List<string>();
    List<List<string>> _rows = new List<List<string>>();
    private bool _hasHeaders;
    
    public  ExcelHelper(string filepath, bool hasHeaders = true)
    {
        _filepath = filepath;
        _hasHeaders = hasHeaders;
    }

    public void ReadWorkBook()
    {
        using var stream = File.Open(_filepath, FileMode.Open, FileAccess.Read);
        using var reader = ExcelReaderFactory.CreateCsvReader(stream);
        var firstRow = true;

        while (reader.Read())
        {
            var row =  reader;
            if(firstRow && _hasHeaders)
            {
                _headers.AddRange(row);
                firstRow = false;
            }
            else
            {
                _rows.Add((new List<string>()).AddRange(row));
            }
            // Console.WriteLine($"{row[0]} / {row[1]} / {row[2]} / {row[3]} / {row[4]} / {row[5]} / {row[6]} / {row[7]} / {row[8]} / {row[9]} / {row[10]} / {row[11]}" );
        }
        Console.WriteLine($"Headers: {_headers.Count}");
    }
}
