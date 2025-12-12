using System.Text.RegularExpressions;

namespace CrashLogAnalyzer;

/// <summary>
/// Regex generation during compile time.
/// </summary>
public static partial class RegexExt
{
    [GeneratedRegex(_arcdpsBuild, RegexOptions.IgnoreCase)]
    public static partial Regex ArcdpsBuild();

    [GeneratedRegex(_extensions, RegexOptions.IgnoreCase)]
    public static partial Regex Extensions();

    [GeneratedRegex(_extensionsNameAndAddress, RegexOptions.IgnoreCase)]
    public static partial Regex ExtensionsNameAndAddress();

    [GeneratedRegex(_extensionsPath, RegexOptions.IgnoreCase)]
    public static partial Regex ExtensionsPath();

    [GeneratedRegex(_extensionsDlls, RegexOptions.IgnoreCase)]
    public static partial Regex ExtensionsDll();

    [GeneratedRegex(_extensionsVersion, RegexOptions.IgnoreCase)]
    public static partial Regex ExtensionsVersion();

    [GeneratedRegex(_extensionsSignatures, RegexOptions.IgnoreCase)]
    public static partial Regex ExtensionsSignatures();

    [GeneratedRegex(_warnings, RegexOptions.IgnoreCase)]
    public static partial Regex Warnings();

    [GeneratedRegex(_warningsLoadedExtensions, RegexOptions.IgnoreCase)]
    public static partial Regex WarningsLoadedExtensions();

    [GeneratedRegex(_errors, RegexOptions.IgnoreCase)]
    public static partial Regex Errors();

    [GeneratedRegex(_stackTraces, RegexOptions.IgnoreCase)]
    public static partial Regex StackTraces();

    [GeneratedRegex(_systemDll, RegexOptions.IgnoreCase)]
    public static partial Regex SystemDll();

    [GeneratedRegex(_arcdpsAsAddon, RegexOptions.IgnoreCase)]
    public static partial Regex ArcdpsAsAddon();

    [GeneratedRegex(_windows, RegexOptions.IgnoreCase)]
    public static partial Regex Windows();

    [GeneratedRegex(_cpu, RegexOptions.IgnoreCase)]
    public static partial Regex Cpu();

    [GeneratedRegex(_ram, RegexOptions.IgnoreCase)]
    public static partial Regex Ram();

    [GeneratedRegex(_gpu, RegexOptions.IgnoreCase)]
    public static partial Regex Gpu();

    [GeneratedRegex(_wine, RegexOptions.IgnoreCase)]
    public static partial Regex Wine();

    private const string _arcdpsBuild = @"(?:build\s+|arcdps\s+)?([0-9]{8}\.[0-9]{6}-[0-9]+-[A-Za-z0-9]+)";
    private const string _extensions = @"^.*extensions:.*$";
    private const string _extensionsNameAndAddress = @"extensions:\s*(.+?)\s+(0x[0-9A-Fa-f]+)-(0x[0-9A-Fa-f]+)";
    private const string _extensionsPath = @"extensions:.*?\(([^,]+)";
    private const string _extensionsDlls = @"extensions:.*?\([^,]*[\\/](.+?\.dll)";
    private const string _extensionsVersion = @"dll,\s*([^,]+)";
    private const string _extensionsSignatures = @",\s*([A-Fa-f0-9]+)\)\s*$";
    private const string _warnings = @"warning:\s*(.+)$";
    private const string _warningsLoadedExtensions = @"warning:\s+skipped extension\s+""([^""]+)""\s*:\s*already loaded";
    private const string _errors = @"error:\s*(.*"")(?=[^""\r\n]*$)";
    private const string _stackTraces = @"^(0x[0-9A-Fa-f]+):\s+(0x[0-9A-Fa-f]+)\s+:0\+([0-9A-Fa-f]+)\s+(\S+)(?:\s+\(via export\))?";
    private const string _systemDll = @"([A-Za-z0-9_\-]+\.dll)";
    private const string _arcdpsAsAddon = @"^.*\bas addon\b.*$";
    private const string _windows = @"^\s*windows:\s*([0-9]+(?:\.[0-9]+)*)\s*$";
    private const string _cpu = @"^\s*cpu:\s*(.+)$";
    private const string _ram = @"^\s*ram:\s*(.+)$";
    private const string _gpu = @"^\s*gpu:\s*(.+)$";
    private const string _wine = @"^\s*wine:\s*(.+)$";
}
