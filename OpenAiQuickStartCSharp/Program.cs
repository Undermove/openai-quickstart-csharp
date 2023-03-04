using OpenAiQuickStartCSharp;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

const string aspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";
string? environmentName = Environment.GetEnvironmentVariable(aspNetCoreEnvironment);

builder.Configuration.AddJsonFile($"appsettings.{environmentName}.json");

builder.Host.ConfigureAppConfiguration((_, config) =>
{
    config.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);
});

builder.Services.Configure<OpenAiConfig>(builder.Configuration.GetSection("OpenAiConfig"));

var app = builder.Build();

app.MapGet("/", () => "<html>Hello World!</html>");
app.MapControllers();
app.UseRouting();
app.Run();