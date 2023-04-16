namespace Forms.Wpf.Mls.Tools.Services;

using System.IO;
using System.Text.Json;

public static class JsonConvert
{

    /// <summary>
    /// Deserialize Json string to object.
    /// </summary>
    /// <param name="obj">It is needed only to get type</param>
    /// <param name="json"></param>
    /// <returns></returns>
    public static object? JsonStringToObject(object? obj, string json)
    {
        try
        {
            var type = obj?.GetType();
            if (type == null)
                return null;
            var jsonDoc = JsonDocument.Parse(json);
            var result = JsonSerializer.Deserialize(jsonDoc, type);
            jsonDoc.Dispose();
            return result;
        }
        catch (Exception) { return null; }
    }
    /// <summary>
    /// Deserialize Json file to object.
    /// </summary>
    /// <param name="obj">It is needed only to get type</param>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static object? JsonFileToObject(object? obj, string? filePath)
    {
        if (!File.Exists(filePath))
        {
            return null;
        }
        try
        {
            string json = File.ReadAllText(filePath);
            return JsonStringToObject(obj, json);
        }
        catch (Exception) { return null; }
    }

    /// <summary>
    /// Serialize Json object to string.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string ObjectToJsonString(object? obj)
    {
        try
        {
            return JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
        catch (Exception) { return string.Empty; }
    }
    /// <summary>
    /// Serialize Json object to file.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static bool ObjectToJsonFile(object? obj, string? filePath)
    {
        try
        {
            var jsonString = ObjectToJsonString(obj);
            if (string.IsNullOrWhiteSpace(filePath))
                return false;
            File.WriteAllText(filePath, jsonString);
            return true;
        }
        catch (Exception) { return false; }
    }

}