using BeaverLeague.Client.Components;
using BeaverLeague.Client.Services;
using Blazor.Extensions.Logging;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ApiClient>();
        services.AddLogging(builder => builder
            .AddBrowserConsole()
            .SetMinimumLevel(LogLevel.Trace));    
    }

    public void Configure(IBlazorApplicationBuilder app)
    {
        app.AddComponent<App>("body");
    }
}