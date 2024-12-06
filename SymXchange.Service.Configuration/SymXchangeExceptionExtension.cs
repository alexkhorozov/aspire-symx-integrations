namespace SymXchange.Service.Configuration;

internal static class SymXchangeExceptionExtension
{
    internal static string ProcessExceptionMessage(this string message, int statusCode)
    {
        return ProcessExceptionMessage($"Status Code # {statusCode} - {message}");
    }

    internal static string ProcessExceptionMessage(this string message)
    {
        message = message.Replace(SymXchangeDefaults.SYMX_ERROR_MESSAGE_PREFIX, string.Empty);
        message = message.Contains("client authentication scheme 'Anonymous'") ? 
            "The IP address not in whitelist in SymXchange Console." : message;
        var messages = message.Split(':');

        return messages[0].Trim();
    }
}
