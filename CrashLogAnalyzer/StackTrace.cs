namespace CrashLogAnalyzer;

/// <summary>
/// Crash log stack trace.
/// </summary>
public class StackTrace
{
    /// <summary>
    /// Address of function.
    /// </summary>
    public string Trace { get; set; } = "";
    /// <summary>
    /// Stack frame.
    /// </summary>
    public string Frame { get; set; } = "";
    /// <summary>
    /// Module relative adddress of instruction.
    /// </summary>
    public string Rva { get; set; } = "";
    /// <summary>
    /// Name of the dll file.
    /// </summary>
    public string FileShort { get; set; } = "";
    /// <summary>
    /// Wether the dll is external to the game or not.
    /// </summary>
    public bool ViaExport { get; set; } = false;
}
