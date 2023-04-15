namespace Forms.Wpf.Mls.Tools.Services;

using System.IO;
using System.Text.Json;

public static class JsonConvert
{

    public static object? JsonStringToObject(string json, object obj)
    {
        try
        {
            var type = obj.GetType();
            var jsonDoc = JsonDocument.Parse(json);
            var result = JsonSerializer.Deserialize(jsonDoc, type);
            jsonDoc.Dispose();
            return result;
        }
        catch (Exception) { return null; }
    }
    public static object? JsonFileToObject(string? filePath, object obj)
    {
        if (!File.Exists(filePath))
        {
            return null;
        }
        try
        {
            string json = File.ReadAllText(filePath);
            return JsonStringToObject(json, obj);
        }
        catch (Exception) { return null; }
    }

    public static string ObjectToJsonString(object obj)
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
    public static bool ObjectToJsonFile(object obj, string filePath)
    {
        try
        {
            var jsonString = ObjectToJsonString(obj);
            File.WriteAllText(filePath, jsonString);
            return true;
        }
        catch (Exception) { return false; }
    }

}
// to do describe the methods