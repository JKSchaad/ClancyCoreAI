using Microsoft.AspNetCore.Mvc;

namespace ClancyCoreAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SafetyController : ControllerBase
{
    private readonly ILogger<SafetyController> _logger;

    public SafetyController(ILogger<SafetyController> logger)
    {
        _logger = logger;
    }

    [HttpGet("inspections")]
    public async Task<IActionResult> GetSafetyInspections()
    {
        _logger.LogInformation("Getting safety inspections");
        return Ok("Safety inspections endpoint working!");
    }

    [HttpPost("ai-analysis")]
    public async Task<IActionResult> AnalyzeSafetyReport([FromBody] string reportContent)
    {
        _logger.LogInformation("Analyzing safety report with AI");
        return Ok("AI safety analysis endpoint working!");
    }

    [HttpGet("training")]
    public async Task<IActionResult> GetSafetyTraining()
    {
        _logger.LogInformation("Getting AI-powered safety training materials");
        return Ok("Safety training endpoint working!");
    }
}