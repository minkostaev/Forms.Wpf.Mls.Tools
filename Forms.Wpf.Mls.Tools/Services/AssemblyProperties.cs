namespace Forms.Wpf.Mls.Tools.Services;

using System.IO;
using System.Reflection;

public static class AssemblyProperties
{
    private static Assembly? Exe => Assembly.GetEntryAssembly();
    private static Assembly? Dll => Assembly.GetExecutingAssembly();

    // public

    public static string? ExeName => Exe?.GetName().Name;
    public static string? DllName => Dll?.GetName().Name;

    public static string? ExePath => Exe?.Location;
    public static string? DllPath => Dll?.Location;

    public static string? AppVersion => Exe?.GetName()?.Version?.ToString();
    public static string? DllVersion => Dll?.GetName()?.Version?.ToString();

    public static Icon? ExeIcon => (Exe != null) ? Icon.ExtractAssociatedIcon(Exe.Location) : null;

}
// to do add more properties