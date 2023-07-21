using ExcelDataReader;

namespace Helpers;

public class ExcelHelper 
{
    private readonly string _filepath;
    readonly List<string> _headers = new();
    readonly List<List<string>> _rows = new();
    private readonly bool _hasHeaders;
    
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
                _headers.AddRange(GetRow(row));
                firstRow = false;
            }
            else
            {
                _rows.Add(GetRow(row));
            }
        }
        Console.WriteLine($"Headers: {_headers.Count} {_headers.ToArray()[1] } {_rows.Count} {_rows.ToArray()[1][0]}");
    }
    private static List<string>  GetRow(IExcelDataReader row)
    {
        List<string> returnRow = new();
        for(int i = 0; i < row.FieldCount; i++)
        {
            returnRow.Add(row[i]?.ToString() ?? "");
        }
        return returnRow;
    }
}
