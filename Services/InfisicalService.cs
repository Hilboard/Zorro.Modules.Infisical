using Infisical.Sdk;
using Microsoft.Extensions.DependencyInjection;
using Zorro.Modules.Infisical;

namespace Zorro.Services;

public static class Services
{
    public static IServiceCollection AddInfisical(this IServiceCollection services, InfisicalSettings settings)
    {
        ClientSettings clientSettings = new ClientSettings()
        {
            Auth = new AuthenticationOptions
            {
                UniversalAuth = new UniversalAuthMethod
                {
                    ClientId = settings.clientId,
                    ClientSecret = settings.clientSecret,
                }
            },
            SiteUrl = settings.URL
        };

        InfisicalClient client = new InfisicalClient(clientSettings);
        ZorroDI.secretsManager = new InfisicalSecretsManager(client, settings.projectId); ;

        return services;    
    }
}