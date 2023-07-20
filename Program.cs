

using Helpers;
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
var excelHelper = new ExcelHelper("./titanic.csv");
excelHelper.ReadWorkBook();

// var apiKey = "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";

// var gpt3 = new OpenAIService(new OpenAiOptions() { ApiKey = apiKey });

// var completionResult = await gpt3.ChatCompletion.CreateCompletion(new OpenAI.ObjectModels.RequestModels.ChatCompletionCreateRequest() {
//     Messages = new List<ChatMessage>(new ChatMessage[] {
//         new ChatMessage("user", "how t learn c# in 24 hours") }),
//         Model = Models.Gpt_4,
//         Temperature = 0.5F,
//         MaxTokens = 1000,
//         N = 3
//     });

// if (completionResult.Successful)
// {
//     foreach (var choice in completionResult.Choices)
//     {
//         Console.WriteLine(choice.Message.Content);
//     }
// }
// else
// {
//     if(completionResult.Error == null)
//     {
//         throw new Exception("Unknown Error");
//     }
//     Console.WriteLine($"{completionResult.Error.Code}: {completionResult.Error.Message}");
// }

