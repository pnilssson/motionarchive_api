using System.Security.Claims;
using Application.Common.Exceptions;
using Application.Common.Interfaces;

namespace API.Services;

public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string Username => _httpContextAccessor.HttpContext?.User.FindFirstValue("name") 
                              ?? throw new NotFoundException("Username could not be found.");
    public string UserId => _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)
                            ?? throw new NotFoundException("User ID could not be found.");
}