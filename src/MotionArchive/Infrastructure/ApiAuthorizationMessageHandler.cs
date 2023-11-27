using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace MotionArchive.Infrastructure;

public class ApiAuthorizationMessageHandler : AuthorizationMessageHandler
{
    public ApiAuthorizationMessageHandler(IAccessTokenProvider provider, 
        NavigationManager navigation, IConfiguration configuration)
        : base(provider, navigation)
    {
        const string azureScopes = "AzureScopes";
        const string workoutApiBaseurl = "WorkoutApi:BaseUrl";
        
        ConfigureHandler(
            authorizedUrls: new[] { configuration[workoutApiBaseurl] 
                                    ?? throw new ArgumentException("No authorized Urls provided.") },
            scopes: configuration.GetSection(azureScopes).Get<List<string>>() ?? new List<string>());
    }
}