var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.ClancyCoreAI_API>("Clancycoreai-api");

builder.Build().Run();
