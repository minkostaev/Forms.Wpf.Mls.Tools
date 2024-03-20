namespace Forms.Wpf.Mls.Tools.Services;

using AKSoftware.Localization.MultiLanguages;
using AKSoftware.Localization.MultiLanguages.Providers;
using System.Globalization;

public static class LanguageService
{
    private static FolderResourceKeysProvider YmlDir => new("Languages");

    private static ILanguageContainerService? _List;
    private static ILanguageContainerService? List
    {
        get
        {
            if (_List == null)
            {
                try { _List = new LanguageContainer(YmlDir); }
                catch { return null; }
            }
            return _List;
        }
    }

    public static void SetCulture(string culture)
    {
        _List = null;
        try { CultureInfo.CurrentCulture = new CultureInfo(culture); }
        //CultureInfo.CurrentUICulture = new CultureInfo(culture.ToString().Replace("_", "-"));
        catch { }
    }

    public static string GetValue(string labelId)
    {
        string result = labelId;
        if (List != null)
            result = List[labelId];
        return result;
    }

}

//https://akmultilanguages.azurewebsites.net/
// in project file 
//<ItemGroup>
//  <Content Include = "Languages\**">
//    <CopyToOutputDirectory> PreserveNewest </CopyToOutputDirectory>
//  </Content>
//</ItemGroup>