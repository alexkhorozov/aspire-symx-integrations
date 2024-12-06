namespace SymXchange.Service.Configuration;
/// <summary>
/// SymXchange Options class represent common settings for SymXchange services
/// </summary>
public class SymXchangeSettings
{
    /// <summary>
    /// Configurationsection where settings stored
    /// </summary>
    public const string ConfigurationSection = "Symitar";
    /// <summary>
    /// Empty constructor
    /// </summary>
    public SymXchangeSettings()
    {

    }
    /// <summary>
    /// Initializes a new instance of the <see cref="SymXchangeSettings"/> class using the provided connection string.
    /// </summary>
    /// <param name="connectionString">The connection string to parse and initialize the settings.</param>
    public SymXchangeSettings(string connectionString)
    {
        ParseConnectionString(connectionString);
    }
    /// <summary>
    /// SymXchange Options default constructor
    /// </summary>
    /// <param name="endpoint">endpoint URI</param>
    /// <param name="password">SymXchange Admin service password</param>
    public SymXchangeSettings(string endpoint, string password)
    {
        Endpoint = endpoint;
        Password = password;
    }
    /// <summary>
    /// SymXchange service default Branch Id
    /// </summary>
    public short BranchId { get; set; } = SymXchangeDefaults.SYMX_BRANCH_ID;
    /// <summary>
    /// SymXchange service default Device Number
    /// </summary>
    public short DeviceNumber { get; set; } = SymXchangeDefaults.SYMX_DEVICE_NUMBER;
    /// <summary>
    /// SymXchange service instance name
    /// </summary>
    public string DeviceType { get; set; } = SymXchangeDefaults.SYMX_DEVICE_TYPE;
    /// <summary>
    /// SymXchange service endpoint URI
    /// </summary>
    public string Endpoint { get; set; } = string.Empty;
    /// <summary>
    /// SymXchange service default Message Id
    /// </summary>
    public string MessageId { get; set; } = SymXchangeDefaults.SYMX_MESSAGE_ID;
    /// <summary>
    /// SymXchange service Admin password
    /// </summary>
    public string Password { get; set; } = string.Empty;
    /// <summary>
    /// SymXchange service default Teller Id
    /// </summary>
    public short TellerId { get; set; } = SymXchangeDefaults.SYMX_TELLER_ID;

    /// <summary>
    /// Parse connection string and initialize settings
    /// </summary>
    /// <param name="connectionString"></param>
    private void ParseConnectionString(string connectionString)
    {
        var settings = ConnectionStringParser.Parse(connectionString);

        BranchId = settings.TryGetValue("BranchId", out string? branchId) ? short.Parse(branchId) : SymXchangeDefaults.SYMX_BRANCH_ID;
        DeviceNumber = settings.TryGetValue("DeviceNumber", out string? deviceNumber) ? short.Parse(deviceNumber) : SymXchangeDefaults.SYMX_DEVICE_NUMBER;
        DeviceType = settings.TryGetValue("DeviceType", out string? deviceType) ? deviceType : SymXchangeDefaults.SYMX_DEVICE_TYPE;
        Endpoint = settings.TryGetValue("Endpoint", out string? endpoint) ? endpoint : string.Empty;
        MessageId = settings.TryGetValue("MessageId", out string? messageId) ? messageId : SymXchangeDefaults.SYMX_MESSAGE_ID;
        Password = settings.TryGetValue("Password", out string? pasword) ? pasword : string.Empty;
        TellerId = settings.TryGetValue("TellerId", out string? tellerId) ? short.Parse(tellerId) : SymXchangeDefaults.SYMX_TELLER_ID;
    }}
