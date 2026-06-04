namespace CrashLogAnalyzer;

/// <summary>
/// Information about the game client.
/// </summary>
public class ClientInfo
{
    /// <summary>
    /// Map name.
    /// </summary>
    public string MapName { get; set; } = "";
    /// <summary>
    /// Map ID.
    /// </summary>
    public string MapId { get; set; } = "";
    /// <summary>
    /// Location X coordinate.
    /// </summary>
    public string LocationX { get; set; } = "";
    /// <summary>
    /// Location Y coordinate.
    /// </summary>
    public string LocationY { get; set; } = "";
    /// <summary>
    /// Location Z coordinate.
    /// </summary>
    public string LocationZ { get; set; } = "";
}
