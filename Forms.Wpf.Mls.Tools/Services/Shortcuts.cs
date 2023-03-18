using IWshRuntimeLibrary;
using System.Diagnostics;
using System.IO;

// add reference from COM tab - Windows Script Host Object Model
namespace Forms.Wpf.Mls.Tools.Services;

public static class Shortcuts
{
    public static void CreateShortcut(string? exePath, string? shortcutPath, string? shortcutComment = "")
    {
        // Create a new shortcut object
        WshShell shell = new WshShell();
        IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);

        // Set shortcut properties
        shortcut.TargetPath = exePath;
        shortcut.WorkingDirectory = Path.GetDirectoryName(exePath);
        shortcut.Description = shortcutComment;
        shortcut.IconLocation = exePath + ",0";

        // Save the shortcut
        shortcut.Save();
    }

    #region Startup Shortcut
    private static string? exePath => Process.GetCurrentProcess().MainModule?.FileName;
    private static string lnkPath => Path.Combine(SpecialFolders.StartupUser,
        Path.GetFileNameWithoutExtension(exePath) + ".lnk");

    public static bool IsAppInpStartup => System.IO.File.Exists(lnkPath);

    public static void AddAppStartupShortcut()
    {
        if (!System.IO.File.Exists(lnkPath))
        {
            CreateShortcut(exePath, lnkPath, Path.GetFileNameWithoutExtension(exePath));
        }
    }
    public static void RemoveAppStartupShortcut()
    {
        if (System.IO.File.Exists(lnkPath))
        {
            System.IO.File.Delete(lnkPath);
        }
    }
    #endregion

}