namespace SymXchange.Service.Configuration;

/// <summary>  
/// Provides functionality to parse connection strings into a dictionary of settings.  
/// </summary>  
internal static class ConnectionStringParser
{
    /// <summary>  
    /// Parses the given connection string into a dictionary of key-value pairs.  
    /// </summary>  
    /// <param name="connectionString">The connection string to parse.</param>  
    /// <returns>A dictionary containing the key-value pairs from the connection string.</returns>  
    internal static Dictionary<string, string> Parse(string connectionString)
    {
        var settings = new Dictionary<string, string>();
        var pairs = connectionString.Split(';');

        foreach (var pair in pairs)
        {
            if (!string.IsNullOrWhiteSpace(pair))
            {
                var keyValue = pair.Split('=');
                if (keyValue.Length == 2)
                {
                    settings[keyValue[0].Trim()] = keyValue[1].Trim();
                }
            }
        }

        return settings;
    }
}
