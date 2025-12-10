using Discord;
using System.Text;
using System.Text.RegularExpressions;
using static CrashLogAnalyzer.RegexExt;
using static CrashLogAnalyzer.Traces;

namespace CrashLogAnalyzer;

/// <summary>
/// Main class for parsing ArcDPS crash logs.
/// </summary>
public partial class LogParser
{
    /// <summary>
    /// Validates the attachment file type to be .log or .txt.
    /// </summary>
    public bool IsValidFormat { get; private set; } = false;
    /// <summary>
    /// Validates a log by the presence of "info: build" for the ArcDPS build.
    /// </summary>
    public bool HasValidContent { get; private set; } = false;
    /// <summary>
    /// ArcDPS related information.
    /// </summary>
    public ArcDPS ArcDPS { get; private set; } = new();
    /// <summary>
    /// Warning messages.
    /// </summary>
    public HashSet<string> Warnings { get; private set; } = [];
    /// <summary>
    /// Error messages.
    /// </summary>
    public HashSet<string> Errors { get; private set; } = [];
    /// <summary>
    /// Other Dlls loaded in the system. Used to check for possible interference.
    /// </summary>
    public List<string> SystemDlls { get; private set; } = [];
    /// <summary>
    /// Stack traces.
    /// </summary>
    public List<StackTrace> StackTraces { get; private set; } = [];
    /// <summary>
    /// Information for the loaded ArcDPS Extensions.
    /// </summary>
    public List<Extension> Extensions { get; private set; } = [];
    /// <summary>
    /// The top-most trace for each file.
    /// </summary>
    public Dictionary<string, StackTrace> TopMostStackTraces { get; private set; } = [];
    /// <summary>
    /// Possible causes of the crash log.
    /// </summary>
    public List<string> PossibleCauses { get; private set; } = [];
    /// <summary>
    /// User system information.
    /// </summary>
    public System System { get; private set; } = new();
    /// <summary>
    /// Log line containing "info: game exit". Present for crash log on game shut down.
    /// </summary>
    public bool GameExit { get; private set; } = false;

    /// <summary>
    /// Downloads the attachment in the message.
    /// </summary>
    /// <param name="attachment">The <see cref="Attachment"/> contained in the message.</param>
    /// <returns>The parsed <see cref="LogParser"/> log.</returns>
    public static async Task<LogParser> DownloadAttachment(Attachment attachment)
    {
        try
        {
            string fileName = attachment.Filename.ToLower();
            if (fileName.EndsWith(".log") || fileName.EndsWith(".txt"))
            {
                ConsoleTrace("Attachment with .log or .txt found.");

                // Download file content and convert
                using HttpClient httpClient = new();
                byte[] fileBytes = await httpClient.GetByteArrayAsync(attachment.Url);
                string fileContent = Encoding.UTF8.GetString(fileBytes);
                string[] fileByLine = fileContent.Split('\n');
                if (fileByLine.Length > 0)
                {
                    ConsoleTrace("Attachment downloaded and converted.");
                    return ParseLog(fileByLine);
                }
            }
            else
            {
                ConsoleTrace("Skipped attachment: not a .log or .txt file.");
            }
        }
        catch (Exception ex)
        {
            ConsoleTrace("Error downloading the attachment.");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }

        return new LogParser();
    }

