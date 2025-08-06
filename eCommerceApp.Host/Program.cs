using eCommerceApp.Infrastructure.DependencyInjection;
using eCommerceApp.Application.DependencyInjection;
using Serilog;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();
Log.Logger.Information("Application Starting Up...");
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddAplicationService();

builder.Services.AddCors(builder =>
{
    builder.AddDefaultPolicy(options =>
    {
        options.AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("https://localhost:7132",
                        "https://localhost:7063")
        .AllowCredentials();
    });
});

try { 
    var app = builder.Build();
    app.UseCors();
    app.UseSerilogRequestLogging(); // Log HTTP requests

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseInfrastructureService();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
    Log.Logger.Information("Application Started Successfully");
    app.Run();
}
catch (Exception ex)
{
    Log.Logger.Fatal(ex, "Application failed to start");
}
finally
{
    Log.CloseAndFlush();
}