using System.Runtime.CompilerServices;
using real_time_chat_backend.Services.Implementations;
using real_time_chat_backend.Services.Interfaces;

namespace real_time_chat_backend.Services;

public static class ServiceDependencyInjection
{
    public static IServiceCollection AddServiceDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        
        return services;
    }
}