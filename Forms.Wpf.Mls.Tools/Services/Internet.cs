namespace Forms.Wpf.Mls.Tools.Services;

using System.Net.NetworkInformation;

public static class Internet
{
    public static bool CheckForConnection(string site = "")
    {
        site = string.IsNullOrWhiteSpace(site) ? "www.google.com.mx" : site;
        bool result;
        try { result = new Ping().Send(site).Status == IPStatus.Success; }
        catch { result = false; }
        return result;
    }

}