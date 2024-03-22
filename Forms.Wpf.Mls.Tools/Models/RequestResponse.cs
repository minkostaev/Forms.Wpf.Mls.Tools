namespace Forms.Wpf.Mls.Tools.Models;

public class RequestResponse
{
    public RequestResponse() { }
    public RequestResponse(int code, string name, string content)
    {
        Code = code;
        Name = name;
        Content = content;
    }

    public int Code { get; set; }
    public string? Name { get; set; }
    public string? Content { get; set; }
}

public enum RequestMethod
{
    GET,
    POST,
    PUT,
    DELETE
}