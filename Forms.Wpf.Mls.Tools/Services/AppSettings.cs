namespace Forms.Wpf.Mls.Tools.Services;

using Forms.Wpf.Mls.Tools.Models;
using System.IO;

public static class AppSettings
{

    public static bool Save(object? obj, WindowsLocation location, string fileName)
    {
        string path = JsonPath(location, fileName);
        return Save(obj, path);
    }
    public static bool Save(object? obj, string filePath)
    {
        return JsonConvert.ObjectToJsonFile(obj, filePath);
    }

    public static object? Load(object? obj, WindowsLocation location, string fileName)
    {
        string path = JsonPath(location, fileName);
        return Load(obj, path);
    }
    public static object? Load(object? obj, string filePath)
    {
        return JsonConvert.JsonFileToObject(obj, filePath);
    }

    public static string JsonPath(WindowsLocation location, string fileName)
    {
        string appNmae = AssemblyProperties.AssemblyName ?? "appNmae";
        string? winAppLocation = location switch
        {
            WindowsLocation.OwnApp => AssemblyProperties.ExeDir,
            WindowsLocation.ProgramData => SpecialFolders.CommonAppData,
            WindowsLocation.LocalData => SpecialFolders.LocalAppData,
            WindowsLocation.RoamingData => SpecialFolders.RoamingFolder,
            _ => SpecialFolders.LocalAppData,
        };
        string dir = Path.Combine(winAppLocation ?? SpecialFolders.LocalAppData, appNmae);
        if (location == WindowsLocation.OwnApp && !string.IsNullOrWhiteSpace(winAppLocation))
            dir = winAppLocation;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        fileName = !string.IsNullOrWhiteSpace(fileName) ? fileName : appNmae;
        return Path.Combine(dir, fileName + ".json");
    }

}
// add summaries