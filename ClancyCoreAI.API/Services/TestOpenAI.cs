using Azure.AI.OpenAI;

namespace ClancyCoreAI.API.Services;

public class TestOpenAI
{
    public void Test()
    {
        var message = new Azure.AI.OpenAI.ChatRequestMessage(Azure.AI.OpenAI.ChatRole.System, "test");
    }
} 