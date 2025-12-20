namespace CrashLogAnalyzer;

/// <summary>
/// Loaded system files information.
/// </summary>
public class SystemFile
{
    /// <summary>
    /// Start and end memory addresses.
    /// </summary>
    public string ModuleRange { get; set; } = "";
    /// <summary>
    /// Full path to the file.
    /// </summary>
    public string Path { get; set; } = "";
    /// <summary>
    /// Loaded file name.
    /// </summary>
    public string File { get; set; } = "";
}

