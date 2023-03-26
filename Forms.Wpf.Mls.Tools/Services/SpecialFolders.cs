namespace Forms.Wpf.Mls.Tools.Services;

public static class SpecialFolders
{

    /// <summary>
    /// C:\ProgramData
    /// </summary>
    public static string CommonAppData => Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

    /// <summary>
    /// C:\Users\username\AppData\Local
    /// </summary>
    public static string LocalAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

    /// <summary>
    /// C:\Users\username\AppData\Roaming
    /// </summary>
    public static string RoamingFolder => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

    /// <summary>
    /// C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup
    /// </summary>
    public static string StartupSystem => Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup);

    /// <summary>
    /// C:\Users\username\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup
    /// </summary>
    public static string StartupUser => Environment.GetFolderPath(Environment.SpecialFolder.Startup);


}
// to do add more