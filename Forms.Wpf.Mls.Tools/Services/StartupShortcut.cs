namespace Forms.Wpf.Mls.Tools.Services;

using System.Diagnostics;
using System.IO;

public class StartupShortcut
{
    private string? ExePath { get; set; }
    private string LinkPath { get; set; }

    public StartupShortcut(string? exePath = "")
    {
        if (!File.Exists(exePath))
            ExePath = Process.GetCurrentProcess().MainModule?.FileName;
        string lnk = Path.GetFileNameWithoutExtension(ExePath) + ".lnk";
        LinkPath = Path.Combine(SpecialFolders.StartupUser, lnk);
    }

    public bool IsAppInStartup => File.Exists(LinkPath);

    public void Add()
    {
        if (!IsAppInStartup)
        {
            Shortcut.Create(ExePath, LinkPath, Path.GetFileNameWithoutExtension(ExePath));
        }
    }
    public void Remove()
    {
        if (IsAppInStartup)
        {
            File.Delete(LinkPath);
        }
    }

}