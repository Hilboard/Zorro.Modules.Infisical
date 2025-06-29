using Infisical.Sdk;
using Zorro.Extensions;
using Zorro.Secrets;

namespace Zorro.Modules.Infisical;

public class InfisicalSecretsManager : SecretsManager
{
    public InfisicalClient client { get; private set; }
    public string projectId { get; private set; }

    public InfisicalSecretsManager(InfisicalClient client, string projectId)
    {
        this.client = client;
        this.projectId = projectId;
    }

    public override string GetSecret(string key)
    {
        return GetSecret("/", key);
    }

    public override string GetSecret(string path, string key)
    {
        var getSecretOptions = new GetSecretOptions
        {
            Path = path,
            SecretName = key,
            ProjectId = projectId,
            Environment = ZorroDI.environment.ToReabableValue()
        };

        var secret = client.GetSecret(getSecretOptions);

        return secret.SecretValue;
    }
}