    /// <summary>
    /// Parse the attachment as an array of strings split by '\n'.
    /// </summary>
    /// <param name="file">The attachment as strings array.</param>
    /// <returns>The parsed <see cref="LogParser"/> log.</returns>
    private static LogParser ParseLog(string[] file)
    {
        ConsoleTrace("Parsing started");

        LogParser log = new()
        {
            IsValidFormat = true,
            HasValidContent = file.Any(x => x.Contains("info: build")),
            GameExit = file.Any(x => x.Contains("info: game exit")),
        };

        foreach (string line in file)
        {
            // ArcDPS Build
            Match buildMatch = ArcdpsBuild().Match(line);
            if (buildMatch.Success)
            {
                log.ArcDPS.Build = buildMatch.Groups[1].Value.Trim();
            }

            // ArcDPS loaded as addon
            Match asAddonMatch = ArcdpsAsAddon().Match(line);
            if (asAddonMatch.Success)
            {
                string path = Path.Combine(["addons", "arcdps", "gw2addon_arcdps.dll"]);
                if (line.Contains(path) || line.Contains(path.Replace('/', '\\')))
                {
                    log.ArcDPS.Method = ArcDPS.LoadMethod.AddonLoader;
                }
                else
                {
                    log.ArcDPS.Method = ArcDPS.LoadMethod.Nexus;
                }
            }
            if (line.Contains("as proxy") && line.Contains("d3d11.dll"))
            {
                log.ArcDPS.Method = ArcDPS.LoadMethod.Standalone;
            }

            // Extensions
            Match addonMatch = Extensions().Match(line);
            if (addonMatch.Success)
            {
                Extension addon = new();

                // Name
                Match nameAddressMatch = ExtensionsNameAndAddress().Match(line);
                if (nameAddressMatch.Success)
                {
                    addon.Name = nameAddressMatch.Groups[1].Value.Trim();
                    addon.Address = $"{nameAddressMatch.Groups[2].Value.Trim()}-{nameAddressMatch.Groups[3].Value.Trim()}";
                }

                // Dll
                Match dllMatch = ExtensionDll().Match(line);
                if (dllMatch.Success)
                {
                    addon.Dll = dllMatch.Groups[1].Value.Trim();
                }

                // Version
                Match versionMatch = ExtensionsVersion().Match(line);
                if (versionMatch.Success)
                {
                    addon.Version = versionMatch.Groups[1].Value.Trim();
                }

                // Signature
                Match signatureMatch = ExtensionsSignatures().Match(line);
                if (signatureMatch.Success)
                {
                    addon.Signature = signatureMatch.Groups[1].Value;
                }

                log.Extensions.Add(addon);
            }

            // Warnings
            Match warningsMatch = Warnings().Match(line);
            if (warningsMatch.Success)
            {
                log.Warnings.Add(warningsMatch.Groups[1].Value.Trim());
            }

            // Errors
            Match errorsMatch = Errors().Match(line);
            if (errorsMatch.Success)
            {
                log.Errors.Add(errorsMatch.Groups[1].Value.Trim());
            }

            // DLLs
            Match systemDllMatch = SystemDll().Match(line);
            if (systemDllMatch.Success)
            {
                log.SystemDlls.Add(systemDllMatch.Groups[1].Value.Trim());
            }

            // Stack
            Match stackMatch = StackTraces().Match(line.Trim());
            if (stackMatch.Success)
            {
                log.StackTraces.Add(new StackTrace
                {
                    Trace = stackMatch.Groups[1].Value,
                    Frame = stackMatch.Groups[2].Value,
                    Rva = stackMatch.Groups[3].Value,
                    FileShort = stackMatch.Groups[4].Value,
                    ViaExport = line.Contains("(via export)"),
                });
            }

            // System
            Match windowsMatch = Windows().Match(line);
            if (windowsMatch.Success)
            {
                log.System.Windows = windowsMatch.Groups[1].Value.Trim();
            }

            Match cpuMatch = Cpu().Match(line);
            if (cpuMatch.Success)
            {
                log.System.Cpu = cpuMatch.Groups[1].Value.Trim();
            }

            Match ramMatch = Ram().Match(line);
            if (ramMatch.Success)
            {
                log.System.Ram = ramMatch.Groups[1].Value.Trim();
            }

            Match gpuMatch = Gpu().Match(line);
            if (gpuMatch.Success)
            {
                log.System.Gpu = gpuMatch.Groups[1].Value.Trim();
            }

            Match wineMatch = Wine().Match(line);
            if (wineMatch.Success)
            {
                log.System.Wine = wineMatch.Groups[1].Value.Trim();
            }
        }

        // Top-most stack trace entry per file name
        foreach (StackTrace entry in log.StackTraces)
        {
            string fileShort = entry.FileShort!;

            if (!log.TopMostStackTraces.ContainsKey(fileShort))
            {
                log.TopMostStackTraces[fileShort] = entry;
            }
        }

        // Possible causes
        foreach (var group in log.TopMostStackTraces.Where(x => !x.Value.ViaExport))
        {
            log.PossibleCauses.Add(group.Value.FileShort!);
        }

        ConsoleTrace("Parsing completed.");

        return log;
    }
}
