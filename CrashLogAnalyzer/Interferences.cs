namespace CrashLogAnalyzer;

/// <summary>
/// Known software dll inferference.
/// </summary>
public static class Interference
{
    private static readonly IReadOnlyList<string> AsusGPUTweakIII = ["glew32.dll", "GTIII-OSD64-GL.dll", "GTIII-OSD64-VK.dll", "GTIII-OSD64.dll"];
    private static readonly IReadOnlyList<string> BitDefender = ["bdhkm64.dll", "atcuf64.dll"];
    private static readonly IReadOnlyList<string> Groupy = ["groupy_64.dll"];
    private static readonly IReadOnlyList<string> Medal = ["medal-hook64.dll"];
    private static readonly IReadOnlyList<string> NvidiaPhotoModeGameFilter = ["NvCamera64.dll"];
    private static readonly IReadOnlyList<string> NvidiaSmoothMotion = ["nvcuda64.dll", "nvdxgdmal64.dll", "NvPresent64.dll"];
    private static readonly IReadOnlyList<string> Overwolf = ["OWClient.dll", "OWExplorer.dll", "OWUtils.dll"];
    private static readonly IReadOnlyList<string> RivaTurnerStatisticsServer = ["RTSSHooks64.dll"];

    /// <summary>
    /// Grouped dll groups by software names.
    /// </summary>
    public static readonly Dictionary<string, IReadOnlyList<string>> DllGroups = new()
    {
        { "Asus GPU Tweak III", AsusGPUTweakIII },
        { "Bit Defender", BitDefender },
        { "Groupy", Groupy },
        { "Medal", Medal },
        { "Nvidia Photo Mode", NvidiaPhotoModeGameFilter },
        { "Nvidia Smooth Motion", NvidiaSmoothMotion },
        { "Overwolf", Overwolf },
        { "RivaTurner Statistics Server", RivaTurnerStatisticsServer },
    };

    /// <summary>
    /// Software interference names.
    /// </summary>
    public static readonly string Software = string.Join("\n",
    [
        "- Bit Defender",
        "- Groupy",
        "- Citrix Workspace (v22+)",
        "- MyDesk Shield",
        "- Nvidia's GeForce Overlay",
        "- Nvidia's Smooth Motion",
        "- ASUS GPU Tweak III",
        "- Afterburner",
        "- RivaTuner Statistics Server",
        "- Medal",
        "- Overwolf",
        "- Razer Cortex"
    ]);
}
