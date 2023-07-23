using Helpers;
using System.Text;
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
var excelHelper = new ExcelHelper("Data/javascriptcourse.csv");
excelHelper.ReadWorkBook();
var openAIHelper = new OpenAIHelper("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");
List<List<string>> course = new();
StringBuilder sb = new();
foreach(var row in excelHelper.Rows)
{
    var results = await openAIHelper.CreateCompletion("user", $"Based on the Javascript topic {row[1]} could you write a 1000 word blog post using this synopsis to guide you: {row[2]}","gpt-4", 0.0F, 1000, 1);
    course.Add(results);
    sb.AppendLine($"Topic: {row[1]}");
    sb.AppendLine($"Synopsis: {row[2]}");
    sb.AppendLine($"Result:");
    sb.AppendLine($"{results[0]}");
    sb.AppendLine("====================================");
}
File.WriteAllText($"Output/javascriptcourse{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.txt", sb.ToString());


