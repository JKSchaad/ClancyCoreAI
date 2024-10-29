using ClancyCoreAI.Core.Configuration;
using ClancyCoreAI.Core.Interfaces;
using ClancyCoreAI.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add this near your other service configurations
builder.Services.Configure<AzureOpenAISettings>(
    builder.Configuration.GetSection("AzureOpenAI"));

builder.Services.AddScoped<IAiService, AzureOpenAiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
