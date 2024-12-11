using SymXchange.Service.Configuration;

namespace SymXchange.Service.Info;

public partial interface EpisysInformationService
{
    SymXchangeSettings SymXchangeSettings { get; }
}
