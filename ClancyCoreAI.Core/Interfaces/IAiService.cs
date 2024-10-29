namespace ClancyCoreAI.Core.Interfaces
{
    public interface IAiService
    {
        Task<string> GetQuickInsight(string projectData);
        Task<string> AnalyzeProjectRisks(object projectData);
        Task<string> AnalyzeSchedule(object scheduleData);
        Task<string> AnalyzeDocuments(object documentData);
        Task<string> GenerateRecommendations(object projectMetrics);
        Task<string> PredictDelays(object projectTimeline);
    }
} 