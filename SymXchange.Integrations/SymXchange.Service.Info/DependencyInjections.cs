using Microsoft.Extensions.DependencyInjection;
using SymXchange.Service.Configuration;

namespace SymXchange.Service.Info;

public static class DependencyInjections
{
    public static IServiceCollection AddSymXchangeEpisysInformationService
        (this IServiceCollection services, string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString));
        }

        services.AddTransient<EpisysInformationService, EpisysInformationServiceClient>
            (provider => new EpisysInformationServiceClient(connectionString, SymXchangeServiceType.EpisysInformation));
        return services;
    }
}
