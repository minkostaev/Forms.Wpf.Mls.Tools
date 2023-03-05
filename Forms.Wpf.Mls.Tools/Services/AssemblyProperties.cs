using System.Reflection;

namespace Forms.Wpf.Mls.Tools.Services;

public static class AssemblyProperties
{
    private static Assembly? AssemblyEntry => Assembly.GetEntryAssembly();
    private static Assembly? AssemblyExecuting => Assembly.GetExecutingAssembly();

    /// <summary>
    /// Exe name
    /// </summary>
    public static string AssemblyName
    {
        get
        {
            var assembly = AssemblyEntry;
            if (assembly == null)
                return "AssemblyName";
            else
            {
                var name = assembly.GetName().Name;
                if (name == null)
                    return "AssemblyName";
                else
                    return name;
            }
        }
    }

    /// <summary>
    /// Exe icon
    /// </summary>
    public static Icon? AssemblyIcon
    {
        get
        {
            if (AssemblyEntry == null)
            {
                return null;
            }
            else
            {
                return Icon.ExtractAssociatedIcon(AssemblyEntry.Location);
            }
        }
    }


    public static string? AppVersion
    {
        get
        {
            try
            {
                return AssemblyExecuting?.GetName()?.Version?.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

}