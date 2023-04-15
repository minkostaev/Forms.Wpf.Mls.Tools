namespace Forms.Wpf.Mls.Tools.Services;

using Forms.Wpf.Mls.Tools.Models;
using System.IO;

public static class JsonSettings
{

    public static void Save(object obj)
    {
        string path = JsonPath("", WindowsLocation.LocalData);
        JsonConvert.ObjectToJsonFile(obj, path);
    }//to do

    public static void Load(object obj)
    {
        string path = JsonPath("", WindowsLocation.LocalData);
        JsonConvert.JsonFileToObject(path, obj);
    }//to do

    private static string JsonPath(string fileName, WindowsLocation location)
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
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        fileName = !string.IsNullOrWhiteSpace(fileName) ? fileName : appNmae;
        return Path.Combine(dir, fileName + ".json");
    }

}