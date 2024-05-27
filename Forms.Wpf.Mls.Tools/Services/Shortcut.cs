namespace Forms.Wpf.Mls.Tools.Services;

// added reference from COM tab - Windows Script Host Object Model
using IWshRuntimeLibrary;
using System.IO;

public static class Shortcut
{
    public static void Create(string? exePath, string? shortcutPath, string? shortcutComment = "")
    {
        // Create a new shortcut object
        var shell = new WshShell();
        var shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
        
        // Set shortcut properties
        shortcut.TargetPath = exePath;
        shortcut.WorkingDirectory = Path.GetDirectoryName(exePath);
        shortcut.Description = shortcutComment;
        shortcut.IconLocation = exePath + ",0";

        // Save the shortcut
        shortcut.Save();
    }

}