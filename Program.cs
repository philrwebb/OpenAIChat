using Helpers;
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
var excelHelper = new ExcelHelper("./titanic.csv");
excelHelper.ReadWorkBook();
var openAIHelper = new OpenAIHelper("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");
var results = await openAIHelper.CreateCompletion("user", "how to learn csharp in 24 hours");
foreach(var result in results)
{
    Console.WriteLine(result);
}


