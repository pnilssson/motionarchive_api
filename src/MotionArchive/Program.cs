using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MotionArchive;
using MotionArchive.Common;
using MotionArchive.Infrastructure;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<ApiAuthorizationMessageHandler>();

var apiUrl = builder.Configuration["WorkoutAPI:APIUrl"];
builder.Services.AddHttpClient(Constants.WebApi, 
        client => client.BaseAddress = new Uri(apiUrl 
                                               ?? throw new ArgumentException("Web API url was not provided to the Http client.")))
    .AddHttpMessageHandler<ApiAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient(Constants.WebApi));

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add(
        builder.Configuration.GetSection("AzureScopes").Get<List<string>>()?.FirstOrDefault() ?? "");
});

builder.Services.AddMudServices();

await builder.Build().RunAsync();