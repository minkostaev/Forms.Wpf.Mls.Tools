namespace Forms.Wpf.Mls.Tools.Services;

using System;
using System.IO.Compression;
using System.IO;
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

    public static string GetSha256Hash(this string rawData)
    {
        var bytes = Encoding.UTF8.GetBytes(rawData);
        return bytes.GetSha2Hash();
    }
    public static string GetSha2Hash(this byte[] input)
    {
        var key = SHA256.Create().ComputeHash(input);
        var builder = new StringBuilder();
        foreach (var b in key)
        {
            builder.Append(b.ToString("X"));
        }
        return builder.ToString();
    }

    public static byte[] Zip(this string inputString)
    {
        var bytes = Encoding.UTF8.GetBytes(inputString);
        using (var inputStream = new MemoryStream(bytes))
        {
            using (var outputStream = new MemoryStream())
            {
                using (var zipStream = new GZipStream(outputStream, CompressionMode.Compress))
                {
                    inputStream.CopyTo(zipStream);
                }
                return outputStream.ToArray();
            }
        }
    }
    public static string Unzip(this byte[] inputBytes)
    {
        using (var inputStream = new MemoryStream(inputBytes))
        {
            using (var outputStream = new MemoryStream())
            {
                using (var zipStream = new GZipStream(inputStream, CompressionMode.Decompress))
                {
                    zipStream.CopyTo(outputStream);
                }
                return Encoding.UTF8.GetString(outputStream.ToArray());
            }
        }
    }

}