namespace Forms.Wpf.Mls.Tools.Services;

using System.Collections.Generic;
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

    /// <summary>
    /// Deserialize any Json file to Dictionary.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static Dictionary<string, object?>? JsonFileToDictionary(string? filePath)
    {
        if (!File.Exists(filePath))
        {
            return null;
        }
        try
        {
            string json = File.ReadAllText(filePath);
            return JsonToDictionary(json);
        }
        catch (Exception) { return null; }
    }
    /// <summary>
    /// Deserialize any Json string to Dictionary.
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    public static Dictionary<string, object?> JsonToDictionary(string json)
    {
        JsonDocument jDocument = JsonDocument.Parse(json);

        JsonElement jRoot = jDocument.RootElement;

        var jsonDictionary = new Dictionary<string, object?>();
        if (jRoot.ValueKind == JsonValueKind.Object)
        {
            foreach (JsonProperty jProperty in jRoot.EnumerateObject())
            {
                var keyValue = JsonObjectToKeyValue(jProperty, jRoot);
                jsonDictionary.Add(keyValue.Key, keyValue.Value);
            }
        }
        else
        {
            jsonDictionary.Add("key", GetValueFromJson(jRoot.ValueKind, jRoot));
        }

        jDocument.Dispose();

        return jsonDictionary;
    }

    private static KeyValuePair<string, object?> JsonObjectToKeyValue(JsonProperty jProperty, JsonElement jElement)
    {
        string key = jProperty.Name;
        object? value = GetValueFromJson(jProperty.Value.ValueKind, jElement, key);

        return new KeyValuePair<string, object?>(key, value);
    }
    private static object? GetValueFromJson(JsonValueKind objectType, JsonElement jElement, string propertyName = "")
    {
        JsonElement jsonElement = jElement;
        if (!string.IsNullOrWhiteSpace(propertyName))
        {
            jElement.TryGetProperty(propertyName, out jsonElement);
        }

        switch (objectType)
        {
            case JsonValueKind.Object:
                var dictionary = new Dictionary<string, object?>();
                foreach (JsonProperty jProp in jsonElement.EnumerateObject())
                {
                    var val = JsonObjectToKeyValue(jProp, jsonElement);
                    dictionary.Add(val.Key, val.Value);
                }
                return dictionary;
            case JsonValueKind.Array:
                var list = new List<object?>();
                var jList = jsonElement.EnumerateArray();
                foreach (var el in jList)
                {
                    var val = GetValueFromJson(el.ValueKind, el);
                    list.Add(val);
                }
                return list;
            case JsonValueKind.String:
                return jsonElement.GetString();
            case JsonValueKind.Number:
                bool isInt = jsonElement.TryGetInt32(out int intNumber);
                if (isInt)
                {
                    return intNumber;
                }
                else
                {
                    jsonElement.TryGetDecimal(out decimal decimalNumber);
                    return decimalNumber;
                }
            case JsonValueKind.True:
                return true;
            case JsonValueKind.False:
                return false;
            case JsonValueKind.Null:
            case JsonValueKind.Undefined:
            default:
                return null;
        }
    }

}