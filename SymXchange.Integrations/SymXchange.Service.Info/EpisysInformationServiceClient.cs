using SymXchange.Service.Configuration;
using System.ServiceModel;

namespace SymXchange.Service.Info;

public partial class EpisysInformationServiceClient : ClientBase<EpisysInformationService>, EpisysInformationService
{
    public EpisysInformationServiceClient(string connectionString, SymXchangeServiceType symxServiceType) : 
        base(GetHttpBinding(), GetEndpointAddress(new SymXchangeSettings(connectionString, symxServiceType)))
    {
        SymXchangeSettings = new SymXchangeSettings(connectionString, SymXchangeServiceType.EpisysInformation);
    }

    private static BasicHttpBinding GetHttpBinding()
    {
        return new BasicHttpBinding
        {
            Namespace = SymXchangeNamespace.SymXchangeEpisysInformation.ToString(),
            MaxBufferSize = int.MaxValue,
            MaxReceivedMessageSize = int.MaxValue
        };
    }

    private static EndpointAddress GetEndpointAddress(SymXchangeSettings settings)
    {
        return new EndpointAddress(ValidateUri(settings.Endpoint));
    }

    private static string ValidateUri(string uriString)
    {
        if(string.IsNullOrWhiteSpace(uriString))
        {
            throw new NullReferenceException("Endpoint can't be null");
        }

        if (!Uri.TryCreate(uriString, UriKind.Absolute, out Uri uri))
        {
            throw new UriFormatException($"Invalid URI {uriString}: The URI scheme is not valid. ");
        }
        var url = uri.ToString();
        return url;
    }

    public SymXchangeSettings SymXchangeSettings { get; init; }
}