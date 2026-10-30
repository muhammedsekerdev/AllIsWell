using AllIsWell.Users.Application.Register;
using Microsoft.Extensions.DependencyInjection;

namespace AllIsWell.Users.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddUsersApplication(this IServiceCollection services)
    {
        services.AddScoped<RegisterUserHandler>();

        return services;
    }
}
