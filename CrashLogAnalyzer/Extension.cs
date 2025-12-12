namespace CrashLogAnalyzer;

/// <summary>
/// ArcDPS extensions information.
/// </summary>
public class Extension
{
    /// <summary>
    /// Extension name.
    /// </summary>
    public string Name { get; set; } = "";
    /// <summary>
    /// File path.
    /// </summary>
    public string Path { get; set; } = "";
    /// <summary>
    /// Extension dll file name.
    /// </summary>
    public string Dll { get; set; } = "";
    /// <summary>
    /// Memory address.
    /// </summary>
    public string Address { get; set; } = "";
    /// <summary>
    /// Build version.
    /// </summary>
    public string Version { get; set; } = "";
    /// <summary>
    /// Unique signature.
    /// </summary>
    public string Signature { get; set; } = "";
}
