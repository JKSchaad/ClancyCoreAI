using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using ClancyCoreAI.Core.Configuration;
using ClancyCoreAI.Core.Interfaces;
using System.Text.Json;

namespace ClancyCoreAI.API.Services;

public class AzureOpenAiService : IAiService
{
    private readonly OpenAIClient _client;
    private readonly ILogger<AzureOpenAiService> _logger;
    private readonly AzureOpenAISettings _settings;

    public AzureOpenAiService(IOptions<AzureOpenAISettings> settings, ILogger<AzureOpenAiService> logger)
    {
        _settings = settings.Value;
        _client = new OpenAIClient(
            new Uri(_settings.Endpoint),
            new AzureKeyCredential(_settings.ApiKey));
        _logger = logger;
    }

    public async Task<string> GetQuickInsight(string projectData)
    {
        try
        {
            var chatCompletionsOptions = new ChatCompletionsOptions
            {
                DeploymentName = _settings.DeploymentName,
                Messages =
                {
                    new ChatRequestMessage(ChatRole.System, @"You are an expert construction AI assistant..."),
                    new ChatRequestMessage(ChatRole.User, projectData)
                },
                Temperature = _settings.Temperature,
                MaxTokens = _settings.MaxTokens
            };

            var response = await _client.GetChatCompletionsAsync(chatCompletionsOptions);
            return response.Value.Choices[0].Message.Content;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting quick insight");
            throw;
        }
    }

    public async Task<string> AnalyzeProjectRisks(object projectData)
    {
        var chatCompletionsOptions = new ChatCompletionsOptions
        {
            DeploymentName = _settings.DeploymentName,
            Messages =
            {
                new ChatRequestMessage(ChatRole.System, @"Analyze project risks and provide detailed assessment."),
                new ChatRequestMessage(ChatRole.User, JsonSerializer.Serialize(projectData))
            },
            Temperature = _settings.Temperature,
            MaxTokens = _settings.MaxTokens
        };

        var response = await _client.GetChatCompletionsAsync(chatCompletionsOptions);
        return response.Value.Choices[0].Message.Content;
    }

    public async Task<string> AnalyzeSchedule(object scheduleData)
    {
        var chatCompletionsOptions = new ChatCompletionsOptions
        {
            DeploymentName = _settings.DeploymentName,
            Messages =
            {
                new ChatRequestMessage(ChatRole.System, @"Analyze construction schedule and identify optimizations."),
                new ChatRequestMessage(ChatRole.User, JsonSerializer.Serialize(scheduleData))
            },
            Temperature = _settings.Temperature,
            MaxTokens = _settings.MaxTokens
        };

        var response = await _client.GetChatCompletionsAsync(chatCompletionsOptions);
        return response.Value.Choices[0].Message.Content;
    }

    public async Task<string> AnalyzeDocuments(object documentData)
    {
        var chatCompletionsOptions = new ChatCompletionsOptions
        {
            DeploymentName = _settings.DeploymentName,
            Messages =
            {
                new ChatRequestMessage(ChatRole.System, @"Analyze construction documents and extract key information."),
                new ChatRequestMessage(ChatRole.User, JsonSerializer.Serialize(documentData))
            },
            Temperature = _settings.Temperature,
            MaxTokens = _settings.MaxTokens
        };

        var response = await _client.GetChatCompletionsAsync(chatCompletionsOptions);
        return response.Value.Choices[0].Message.Content;
    }

    public async Task<string> GenerateRecommendations(object projectMetrics)
    {
        var chatCompletionsOptions = new ChatCompletionsOptions
        {
            DeploymentName = _settings.DeploymentName,
            Messages =
            {
                new ChatRequestMessage(ChatRole.System, @"Generate actionable recommendations based on project metrics."),
                new ChatRequestMessage(ChatRole.User, JsonSerializer.Serialize(projectMetrics))
            },
            Temperature = _settings.Temperature,
            MaxTokens = _settings.MaxTokens
        };

        var response = await _client.GetChatCompletionsAsync(chatCompletionsOptions);
        return response.Value.Choices[0].Message.Content;
    }

    public async Task<string> PredictDelays(object projectTimeline)
    {
        var chatCompletionsOptions = new ChatCompletionsOptions
        {
            DeploymentName = _settings.DeploymentName,
            Messages =
            {
                new ChatRequestMessage(ChatRole.System, @"Analyze project timeline and predict potential delays."),
                new ChatRequestMessage(ChatRole.User, JsonSerializer.Serialize(projectTimeline))
            },
            Temperature = _settings.Temperature,
            MaxTokens = _settings.MaxTokens
        };

        var response = await _client.GetChatCompletionsAsync(chatCompletionsOptions);
        return response.Value.Choices[0].Message.Content;
    }
} 