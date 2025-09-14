namespace Forms.Wpf.Mls.Tools.Services;

using System.IO;
using System.Reflection;

public static class SpecialFolders
{
    /// <summary>
    /// C:
    /// </summary>
    public static string SystemDrive => Environment.GetEnvironmentVariable("SystemDrive") ?? "C:";

    /// <summary>
    /// Path to this exe
    /// </summary>
    public static string CurrentDirectory => Environment.CurrentDirectory;

    #region Windows
    /// <summary>
    /// C:\Windows
    /// </summary>
    public static string Windows => Environment.GetFolderPath(Environment.SpecialFolder.Windows);

    /// <summary>
    /// C:\Windows\System32__or__C:\Windows\SysWOW64
    /// </summary>
    /// <param name="x86"></param>
    /// <param name="useShell"></param>
    /// <returns></returns>
    public static string WindowsSystem(bool x86 = false, bool useShell = false)
    {
        if (x86)
            return Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
        if (useShell)
            return Environment.GetFolderPath(Environment.SpecialFolder.System);
        return Environment.SystemDirectory;
    }

    /// <summary>
    /// C:\Windows\Fonts
    /// </summary>
    public static string WindowsFonts => Environment.GetFolderPath(Environment.SpecialFolder.Fonts);

    /// <summary>
    /// C:\Windows\Resources
    /// </summary>
    public static string WindowsResources => Environment.GetFolderPath(Environment.SpecialFolder.Resources);
    #endregion

    #region Program Files
    /// <summary>
    /// C:\Program Files__or__C:\Program Files (x86)
    /// </summary>
    /// <param name="x86"></param>
    /// <returns></returns>
    public static string ProgramFiles(bool x86 = false)
    {
        if (x86)
            return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
        return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
    }

