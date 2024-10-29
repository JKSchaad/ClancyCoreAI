using System.ComponentModel.DataAnnotations;

namespace ClancyCoreAI.API.DTOs.RFIs;

public class RfiDto
{
    [Required]
    public string Id { get; set; } = string.Empty;

    [Required]
    public string ProjectId { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Number { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Subject { get; set; } = string.Empty;

    [Required]
    [StringLength(2000)]
    public string Question { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Status { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Priority { get; set; } = string.Empty;

    [Required]
    public DateTime DateSubmitted { get; set; }

    public DateTime? DateRequired { get; set; }
    public DateTime? DateAnswered { get; set; }

    [Required]
    [StringLength(100)]
    public string SubmittedBy { get; set; } = string.Empty;

    [StringLength(100)]
    public string AssignedTo { get; set; } = string.Empty;

    [StringLength(2000)]
    public string Answer { get; set; } = string.Empty;

    [StringLength(100)]
    public string AnsweredBy { get; set; } = string.Empty;

    public List<string> AttachmentUrls { get; set; } = new();
    public List<string> RelatedDrawings { get; set; } = new();
    public List<string> RelatedSpecifications { get; set; } = new();

    [Range(0, int.MaxValue)]
    public int DaysOutstanding { get; set; }

    [Range(0, double.MaxValue)]
    public decimal CostImpact { get; set; }

    [Range(0, int.MaxValue)]
    public int ScheduleImpact { get; set; }
} 