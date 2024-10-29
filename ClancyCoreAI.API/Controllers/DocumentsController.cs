using Microsoft.AspNetCore.Mvc;

namespace ClancyCoreAI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly ILogger<DocumentsController> _logger;

    public DocumentsController(ILogger<DocumentsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetDocuments([FromQuery] string projectId)
    {
        _logger.LogInformation("Getting documents for project {ProjectId}", projectId);
        return Ok("Documents endpoint working!");
    }

    [HttpPost]
    public async Task<IActionResult> UploadDocument()
    {
        _logger.LogInformation("Uploading new document");
        return Ok("Document upload endpoint working!");
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchDocuments([FromQuery] string searchTerm)
    {
        _logger.LogInformation("Searching documents with AI assistance: {SearchTerm}", searchTerm);
        return Ok("AI-powered document search endpoint working!");
    }

    [HttpGet("{id}/ai-summary")]
    public async Task<IActionResult> GetDocumentAISummary(string id)
    {
        _logger.LogInformation("Generating AI summary for document {DocumentId}", id);
        return Ok("Document AI summary endpoint working!");
    }
}