    /// <summary>
    /// C:\Program Files\Common Files__or__C:\Program Files (x86)\Common Files
    /// </summary>
    /// <param name="x86"></param>
    /// <returns></returns>
    public static string ProgramFilesCommon(bool x86 = false)
    {
        if (x86)
            return Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFilesX86);
        return Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles);
    }
    #endregion

    /// <summary>
    /// C:\ProgramData
    /// </summary>
    public static string ProgramData => Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

    #region User and AppData
    /// <summary>
    /// C:\Users\username
    /// </summary>
    public static string UserProfile => Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

    /// <summary>
    /// C:\Users\username\AppData\Local
    /// </summary>
    public static string LocalAppData => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

    /// <summary>
    /// C:\Users\username\AppData\Roaming
    /// </summary>
    public static string RoamingAppData => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

    /// <summary>
    /// C:\Users\username\AppData\Roaming\Microsoft\Windows\Recent
    /// </summary>
    public static string Recent => Environment.GetFolderPath(Environment.SpecialFolder.Recent);

    /// <summary>
    /// C:\Users\username\AppData\Roaming\Microsoft\Windows\SendTo
    /// </summary>
    public static string SendTo => Environment.GetFolderPath(Environment.SpecialFolder.SendTo);

    /// <summary>
    /// C:\Users\username\AppData\Roaming\Microsoft\Windows\Network Shortcuts
    /// </summary>
    public static string NetworkShortcuts => Environment.GetFolderPath(Environment.SpecialFolder.NetworkShortcuts);

    /// <summary>
    /// C:\Users\username\AppData\Roaming\Microsoft\Windows\PrintHood
    /// </summary>
    public static string PrinterShortcuts => Environment.GetFolderPath(Environment.SpecialFolder.PrinterShortcuts);

    /// <summary>
    /// C:\Users\username\AppData\Local\Temp
    /// </summary>
    public static string Temp => Path.GetTempPath();
    #endregion

    #region User Folders
    /// <summary>
    /// C:\Users\username\Desktop__or__C:\Users\Public\Desktop
    /// </summary>
    /// <param name="isPublic"></param>
    /// <param name="isLogical"></param>
    /// <returns></returns>
    public static string Desktop(bool isPublic = false, bool isLogical = false)
    {
        if (isPublic)
            return Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
        if (isLogical)
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        ///Environment.GetFolderPath((Environment.SpecialFolder)0)
        return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
    }

    /// <summary>
    /// C:\Users\username\Documents__or__C:\Users\Public\Documents
    /// </summary>
    /// <param name="isPublic"></param>
    /// <returns></returns>
    public static string Documents(bool isPublic = false)
    {
        if (isPublic)
            return Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
        ///Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    }

    /// <summary>
    /// C:\Users\username\Pictures__or__C:\Users\Public\Pictures
    /// </summary>
    /// <param name="isPublic"></param>
    /// <returns></returns>
    public static string Pictures(bool isPublic = false)
    {
        if (isPublic)
            return Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
        return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
    }

    /// <summary>
    /// C:\Users\username\Music__or__C:\Users\Public\Music
    /// </summary>
    /// <param name="isPublic"></param>
    /// <returns></returns>
    public static string Music(bool isPublic = false)
    {
        if (isPublic)
            return Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic);
        return Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
    }

    /// <summary>
    /// C:\Users\username\Videos__or__C:\Users\Public\Videos
    /// </summary>
    /// <param name="isPublic"></param>
    /// <returns></returns>
    public static string Videos(bool isPublic = false)
    {
        if (isPublic)
            return Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos);
        return Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
    }

    /// <summary>
    /// C:\Users\username\Favorites
    /// </summary>
    /// <returns></returns>
    public static string Favorites(bool isPublic = false)
    {
        //if (isPublic)
        //    return Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
        return Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
    }

    /// <summary>
    /// C:\Users\username\Downloads
    /// </summary>
    /// <returns></returns>
    public static string Download(bool isPublic = false)
    {// to do improve
        return Path.Combine(UserProfile, "Downloads");
    }
    #endregion

    #region Start Menu
    /// <summary>
    /// C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup
    /// </summary>
    public static string StartupSystem => Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup);

    /// <summary>
    /// C:\Users\username\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup
    /// </summary>
    public static string StartupUser => Environment.GetFolderPath(Environment.SpecialFolder.Startup);

    /// <summary>
    /// C:\ProgramData\Microsoft\Windows\Start Menu
    /// </summary>
    public static string StartMenuSystem => Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);

    /// <summary>
    /// C:\Users\username\AppData\Roaming\Microsoft\Windows\Start Menu
    /// </summary>
    public static string StartMenuUser => Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);

    /// <summary>
    /// C:\ProgramData\Microsoft\Windows\Start Menu\Programs
    /// </summary>
    public static string StartMenuProgramsSystem => Environment.GetFolderPath(Environment.SpecialFolder.CommonPrograms);

    /// <summary>
    /// C:\Users\shefa\AppData\Roaming\Microsoft\Windows\Start Menu\Programs
    /// </summary>
    public static string StartMemuProgramsUser => Environment.GetFolderPath(Environment.SpecialFolder.Programs);

    /// <summary>
    /// C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Administrative Tools
    /// </summary>
    public static string AdminToolsSystem => Environment.GetFolderPath(Environment.SpecialFolder.CommonAdminTools);

    /// <summary>
    /// C:\Users\username\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Administrative Tools
    /// </summary>
    public static string AdminToolsUser => Environment.GetFolderPath(Environment.SpecialFolder.AdminTools);
    #endregion

    /// <summary>
    /// C:\\Users\\username\\AppData\\Roaming\\Microsoft\\Windows\\Templates
    /// </summary>
    public static string TemplatesUser => Environment.GetFolderPath(Environment.SpecialFolder.Templates);

    /// <summary>
    /// C:\ProgramData\Microsoft\Windows\Templates
    /// </summary>
    public static string TemplatesSystem => Environment.GetFolderPath(Environment.SpecialFolder.CommonTemplates);

    ///Environment.SpecialFolder.MyComputer isn’t a real directory — it’s a shell abstraction
    ///Environment.SpecialFolder.InternetCache it's about Internet Explorer components
    ///Environment.SpecialFolder.Cookies it's about Internet Explorer’s legacy infrastructure
    ///Environment.SpecialFolder.History another legacy Internet Explorer component
    ///Environment.SpecialFolder.LocalizedResources
    ///Environment.SpecialFolder.CommonOemLinks Original Equipment Manufacturers
    ///Environment.SpecialFolder.CDBurning Staging area for CD/DVD burning

    /// <summary>
    /// Convert name of special folder to full path ex: "Windows" to "C:\Windows"
    /// </summary>
    /// <param name="nameOrPath"></param>
    public static string NameToPath(string nameOrPath)
    {
        if (string.IsNullOrWhiteSpace(nameOrPath))
            return string.Empty;

        string folderName = nameOrPath.Split("\\").FirstOrDefault()!.ToLower();
        string restOfPath = nameOrPath[folderName.Length..];
        string specialPath = string.Empty;

        Type type = typeof(SpecialFolders);
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (PropertyInfo prop in properties)
        {
            var name = prop.Name.ToLower();
            if (name == folderName)
            {
                specialPath = prop.GetValue(null)!.ToString()!;
                return specialPath + restOfPath;
            }
        }
        // Excludes get_/set_/op_/etc.
        var realMethods = methods.Where(m => !m.IsSpecialName).ToArray();
        foreach (MethodInfo method in realMethods)
        {
            var name = method.Name.ToLower();
            if (name == "resolvepath")
                continue;
            List<string> names = [name, name + "x86", name + "public"];
            if (names.Contains(folderName))
            {
                if (folderName.EndsWith("public"))
                {
                    if (folderName == "desktoppublic")
                    {
                        specialPath = method.Invoke(null, [true, false])!.ToString()!;
                        break;
                    }
                    specialPath = method.Invoke(null, [true])!.ToString()!;
                    break;
                }
                specialPath = folderName switch
                {
                    "windowssystem" => method.Invoke(null, [false, false])!.ToString()!,
                    "windowssystemx86" => method.Invoke(null, [true, false])!.ToString()!,
                    "desktop" => method.Invoke(null, [false, false])!.ToString()!,
                    "programfilesx86" => method.Invoke(null, [true])!.ToString()!,
                    "programfilescommonx86" => method.Invoke(null, [true])!.ToString()!,
                    _ => method.Invoke(null, [false])!.ToString()!
                };
                break;
            }
        }
        return specialPath + restOfPath;
    }

}