
using OpenAI;
using OpenAI.Managers;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;

namespace Helpers;

public class OpenAIHelper
{
    // private readonly static string apiKey = "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";
    // private readonly OpenAIService _service;

    public OpenAIHelper(string apiKey = "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")
    {
        Console.WriteLine(apiKey);
        this.Service = new OpenAIService(new OpenAiOptions() { ApiKey = apiKey });
    }

    public OpenAIService Service { get; set; }

    public async Task<List<string>> CreateCompletion(string actor, string prompt, string model = "gpt_4", float temperature = 0.5F, int maxTokens = 1000, int n = 3)
    {
        var completionResult = await this.Service.ChatCompletion.CreateCompletion(new OpenAI.ObjectModels.RequestModels.ChatCompletionCreateRequest()
        {
            Messages = new List<ChatMessage>(new ChatMessage[]
            {
               new ChatMessage(actor, prompt) }),
               Model = Models.Gpt_4,
               Temperature = temperature,
               MaxTokens = maxTokens,
               N = n
            });

        List<string> returnList = new();
        if (completionResult.Successful)
        {
            foreach (var choice in completionResult.Choices)
            {
                returnList.Add(choice.Message.Content);
            }
        }
        else
        {
            if (completionResult.Error == null)
            {
                returnList.Add("Unknown Error");
            }
            else
            {
                returnList.Add($"{completionResult.Error.Code}: {completionResult.Error.Message}");
            }

        }
        return returnList;
        
    }


}


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