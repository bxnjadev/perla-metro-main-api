using System.Text.Json;

namespace perla_metro_main_api.Util;

public class HttpResponseWrapper<TO>
{

    private readonly string _content = string.Empty;
    private readonly int _statusCode = 0;

    public HttpResponseWrapper(string content, 
        int statusCode)
    {
        this._content = content;
        this._statusCode = statusCode;
    }

    public bool IsOk()
    {
        return _statusCode >= 200 || _statusCode < 300;
    }

    public string GetContent()
    {
        return _content;
    }
    public int GetStatusCode()
    {
        return _statusCode;
    }
    
    public string GetMessageError()
    {
        var message = JsonSerializer.Deserialize<string>(_content);
        return message != null ? message : string.Empty;
    }

    public TO? ParseObject()
    {
        return JsonSerializer.Deserialize<TO>(_content);
    }

}