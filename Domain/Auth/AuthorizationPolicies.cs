using Microsoft.Extensions.DependencyInjection;

namespace Domain.Auth;


/*/ask jakob how to implements/*/


public class AuthorizationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        services.AddAuthorizationCore(options =>
        {
            options.AddPolicy("MustBeLoggedIn", a =>
                a.RequireAuthenticatedUser().RequireClaim("LoggedIn", "Yes", "yes"));
        });
    }
}
