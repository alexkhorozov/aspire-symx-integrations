using Microsoft.Extensions.Options;
using SymXchange.Service.Configuration;
using System.ServiceModel;

namespace SymXchange.Service.Info;

public partial class EpisysInformationServiceClient : ClientBase<EpisysInformationService>, EpisysInformationService
{
    public EpisysInformationServiceClient(IOptions<SymXchangeOptions> options) :
        base(GetCustomBinding(), GetCustomRemoteAddress(options))
    { }

    private static BasicHttpBinding GetCustomBinding()
    {
        return new BasicHttpBinding
        {
            Namespace = SymXchangeNamespace.SymXchangeEpisysInformation.ToString(),
            MaxBufferSize = int.MaxValue,
            MaxReceivedMessageSize = int.MaxValue
        };
    }

    private static EndpointAddress GetCustomRemoteAddress(IOptions<SymXchangeOptions> options)
    {
        var _options = options.Value;
        return new EndpointAddress(_options.Endpoint + SymXchangeService.EpisysInformation.ToString().ToLower());
    }
}
