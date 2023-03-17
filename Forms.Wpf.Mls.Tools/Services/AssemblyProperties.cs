using System.Reflection;

namespace Forms.Wpf.Mls.Tools.Services;

public static class AssemblyProperties
{
    private static Assembly? AssemblyEntry => Assembly.GetEntryAssembly();//exe
    private static Assembly? AssemblyExecuting => Assembly.GetExecutingAssembly();//dll

    /// <summary>
    /// Exe name
    /// </summary>
    public static string? AssemblyName => AssemblyEntry?.GetName().Name;
    public static string? DllName => AssemblyExecuting?.GetName().Name;
    
    /// <summary>
    /// Exe icon
    /// </summary>
    public static Icon? AssemblyIcon => 
        (AssemblyEntry != null) ? Icon.ExtractAssociatedIcon(AssemblyEntry.Location) : null;

    

    public static string? AppVersion => AssemblyEntry?.GetName()?.Version?.ToString();
    public static string? DllVersion => AssemblyExecuting?.GetName()?.Version?.ToString();

}