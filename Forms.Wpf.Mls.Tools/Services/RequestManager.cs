namespace Forms.Wpf.Mls.Tools.Services;

using Forms.Wpf.Mls.Tools.Models;
using System.Net;
using System.Net.Http;
using System.Text;

public class RequestManager
{
    public RequestManager(Dictionary<string, string>? headers = null)
    {
        client = new HttpClient();
        if (headers != null)
        {
            foreach (var header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }
    }

    // Private

    private readonly HttpClient client;
    private string CheckForProtocol(string url)
    {
        if (url.StartsWith("https://") || url.StartsWith("http://"))
            return url;
        else
            return $"https://{url}";
    }

    // Public

    public async Task<RequestResponse> SendRequest(string target, RequestMethod method, string json = "")
    {
        var requestBody = new ByteArrayContent(Encoding.UTF8.GetBytes(json));
        return await SendRequest(target, method, requestBody);
    }
    public async Task<RequestResponse> SendRequest(string target, RequestMethod method, HttpContent? body = null)
    {
        HttpResponseMessage? httpResponse = null;
        target = CheckForProtocol(target);
        try
        {
            switch (method)
            {
                case RequestMethod.GET:
                    httpResponse = await client.GetAsync(target);
                    break;
                case RequestMethod.POST:
                    httpResponse = await client.PostAsync(target, body);
                    break;
                case RequestMethod.PUT:
                    httpResponse = await client.PutAsync(target, body);
                    break;
                case RequestMethod.DELETE:
                    httpResponse = await client.DeleteAsync(target);
                    break;
            }
        }
        catch (Exception ex)
        {
            return new RequestResponse(0, "Error", ex.Message);
        }
        if (httpResponse == null)
        {
            return new RequestResponse(0, "Error", "null");
        }

        HttpStatusCode responseStatus = httpResponse.StatusCode;
        int code = (int)responseStatus;
        string name = responseStatus.ToString();

        HttpContent responseContent = httpResponse.Content;
        var content = await responseContent.ReadAsStringAsync();

        httpResponse.Dispose();

        return new RequestResponse(code, name, content);
    }

}