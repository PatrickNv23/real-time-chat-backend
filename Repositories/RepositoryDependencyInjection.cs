using real_time_chat_backend.Repositories.Implementations;
using real_time_chat_backend.Repositories.Interfaces;

namespace real_time_chat_backend.Repositories;

public static class RepositoryDependencyInjection
{
    public static IServiceCollection AddRepositoryDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IAuthRepository, AuthRepository>();
        
        return services;
    }
}