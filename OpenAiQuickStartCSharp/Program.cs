using OpenAiQuickStartCSharp.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllers();

LoadConfiguration(builder);

var app = builder.Build();

app.UseStaticFiles();

app.MapControllers();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.Run();

void LoadConfiguration(WebApplicationBuilder webApplicationBuilder)
{
    const string aspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";
    string? environmentName = Environment.GetEnvironmentVariable(aspNetCoreEnvironment);
    
    webApplicationBuilder.Host.ConfigureAppConfiguration((_, config) =>
    {
        config.AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true);
        config.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);
    });
    webApplicationBuilder.Services.Configure<OpenAiConfig>(
        webApplicationBuilder.Configuration.GetSection("OpenAiConfig"));
}