using System.Security.Claims;
using Blazor.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Auth;

public class Authentication : AuthenticationStateProvider
{
    private readonly IAuthService _authService;

    public Authentication(IAuthService authService)
    {
        _authService = authService;
        authService.OnAuthStateChanged += AuthStateChanged;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = await _authService.GetAuthAsync();

        return new AuthenticationState(principal);
    }

    private void AuthStateChanged(ClaimsPrincipal principal)
    {
        NotifyAuthenticationStateChanged(
            Task.FromResult(
                new AuthenticationState(principal)
            )
        );
    }
}
