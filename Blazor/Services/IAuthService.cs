using System.Security.Claims;
using Domain.Models;

namespace Blazor.Services;

public interface IAuthService
{
    public Task LoginAsync(string? username, string? password);
    public Task LogoutAsync();
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    public Task<ClaimsPrincipal> GetAuthAsync();
}
