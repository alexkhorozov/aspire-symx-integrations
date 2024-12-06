using Microsoft.Extensions.DependencyInjection;

namespace SymXchange.Service.Info;

public static class DependencyInjections
{
    public static IServiceCollection AddSymXchangeEpisysInformationService(this IServiceCollection services)
    {
        services.AddTransient<EpisysInformationService, EpisysInformationServiceClient>();
        return services;
    }
}
