namespace ClancyCoreAI.Core.Configuration;

public class AzureOpenAISettings
{
    public string Endpoint { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public string DeploymentName { get; set; } = string.Empty;
    public float Temperature { get; set; } = 0.7f;
    public int MaxTokens { get; set; } = 2000;
} 