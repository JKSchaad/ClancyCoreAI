using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ClancyCoreAI.API.Services;
using ClancyCoreAI.Core.Interfaces;

namespace ClancyCoreAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AiTestController : ControllerBase
{
    private readonly IAiService _aiService;
    private readonly ILogger<AiTestController> _logger;

    public AiTestController(IAiService aiService, ILogger<AiTestController> logger)
    {
        _aiService = aiService;
        _logger = logger;
    }

    [HttpGet("analyze-project")]
    public async Task<IActionResult> TestProjectAnalysis()
    {
        try
        {
            var projectData = new
            {
                ProjectDetails = new
                {
                    Name = "High Rise Development",
                    Location = "New York, NY",
                    Type = "Commercial",
                    Value = 25000000
                },
                CurrentStatus = new
                {
                    PercentComplete = 65,
                    Schedule = new
                    {
                        DaysAhead = 3,
                        PlannedCompletion = "2024-12-31",
                        CriticalPath = "Steel Erection, MEP Rough-in"
                    },
                    Budget = new
                    {
                        Spent = 16250000,
                        Remaining = 8750000,
                        Variance = "+250000"
                    },
                    Metrics = new
                    {
                        OpenRFIs = 12,
                        OpenSubmittals = 8,
                        SafetyIncidents = 0,
                        QualityScore = 95
                    }
                },
                Risks = new[]
                {
                    "Steel delivery delay potential",
                    "Weather impact on concrete pour",
                    "Labor shortage in MEP trades"
                }
            };

            var insight = await _aiService.GetQuickInsight(
                JsonSerializer.Serialize(projectData));

            return Ok(new 
            { 
                success = true, 
                insight,
                timestamp = DateTime.UtcNow,
                projectData
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error testing AI analysis");
            return StatusCode(500, new 
            { 
                success = false, 
                error = ex.Message,
                details = ex.ToString()
            });
        }
    }
} 