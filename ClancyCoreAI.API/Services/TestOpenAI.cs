using Azure.AI.OpenAI;

namespace ClancyCoreAI.API.Services;

public class TestOpenAI
{
    public void Test()
    {
        var message = new ChatRequestMessage(ChatRole.System, "test");
    }
} 