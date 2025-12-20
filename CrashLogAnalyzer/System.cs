namespace CrashLogAnalyzer;

/// <summary>
/// System information.
/// </summary>
public class System
{
    /// <summary>
    /// Windows build version.
    /// </summary>
    public string Windows { get; set; } = "";
    /// <summary>
    /// CPU model.
    /// </summary>
    public string Cpu { get; set; } = "";
    /// <summary>
    /// Ram used.
    /// </summary>
    public string Ram { get; set; } = "";
    /// <summary>
    /// GPU model.
    /// </summary>
    public string Gpu { get; set; } = "";
    /// <summary>
    /// Vram used.
    /// </summary>
    public string Vram { get; set; } = "";
    /// <summary>
    /// Wine version.
    /// </summary>
    /// <remarks>Linux only.</remarks>
    public string Wine { get; set; } = "";
}
