namespace Forms.Wpf.Mls.Tools.Services;

using System;
using System.Security.Cryptography;
using System.Text;

public static class More
{
    public static string HashString(string text, string salt = "")
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;
        byte[] textBytes = Encoding.UTF8.GetBytes(text + salt);
        byte[] hashBytes = SHA256.HashData(textBytes);
        string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
        return hash;
    }

}