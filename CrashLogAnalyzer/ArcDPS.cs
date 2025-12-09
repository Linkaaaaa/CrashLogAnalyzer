namespace CrashLogAnalyzer;

/// <summary>
/// ArcDPS information.
/// </summary>
public class ArcDPS
{
    /// <summary>
    /// Build number.
    /// </summary>
    public string Build { get; set; } = "";
    /// <summary>
    /// Loading Method.
    /// </summary>
    public LoadMethod Method { get; set; } = LoadMethod.Standalone;
    
    /// <summary>
    /// Loading method.
    /// <list type="bullet">
    /// <item>Standalone</item>
    /// <item>Addon Loader</item>
    /// <item>Nexus</item>
    /// </list>
    /// </summary>
    public enum LoadMethod : int
    {
        Standalone = 0,
        AddonLoader = 1,
        Nexus = 2,
    }
}
